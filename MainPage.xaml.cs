using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MusicLibrary.Model;
using System.Collections.ObjectModel;
//using System.Text.RegularExpressions;
using Newtonsoft.Json;
//using System.Text.Json;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // This is the exhaustive list of Songs present in the Music Library
        // User can select any number of songs from this list to create a favorite Playlist
        private List<EachSongLine> SongList;

        // This is a list of all the Playlists created by the user
        // This is read from playlists.txt file stores in the User-AppData-directory
        private ObservableCollection<EachPlayList> playLists;

        // These are the songs selected by the user to add to a Playlist
        // (only in the context of the current session
        private ObservableCollection <EachSongLine> SelectedSongs;

        // The current Playlist created by the user (add songs in next page)
        // Or it can be the playlist selected from the list to view details
        private EachPlayList currentPlaylist;

        // Data Binding in ListView or GridView can only be done with a collection object
        // Hence I created this one-object collection of Playlist to display details in UI
        private ObservableCollection<EachPlayList> thisPlayList;

        // This is the list of all available pics. This is used to populate the 
        // Iamges combo box during playlist creation
        private List<CoverImage> listOfImages;

        public MainPage()
        {
            this.InitializeComponent();
            SongList = new List<EachSongLine>();
            playLists = new ObservableCollection<EachPlayList>();
            SelectedSongs = new ObservableCollection<EachSongLine>();
            currentPlaylist = new EachPlayList();
            thisPlayList = new ObservableCollection<EachPlayList>();
            listOfImages = new List<CoverImage>();

            ViewManager.Initialize(SongList, SelectedSongs, listOfImages);
            currentPlaylist.Songs = new ObservableCollection<EachSongLine>();
            currentPlaylist.Songs.Clear();
            thisPlayList.Clear();

            AllSongsListView.Visibility = Visibility.Collapsed;
            PlayListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Collapsed;
            ThisPlayListView.Visibility = Visibility.Collapsed;
            SongsInThisPlayListView.Visibility = Visibility.Collapsed;
        }

        // This method is invoked when user clicks on anyone of the songs on
        // All Songs Display Page. 
        private void AllSongsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var songLine = (EachSongLine)e.ClickedItem;
            MyMediaElement.Source = new Uri(this.BaseUri, songLine.AudioFile);
            MyMediaElement.Play();
                            
        }

        // This method is invoked when user clicks on the "My Playlists" menu item
        // on LHS panel. This method reads all the playlists details from playlists.txt 
        // and displays names of all playlists on the RHS pane
        private void PlayListHeader_Click(object sender, RoutedEventArgs e)
        {
            PlayListView.Visibility = Visibility.Visible;
            AllSongsListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Collapsed;
            ThisPlayListView.Visibility = Visibility.Collapsed;
            SongsInThisPlayListView.Visibility = Visibility.Collapsed;

            var playListLines = new List<EachPlayList>();
            var localAppDataPath = Environment.SpecialFolder.LocalApplicationData;
            string root = Environment.GetFolderPath(localAppDataPath);
            string playListFileName = $@"{root}\MusicLibrary\playlists.txt";

            if (File.Exists(playListFileName))
            {
                string[] rowsReadFromFile = File.ReadAllLines(playListFileName);

                // Using json to retrieve playlist details from file
                foreach (string eachRow in rowsReadFromFile)
                {
                    EachPlayList eachList = JsonConvert.DeserializeObject<EachPlayList>(eachRow);
                    playListLines.Add(eachList);
                }
            }
            else
            {
                File.Create(playListFileName);
            }


            playLists.Clear();
            playListLines.ForEach(each => playLists.Add(each));
            currentPlaylist.Songs.Clear();

        }


        // This method is invoked when user clicks on the "All Songs" menu item 
        // on LHS panel. This method displays all available songs in the App
        private void AllSongsHeader_Click(object sender, RoutedEventArgs e)
        {
            PlayListView.Visibility = Visibility.Collapsed;
            AllSongsListView.Visibility = Visibility.Visible;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Collapsed;
            ThisPlayListView.Visibility = Visibility.Collapsed;
            SongsInThisPlayListView.Visibility = Visibility.Collapsed;
        }

        // This method is invoked when user clicks on the "Create Playlist" menu item 
        // on LHS panel. User can enter name, description and image to create a Playlist
        // On click of "Create" button user is taken to the next page to add songs to
        // this newly created playlist. Playlist is not created if songs are not added

        private void CreatePlayListHeader_Click(object sender, RoutedEventArgs e)
        {
            PlayListView.Visibility = Visibility.Collapsed;
            AllSongsListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Visible;
            AddSongsView.Visibility = Visibility.Collapsed;
            ThisPlayListView.Visibility = Visibility.Collapsed;
            SongsInThisPlayListView.Visibility = Visibility.Collapsed;
        }

        // This method is invoked when the user clicks on the "Create" button on 
        // "Create Playlist" pane. On this pane you can give a name, description 
        // pick an image to create a playlist. Playlist is not created yet.
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string NewName = NewPlayListNameBox.Text;
            string NewDescription = PlayListDescriptionBox.Text;
            string NewImage = ((CoverImage)PlayListImageComboBox.SelectedValue).ImageFile;
            currentPlaylist.Name = NewName;
            currentPlaylist.Description = NewDescription;
            currentPlaylist.ImageFile = NewImage;
            playLists.Add(currentPlaylist);

            //Clear all form data
            currentPlaylist.Songs.Clear();
            NewPlayListNameBox.Text = "";
            PlayListDescriptionBox.Text = "";
            PlayListImageComboBox.SelectedIndex = -1;

            PlayListView.Visibility = Visibility.Collapsed;
            AllSongsListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Visible;
            ThisPlayListView.Visibility = Visibility.Collapsed;
            SongsInThisPlayListView.Visibility = Visibility.Collapsed;
        }

        // This method is invoked by the "Add Songs" button. The playlist is created and details
        // stored in the playlists.txt file. Uses json to write to playlists.txt file
        private void AddSongsViewAddButton_Click(object sender, RoutedEventArgs e)
        {

            foreach (var every in SelectedSongs)
            {
                if (every.IsSelected == true)
                {
                    var thisSong = new EachSongLine();
                    thisSong.SongTitle = every.SongTitle;
                    thisSong.AudioFile = every.AudioFile;
                    thisSong.IsSelected = true;
                    currentPlaylist.Songs.Add(thisSong);
                }
            }

            PlayListView.Visibility = Visibility.Collapsed;
            AllSongsListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Collapsed;
            ThisPlayListView.Visibility = Visibility.Collapsed;
            SongsInThisPlayListView.Visibility = Visibility.Collapsed;

            // Using json to write into File
            var localAppDataPath = Environment.SpecialFolder.LocalApplicationData;
            string root = Environment.GetFolderPath(localAppDataPath);
            string playListFileName = $@"{root}\MusicLibrary\playlists.txt";
            string writeToFile = JsonConvert.SerializeObject(currentPlaylist);
            currentPlaylist.Songs.Clear();


            // The new playlist details are appended as a single line entry
            // Inserting a newline to ensure next playlist is entered on next line
            if (File.Exists(playListFileName))
            {
                System.IO.File.AppendAllText(playListFileName, writeToFile);
                System.IO.File.AppendAllText(playListFileName, "\n");
            }
            else
            {
                File.Create(playListFileName);
            }

        }

        // This method is invoked when user checks on a song to add to the playlist
        // Nothing is done here. This is for later build-up for optimization
        private void SelectSongCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            
            if (cb.IsChecked == true)
            {
                return;
            }
        }

        // Thsi method is invoked when a playlist is clicked on from the RHS pane
        // This takes to next pane where the selected playlist's details are displayed
        private void PlayListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            thisPlayList.Clear();
            currentPlaylist.Songs.Clear();
            currentPlaylist.Name = ((EachPlayList)e.ClickedItem).Name;

            foreach (var each in ((EachPlayList)e.ClickedItem).Songs)
            {
                currentPlaylist.Songs.Add(each);
            }
            thisPlayList.Add((EachPlayList)e.ClickedItem);
 
            PlayListView.Visibility = Visibility.Collapsed;
            AllSongsListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Collapsed;
            ThisPlayListView.Visibility = Visibility.Visible;
            SongsInThisPlayListView.Visibility = Visibility.Visible;
        }

        // Plays all the songs of the this particular playlist
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
                var firstSong = currentPlaylist.Songs.ElementAt(0);
                PlaylistMediaElement.Source = new Uri(this.BaseUri, firstSong.AudioFile);
                PlaylistMediaElement.Play();
        }

        // Stops playing this particular playlist
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            PlaylistMediaElement.Stop();
        }

        // Not implemented
        private void ThisPlayListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        // Pauses playing this particular playlist
        // Click Play to resume playing
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
                PlaylistMediaElement.Pause();
        }

        // This method is invoked when the "Play-icon" button next to a song is clicked
        // Plays the selected song
        private void EachSongPlayButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            // We have bound the AudioFile property of EachSongLine to the CommandParameter property of the Button
            MyMediaElement.Source = new Uri(this.BaseUri, b.CommandParameter.ToString());
            MyMediaElement.Play();

        }

        // This method is invoked when the "stop-icon" button next to a song is clicked
        // Stops playing the song
        private void EachSongStopButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            // We have bound the AudioFile property of EachSongLine to the CommandParameter property of the Button
            MyMediaElement.Stop();

        }
    }
}

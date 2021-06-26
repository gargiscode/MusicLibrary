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
using System.Text.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<EachSongLine> SongList;
        private List<EachPlayList> playLists;

        public MainPage()
        {
            this.InitializeComponent();
            SongList = new List<EachSongLine>();
            playLists = new List<EachPlayList>();

            ViewManager.Initialize(SongList,playLists);
            AllSongsListView.Visibility = Visibility.Collapsed;
            PlayListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Collapsed;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            leftSplitView.IsPaneOpen = !leftSplitView.IsPaneOpen;
        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void AllSongsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var songLine = (EachSongLine)e.ClickedItem;
            //string s1 = this.BaseUri.ToString();
            //string s2 = songLine.AudioFile;
            MyMediaElement.Source = new Uri(this.BaseUri, songLine.AudioFile);
            
            //MyMediaElement.Source = new Uri("C:/Users/gargi/source/repos/MusicLibrary/Assets/Audio/Cat.wav");
            //MyMediaElement.Play();

            //var song = e.OriginalSource.GetType();
            //AllSongsListView.Visibility = Visibility.Collapsed;
          
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            //string path = e.OriginalSource.ToString();
            //var song = (EachSongLine)AllSongsListView.Items;
            //Console.WriteLine(e.GetType());
            //Console.WriteLine(e.OriginalSource.GetType());
            //Console.WriteLine(e.OriginalSource.GetType().ToString());
            //var song = (EachSongLine)e.OriginalSource.GetType();
            //MyMediaElement.Source = new Uri(this.BaseUri, song.AudioFile);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPlayListButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PlayListHeader_Click(object sender, RoutedEventArgs e)
        {
            PlayListView.Visibility = Visibility.Visible;
            AllSongsListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Collapsed;
            var playListLines = new List<EachPlayList>();
            var localAppDataPath = Environment.SpecialFolder.LocalApplicationData;
            string root = Environment.GetFolderPath(localAppDataPath);
            string playListFileName = $@"{root}\MusicLibrary\playlists.txt";

            if (File.Exists(playListFileName))
            {
                string ListOFNames = File.ReadAllText(playListFileName);
                string[] PlayListNames = ListOFNames.Split(",");

                foreach (string every in PlayListNames)
                {
                    var iterator = new EachPlayList
                    {
                        Name = every
                    };
                    playListLines.Add(iterator);
                }
            }
            else
            {
                File.Create(playListFileName);
            }

            playListLines.ForEach(each => playLists.Add(each));


        }

        private void AllSongsHeader_Click(object sender, RoutedEventArgs e)
        {
            PlayListView.Visibility = Visibility.Collapsed;
            AllSongsListView.Visibility = Visibility.Visible;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Collapsed;
        }

        private void CreatePlayListHeader_Click(object sender, RoutedEventArgs e)
        {
            PlayListView.Visibility = Visibility.Collapsed;
            AllSongsListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Visible;
            AddSongsView.Visibility = Visibility.Collapsed;

            //var localAppDataPath = Environment.SpecialFolder.LocalApplicationData;
            //string root = Environment.GetFolderPath(localAppDataPath);
            //string playListFileName = $@"{root}\MusicLibrary\palylists.txt";

            //string ListOFNames = File.ReadAllText(playListFileName);
            //string[] PlayListNames = ListOFNames.Split(",");   
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string NewName = NewPlayListNameBox.Text;
            var NewPlayList = new EachPlayList
            {
                Name = NewName
            };
            playLists.Add(NewPlayList);
            PlayListView.Visibility = Visibility.Collapsed;
            AllSongsListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Visible;


            //string PlayListFileLocation;
            var localAppDataPath = Environment.SpecialFolder.LocalApplicationData;
            string root = Environment.GetFolderPath(localAppDataPath);
            string playListFileName = $@"{root}\MusicLibrary\playlists.txt";

            //string PlayListFileLocation = $@"{playListFileName}\{NewName}.json";
            File.AppendAllText(playListFileName,NewName);
          
            File.AppendAllText(playListFileName, ",");

         /*   
                        string text = JsonConvert.SerializeObject(songs); 

                        System.IO.File.WriteAllText(PlayListFileLocation, text);

                        if (Directory.Exists(playListDirectory))
                        {
                            PlayListFileLocation = $@"{playListDirectory}\{NewName}.json";
                            if (File.Exists(PlayListFileLocation))
                            {
                                //read the file
                                string fileText = System.IO.File.ReadAllText(PlayListFileLocation);

                                //converting text into list of music using JSON
                                playLists.Songs = JsonConvert.DeserializeObject<List<Music>>(fileText);
                            }
                            else //if file doesn't exist it creates a song object so that null reference exception doesn't happen
                            {
                                playLists.songs = new List<Music>();
                            }
                        }
                        else
                        {
                            Directory.CreateDirectory(playListDirectory);
                            this.songs = new List<Music>(); //creates a song object so that null reference exception doesn't happen
                        }
          */  
            //string playListDirectory = $@"{root}\MusicLibrary\playlists.txt";

            ////File.OpenWrite(playListDirectory);
            //File.
            //File.AppendAllText(playListDirectory, NewName);
        }

        private void AddSongsButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PlayListViewAddSongsButton_Click(object sender, RoutedEventArgs e)
        {
            //e;
            //string thisObject = PlayListView.SelectedItem.ToString();
            //PlayListView.SelectedItem.ToString;
        }

        private void PlayListViewPlayButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllSongsListViewPlayButton_Click(object sender, RoutedEventArgs e)
        {
            //var songLine = (EachSongLine)e.ClickedItem;
            
            //var playButton = e.OriginalSource;
            //MyMediaElement.Source = new Uri(this.BaseUri, this.AudioFile);
        }

        private void AddSongsViewPlayButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddSongsViewAddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

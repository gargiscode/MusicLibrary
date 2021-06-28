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
        private List<EachSongLine> SongList;
        private List<EachPlayList> playLists;
        private List<EachSongLine> SelectedSongs;
        private EachPlayList currentPlaylist;
        private List<EachSongLine> currentSongsList;

        public MainPage()
        {
            this.InitializeComponent();
            SongList = new List<EachSongLine>();
            playLists = new List<EachPlayList>();
            SelectedSongs = new List<EachSongLine>();
            currentPlaylist = new EachPlayList();
            currentSongsList = new List<EachSongLine>();

            ViewManager.Initialize(SongList,playLists, SelectedSongs);

            currentPlaylist.Songs = new List<EachSongLine>();

            currentSongsList = new List<EachSongLine>();

            AllSongsListView.Visibility = Visibility.Collapsed;
            PlayListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Collapsed;
            ThisPlayListView.Visibility = Visibility.Collapsed;
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
            MyMediaElement.Source = new Uri(this.BaseUri, songLine.AudioFile);
            
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
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
            ThisPlayListView.Visibility = Visibility.Collapsed;

            var playListLines = new List<EachPlayList>();
            var localAppDataPath = Environment.SpecialFolder.LocalApplicationData;
            string root = Environment.GetFolderPath(localAppDataPath);
            string playListFileName = $@"{root}\MusicLibrary\playlists.txt";

            string[] rowsReadFromFile = File.ReadAllLines(playListFileName);
            foreach (string eachRow in rowsReadFromFile)
            {
                EachPlayList eachList = JsonConvert.DeserializeObject<EachPlayList>(eachRow);
                playListLines.Add(eachList);
            }

            playListLines.ForEach(each => playLists.Add(each));


        }

        private void AllSongsHeader_Click(object sender, RoutedEventArgs e)
        {
            PlayListView.Visibility = Visibility.Collapsed;
            AllSongsListView.Visibility = Visibility.Visible;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Collapsed;
            ThisPlayListView.Visibility = Visibility.Collapsed;

        }

        private void CreatePlayListHeader_Click(object sender, RoutedEventArgs e)
        {
            PlayListView.Visibility = Visibility.Collapsed;
            AllSongsListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Visible;
            AddSongsView.Visibility = Visibility.Collapsed;
            ThisPlayListView.Visibility = Visibility.Collapsed;

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string NewName = NewPlayListNameBox.Text;
            currentPlaylist.Name = NewName;
            playLists.Add(currentPlaylist);
            PlayListView.Visibility = Visibility.Collapsed;
            AllSongsListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Visible;
            ThisPlayListView.Visibility = Visibility.Collapsed;
        }

        private void AddSongsButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PlayListViewAddSongsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PlayListViewPlayButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllSongsListViewPlayButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddSongsViewPlayButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddSongsViewAddButton_Click(object sender, RoutedEventArgs e)
        {

            currentPlaylist.Songs = new List<EachSongLine>();

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

            int i = currentPlaylist.Songs.Count;
            
            PlayListView.Visibility = Visibility.Visible;
            AllSongsListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Collapsed;
            ThisPlayListView.Visibility = Visibility.Collapsed;

            //Write into File
            var localAppDataPath = Environment.SpecialFolder.LocalApplicationData;
            string root = Environment.GetFolderPath(localAppDataPath);
            string playListFileName = $@"{root}\MusicLibrary\playlists.txt";
            string writeToFile = JsonConvert.SerializeObject(currentPlaylist);

            System.IO.File.AppendAllText(playListFileName, writeToFile);
            System.IO.File.AppendAllText(playListFileName, "\n");

        }

        private void SelectSongCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            
            if (cb.IsChecked == true)
            {
                return;
            }
        }

        private void ThisPlayListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void PlayPlayListButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddSongsToPlayListButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PlayListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            currentPlaylist.Songs.Clear();
            currentPlaylist.Name = ((EachPlayList)e.ClickedItem).Name;

            foreach (var each in ((EachPlayList)e.ClickedItem).Songs)
            {
                currentPlaylist.Songs.Add(each);
                currentSongsList.Add(each);
            }


            PlayListView.Visibility = Visibility.Collapsed;
            AllSongsListView.Visibility = Visibility.Collapsed;
            CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            AddSongsView.Visibility = Visibility.Collapsed;
            ThisPlayListView.Visibility = Visibility.Visible;


        }
    }
}

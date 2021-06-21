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
            
            MyMediaElement.Source = new Uri("C:/Users/gargi/source/repos/MusicLibrary/Assets/Audio/Cat.wav");
            MyMediaElement.Play();
            
            //var song = e.OriginalSource.GetType();
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

        }

        private void AllSongsHeader_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

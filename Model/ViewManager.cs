using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MusicLibrary.Model
{
    public static class ViewManager
    {
        //Scope to Optimize later
        public static void Initialize(List<EachSongLine> songList, List<EachPlayList> playList, List<EachSongLine> selectionList)
        {
            //Initialize SongLines
            songList.Clear();
            playList.Clear();
            selectionList.Clear();

            var SongLines = new List<EachSongLine>
            {
                new EachSongLine
                {
                    SongTitle = "First Song",
                    AudioFile = "/Assets/Audio/Cat.wav",
                    IsSelected = false
                },
                new EachSongLine
                {
                    SongTitle = "Second Song",
                    AudioFile = "/Assets/Audio/Clock.wav",
                    IsSelected = false

                },
                new EachSongLine
                {
                    SongTitle = "Third Song",
                    AudioFile = "/Assets/Audio/Cow.wav",
                    IsSelected = false
                },
                new EachSongLine
                {
                    SongTitle = "Fourth Song",
                    AudioFile = "/Assets/Audio/Gun.wav",
                    IsSelected = false
                },
                new EachSongLine
                {
                    SongTitle = "Fifth Song",
                    AudioFile = "/Assets/Audio/LOL.wav",
                    IsSelected = false
                },
                new EachSongLine
                {
                    SongTitle = "Sixth Song",
                    AudioFile = "/Assets/Audio/Ship.wav",
                    IsSelected = false
                },                
                new EachSongLine
                {
                    SongTitle = "Seventh Song",
                    AudioFile = "/Assets/Audio/Siren.wav",
                    IsSelected = false
                },
                 new EachSongLine
                {
                    SongTitle = "Eighth Song",
                    AudioFile = "/Assets/Audio/Spring.wav",
                    IsSelected = false
                }
            };

            int i = SongLines.Count;

            foreach(EachSongLine each in SongLines)
            {
                songList.Add(each);
                selectionList.Add(each);
            }

            /*
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

            playListLines.ForEach(each => playList.Add(each));

            */


            //SongLines.ForEach(each => songList.Add(each));

        }
        public static void GetDisplayList(List <EachSongLine> songList, List<EachPlayList> playList)
        {

        }
        public static void GetDisplayListByHeader(List<EachSongLine> songList, List<EachPlayList> playList, MenuHeader header)
        {
            if (header == MenuHeader.AllSongs)
            {
                //display songList

            }
            else if (header == MenuHeader.Playlists)
            {
                //display playlists names

            }
        }
    }
}

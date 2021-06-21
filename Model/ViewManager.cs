using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    public static class ViewManager
    {
        public static void Initialize(List<EachSongLine> songList, List<EachPlayList> playList)
        {
            //Initialize SongLines
            songList.Clear();
            playList.Clear();

            var SongLines = new List<EachSongLine>
            {
                new EachSongLine
                {
                    SongTitle = "First Song",
                    AudioFile = "/Assets/Audio/Cat.wav"
                },
                new EachSongLine
                {
                    SongTitle = "Second Song",
                    AudioFile = "/Assets/Audio/Clock.wav"
                },
                new EachSongLine
                {
                    SongTitle = "Third Song",
                    AudioFile = "/Assets/Audio/Cow.wav"
                },
                new EachSongLine
                {
                    SongTitle = "Fourth Song",
                    AudioFile = "/Assets/Audio/Gun.wav"
                },
                new EachSongLine
                {
                    SongTitle = "Fifth Song",
                    AudioFile = "/Assets/Audio/LOL.wav"
                },
                new EachSongLine
                {
                    SongTitle = "Sixth Song",
                    AudioFile = "/Assets/Audio/Ship.wav"
                },                new EachSongLine
                {
                    SongTitle = "Seventh Song",
                    AudioFile = "/Assets/Audio/Siren.wav"
                },
                 new EachSongLine
                {
                    SongTitle = "Eighth Song",
                    AudioFile = "/Assets/Audio/Spring.wav"
                }
            };

            int i = SongLines.Count;

            foreach(EachSongLine each in SongLines)
            {
                songList.Add(each);
            }

            var playListLines = new List<EachPlayList>
            {
                new EachPlayList
                {
                    Name="Gargi",
                    //SongTitles = {"First Song", "Second Song"}
                }
            };

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

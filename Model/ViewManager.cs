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
        //Loads all the songs, images in collection
        public static void Initialize(List<EachSongLine> songList, ObservableCollection<EachSongLine> selectionList, List<CoverImage> ImageList)
        {
            //Initialize SongLines
            songList.Clear();
            selectionList.Clear();

            var SongLines = new List<EachSongLine>
            {
                new EachSongLine
                {
                    SongTitle = "We like to party",
                    AudioFile = "/Assets/Audio/we_like.mp3",
                    IsSelected = false
                },
                new EachSongLine
                {
                    SongTitle = "Sunny Sunny",
                    AudioFile = "/Assets/Audio/sunny_sunny.mp3",
                    IsSelected = false

                },
                new EachSongLine
                {
                    SongTitle = "Dheere Dheere se",
                    AudioFile = "/Assets/Audio/dheere_dheere.mp3",
                    IsSelected = false
                },
                new EachSongLine
                {
                    SongTitle = "To Brazil",
                    AudioFile = "/Assets/Audio/to_brazil.mp3",
                    IsSelected = false
                },
                new EachSongLine
                {
                    SongTitle = "Woh pehli baar",
                    AudioFile = "/Assets/Audio/woh_pehli_baar.mp3",
                    IsSelected = false
                },
                new EachSongLine
                {
                    SongTitle = "Gur naalon ishq meetha",
                    AudioFile = "/Assets/Audio/gur_nalon.mp3",
                    IsSelected = false
                },                
                new EachSongLine
                {
                    SongTitle = "Dama dam mast kalander",
                    AudioFile = "/Assets/Audio/mast_kalander.mp3",
                    IsSelected = false
                },
                 new EachSongLine
                {
                    SongTitle = "Musu musu haasi diyo",
                    AudioFile = "/Assets/Audio/musu_musu.mp3",
                    IsSelected = false
                },
                 new EachSongLine
                {
                    SongTitle = "Kudiye ni tere brown rang de",
                    AudioFile = "/Assets/Audio/brown_rang.mp3",
                    IsSelected = false
                },
                 new EachSongLine
                {
                    SongTitle = "Jaanam dekhlo mit gayi dooriyan",
                    AudioFile = "/Assets/Audio/main_yahan.mp3",
                    IsSelected = false
                },
                 new EachSongLine
                {
                    SongTitle = "Bhool ja hai kasam tujhe muskura",
                    AudioFile = "/Assets/Audio/bhool_ja.mp3",
                    IsSelected = false
                },
                 new EachSongLine
                {
                    SongTitle = "We are going to Ibitza",
                    AudioFile = "/Assets/Audio/we_are.mp3",
                    IsSelected = false
                }
            };


            foreach(EachSongLine each in SongLines)
            {
                songList.Add(each);
                selectionList.Add(each);
            }

            ImageList.Clear();
            var Images = new List<CoverImage>
            {
                new CoverImage
                {
                    Name="celebration",
                    ImageFile="/Assets/Images/bhangra.png"
                },
               new CoverImage
                {
                    Name="happy",
                    ImageFile="/Assets/Images/dandiya.png"
                },
                   new CoverImage
                {
                    Name="meditation",
                    ImageFile="/Assets/Images/kishore.png"
                },
               new CoverImage
               {
                   Name = "romantic",
                   ImageFile = "/Assets/Images/lata.png"
                },
               new CoverImage
               {
                   Name = "melody",
                   ImageFile = "/Assets/Images/party.png"
                },
              new CoverImage
               {
                   Name = "melody",
                   ImageFile = "/Assets/Images/tranquil.png"
                },
              new CoverImage
               {
                   Name = "melody",
                   ImageFile = "/Assets/Images/workout.png"
                },
              new CoverImage
               {
                   Name = "melody",
                   ImageFile = "/Assets/Images/romantic.png"
                },
              new CoverImage
               {
                   Name = "melody",
                   ImageFile = "/Assets/Images/international.png"
                },
              new CoverImage
               {
                   Name = "melody",
                   ImageFile = "/Assets/Images/happy.png"
                }

            };

            Images.ForEach(each => ImageList.Add(each));

        }
    }
}

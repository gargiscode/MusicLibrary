using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    public enum SongArtist
    {
        Taylor,
        Selena,
        Beyonce
    }
/*
    public enum SongAlbum
    {
        Album1,
        Album2,
        Album3
    }
*/
    public class Song
    {
        public string SongTitle { get; set; }
        public SongArtist Artist { get; set; }
        string AudioFile { get; set; }

        public Song(string songTitle) 
        {
            SongTitle = songTitle;
            AudioFile = $"Assets/Audio/{Artist}/{SongTitle}.wav";
        }
        public Song(string songTitle, SongArtist artist)
        {
            SongTitle = songTitle;
            Artist = artist;
            AudioFile = $"Assets/Audio/{Artist}/{SongTitle}.wav";
        }

    }


}

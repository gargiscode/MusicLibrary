using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    public enum MenuHeader
    {
        AllSongs,
        Artists,
        Albums,
        Playlists
    }

    public class EachSongLine
    {
        public string SongTitle { get; set; }
        public string AudioFile { get; set; }
        public bool IsSelected { get; set; }
       
    }
}

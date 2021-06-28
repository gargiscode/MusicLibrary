using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    public class EachPlayList
    {
        public string Name { get; set; }
        public List<EachSongLine> Songs { get; set; }

        //public DateTime dateCreated { get; set; }
    }
}

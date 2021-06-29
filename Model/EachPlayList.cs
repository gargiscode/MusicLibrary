using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    public class EachPlayList
    {
        public string Name { get; set; }
        public ObservableCollection<EachSongLine> Songs { get; set; }
        //public DateTime DateCreated { get; set; }

        public string ImageFile {get; set; }

        public string Description { get; set; }


    }
}

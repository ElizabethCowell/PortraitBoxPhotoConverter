using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortraitBoxPhotoConverter
{
    public interface IPhotoConverter
    {
        public void InvertImage(string photo);
        public string HalfTone(string invertPhoto);
        public string Grouping(string halfTonePhoto);
        public string DownloadImage(string finishedPhoto);
        
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace PortraitBoxPhotoConverter
{
    public interface IPhotoConverter
    {
        public string InvertImage(string uploadedPhoto);
        public string HalfTone(string invertPhoto);
        public string Grouping(string halfTonePhoto);
        public string DownloadImage(string finishedPhoto);
        
    }
}

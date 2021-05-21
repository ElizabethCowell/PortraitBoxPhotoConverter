using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace PortraitBoxPhotoConverter
{
    public interface IPhotoConverter
    {
        public Bitmap InvertImage(string uploadedPhoto);
        public string HalfTone(string invertPhoto);
        public string Grouping(string halfTonePhoto);
        public string DownloadImage(string finishedPhoto);
        
    }
}

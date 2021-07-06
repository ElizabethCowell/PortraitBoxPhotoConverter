using PortraitBoxPhotoConverter.Models;
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
        //public string HalfTone(Bitmap invertPhoto);
        public string DoDithering(Bitmap photo);
        public string Grouping(string halfTonePhoto);
        public bool SaveImage(string ImgStr);


    }
}

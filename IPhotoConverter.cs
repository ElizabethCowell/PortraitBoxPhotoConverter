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
        public string InvertImage(string uploadedPhoto);
        //public string HalfTone(Bitmap invertPhoto);
        public Bitmap DoDithering(Bitmap input);
        public string Grouping(string halfTonePhoto);
        public bool SaveImage(string ImgStr);


    }
}

﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace PortraitBoxPhotoConverter.Models
{
    public class Photo
    {
        public string UploadPhoto { get; set; }
        public int PhotoID { get; set; }
        public string DitherPhoto { get; set; }
        public Bitmap InvertedPhoto { get; set; }
        public string DownLoadPhoto { get; set; }
        public Bitmap GrayScale { get; set; }
    }
}

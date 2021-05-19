using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace PortraitBoxPhotoConverter
{
    public class PhotoConverter : IPhotoConverter
    {
        public string DownloadImage(string finishedPhoto)
        {
            throw new NotImplementedException();
        }

        public string Grouping(string halfTonePhoto)
        {
            throw new NotImplementedException();
        }

        public string HalfTone(string invertPhoto)
        {
            throw new NotImplementedException();
        }

        public void InvertImage(string photo)
        {
            {
                //read image
                Bitmap bmp = new Bitmap(photo);

                //get image dimension
                int width = bmp.Width;
                int height = bmp.Height;

                //negative
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        //get pixel value
                        Color p = bmp.GetPixel(x, y);

                        //extract ARGB value from p
                        int a = p.A;
                        int r = p.R;
                        int g = p.G;
                        int b = p.B;

                        //find negative value
                        r = 255 - r;
                        g = 255 - g;
                        b = 255 - b;

                        //set new ARGB value in pixel
                        bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    }
                }

                //save negative image
                bmp.Save("D:\\Image\\Negative.png");
            }
        }

    }
}

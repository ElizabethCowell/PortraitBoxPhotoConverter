using PortraitBoxPhotoConverter.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        //public Bitmap stringToImage(string inputString)
        //{
        //    byte[] imageBytes = Encoding.Unicode.GetBytes(inputString);
        //    using (MemoryStream ms = new MemoryStream(imageBytes))
        //    {
                
        //        var bmpPhoto = new Bitmap(ms);
        //        return bmpPhoto;
        //    }
        //}
        public Bitmap InvertImage(string uploadedPhoto)
        {
          
            var photo = (Bitmap) Image.FromFile(@$"C:\\Users\\eholy\\repos\\PortraitBoxPhotoConverter\\wwwroot\\{uploadedPhoto}", true);

            //{
            //    Image newPhoto = photo;
            //    ////read image
            //    Bitmap bmp = new Bitmap(newPhoto, 32 , 32);
            //    //Bitmap image;
            //    //using (var ms = new MemoryStream())
            //    //{
            //    //    fileUpload1.PostedFile.InputStream.CopyTo(ms);
            //    //    ms.Position = 0;
            //    //    image = new System.Drawing.Bitmap(ms);
            //}


            //get image dimension
            int width = photo.Width;
                int height = photo.Height;

                //negative
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                    //get pixel value
                    Color p = photo.GetPixel(x, y);

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
                        photo.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
                }

                    
                    //photo.Save("c:\\negative.jpg", ImageFormat.Jpeg);


            return photo;
            
        }

    }
}

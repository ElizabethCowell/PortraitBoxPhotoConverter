﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
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
using System.Web;


namespace PortraitBoxPhotoConverter
{
    public class PhotoConverter : IPhotoConverter
    {

        public string Grouping(string halfTonePhoto)
        {
            throw new NotImplementedException();
        }

        public Bitmap GrayScale(Bitmap photo)

        {
            ////convert image to bitmap
            //var photo = (Bitmap)Image.FromFile(@$"C:\\Users\\eholy\\repos\\PortraitBoxPhotoConverter\\wwwroot\\{uploadedPhoto}", true);
            //get image dimension
            int width = photo.Width;
            int height = photo.Height;

            //cycle through pixels
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

                    //find avg of rgb to grayscale image
                    int avg = (r + g + b) / 3;
                   
                    //set new ARGB value in pixel to create grayscale
                    photo.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            }

            


            return photo;
        }



        public Bitmap InvertImage(string uploadedPhoto)
        {
            //convert image to bitmap
            var photo = (Bitmap) Image.FromFile(@$"C:\\Users\\eholy\\repos\\PortraitBoxPhotoConverter\\wwwroot\\{uploadedPhoto}", true);

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

            //convert bitmap to base64
            //var ms = new MemoryStream();

            //photo.Save(ms, ImageFormat.Jpeg);
            //var invertComplete = Convert.ToBase64String(ms.GetBuffer());


            //return invertComplete;
            return photo;
            
        }

        public bool SaveImage(string ImgStr)
        {
            var path = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")).Root; // create path
            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            string imageName = "negativephoto" + ".jpg";

            //set the image path
            string imgPath = Path.Combine(path, imageName);
            //convert base64 to byte
            byte[] imageBytes = Convert.FromBase64String(ImgStr);
            //save file
            File.WriteAllBytes(imgPath, imageBytes);

            return true;
        }

        public string Halftone(Bitmap photo)
        {
            int width = photo.Width;
            int height = photo.Height;

            //cycle through pixels
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = photo.GetPixel(x, y);

                    //cycle through pixels in 4X4 grid 
                    if (x % 2 == 0 && y % 2 == 0)
                    {
                        if (p.R > 64)
                        {
                            photo.SetPixel(x, y, Color.FromArgb(p.A, 255, 255, 255));
                        }
                        else photo.SetPixel(x, y, Color.FromArgb(p.A, 000, 000, 000));
                    }
                    if (x % 2 == 0 && y % 2 != 0)
                    {
                        if (p.R > 128)
                        {
                            photo.SetPixel(x, y, Color.FromArgb(p.A, 255, 255, 255));
                        }
                        else photo.SetPixel(x, y, Color.FromArgb(p.A, 000, 000, 000));
                    }
                    if (x % 2 != 0 && y % 2 == 0)
                    {
                        if (p.R > 192)
                        {
                            photo.SetPixel(x, y, Color.FromArgb(p.A, 255, 255, 255));
                        }
                        else photo.SetPixel(x, y, Color.FromArgb(p.A, 000, 000, 000));
                    }
                    if (x % 2 != 0 && y % 2 != 0)
                    {
                        if (p.R > 64)
                        {
                            photo.SetPixel(x, y, Color.FromArgb(p.A, 255, 255, 255));
                        }
                        else photo.SetPixel(x, y, Color.FromArgb(p.A, 000, 000, 000));
                    }
                }
            }

                    var ms = new MemoryStream();

            photo.Save(ms, ImageFormat.Jpeg);
            var invertComplete = Convert.ToBase64String(ms.GetBuffer());
            
                return invertComplete;
        }
    }
}

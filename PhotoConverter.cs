using Microsoft.AspNetCore.Http;
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
        public string DownloadImage(string finishedPhoto)
        {
            var dlPhoto = new Photo();
            //Convert Base64 Encoded string to Byte Array.
            //byte[] imageBytes = Convert.FromBase64String(finishedPhoto);
            //Image image;
            //using (MemoryStream ms = new MemoryStream(imageBytes))
            //{
            //    image = Image.FromStream(ms);
            //}
            //image.Save( ImageFormat.Jpeg);

            var fileName = Path.GetFileName(finishedPhoto);

            //Assigning Unique Filename (Guid)
            var myUniqueFileName = Convert.ToString(Guid.NewGuid());

            //Getting file Extension
            var fileExtension = Path.GetExtension(fileName);

            // concatenating  FileName + FileExtension
            var newFileName = String.Concat(myUniqueFileName, fileExtension);

            // Combines two strings into a path.
            var filepath =
            new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")).Root + $@"{newFileName}";
            //using (FileStream fs = System.IO.File.Create(filepath))
            //{
            //    finishedPhoto.CopyTo(fs);
            //    fs.Flush();
            //}
            //string filePath = @$"C:\\Users\\eholy\\repos\\PortraitBoxPhotoConverter\\wwwroot\\" ;
            //File.WriteAllBytes(filePath, imageBytes);

            dlPhoto.PhotoID = 2;
            return dlPhoto.DownLoadPhoto = "/images/" + newFileName;
        }

        public string Grouping(string halfTonePhoto)
        {
            throw new NotImplementedException();
        }

        public string HalfTone(Bitmap invertPhoto)
        {

            throw new NotImplementedException();
        }

        public string InvertImage(string uploadedPhoto)
        {
          
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
                

            var ms = new MemoryStream();

            photo.Save(ms, ImageFormat.Jpeg);
            var invertComplete = Convert.ToBase64String(ms.GetBuffer());
            //photo.Save("c:\\negative.jpg", ImageFormat.Jpeg);





            return invertComplete;
            
        }

        public bool SaveImage(string ImgStr, string ImgName)
        {
            var path = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")).Root; //Path
            //+$@"{ImgName}"
            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            string imageName = ImgName + ".jpg";

            //set the image path
            string imgPath = Path.Combine(path, imageName);

            byte[] imageBytes = Convert.FromBase64String(ImgStr);

            File.WriteAllBytes(imgPath, imageBytes);

            return true;
        }

    }
}

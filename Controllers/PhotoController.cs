using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using MySql.Data.MySqlClient;
using PortraitBoxPhotoConverter.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortraitBoxPhotoConverter.Controllers
{
    public class PhotoController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UploadImage(IFormFile files, Photo photo)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);

                    //Assigning Unique Filename (Guid)
                    //var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                    var myUniqueFileName = "original";

                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);

                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(myUniqueFileName, fileExtension);

                    // Combines two strings into a path.
                    var filepath =
                    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")).Root + $@"{newFileName}";

                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        files.CopyTo(fs);
                        fs.Flush();
                    }

                    photo.PhotoID = 1;
                    photo.UploadPhoto = "/images/" + newFileName;

                }
            }

            var invert = new PhotoConverter();

            //photo.DitherPhoto = invert.DoDithering(photo.UploadPhoto);

            photo.InvertedPhoto = invert.InvertImage(photo.UploadPhoto);

            photo.DitherPhoto = invert.DoDithering(photo.InvertedPhoto);

            invert.SaveImage(photo.DitherPhoto);

            return View(photo);

        }

        

    }
}

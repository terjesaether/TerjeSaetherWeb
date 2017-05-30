﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TerjeSaetherWeb.Models
{
    public class HelperMethods
    {
        public byte[] ConvertToByteArray(Stream inputStream)
        {
            var stream = new MemoryStream();

            inputStream.CopyTo(stream);

            return stream.ToArray();
        }

        // Returnerer om lagringen gikk ok
        public bool SaveUploadedFile(HttpRequest httpRequest, string storagePath, List<string> formattedFilenames)
        {
            storagePath = "~" + storagePath;
            bool isSavedSuccessfully = true;
            string fName = "";
            var counter = 0;
            try
            {
                foreach (string fileName in httpRequest.Files)
                {
                    var file = httpRequest.Files[fileName];

                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        // HttpContext.Current.Server.MapPath genererer absolutt path:

                        var baseDirectory = HttpContext.Current.Server.MapPath(storagePath);

                        string path = Path.Combine(baseDirectory, formattedFilenames[counter]);

                        if (!Directory.Exists(baseDirectory.ToString()))
                            Directory.CreateDirectory(baseDirectory.ToString());

                        file.SaveAs(path);
                    }
                    counter++;
                }
            }
            catch (Exception e)
            {
                var error = e.Message;
                return true;
            }

            if (isSavedSuccessfully)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Returnerer om lagringen gikk ok
        public bool SaveUploadedAudioFile(HttpPostedFile file, string storagePath, string fileName)
        {
            storagePath = "~" + storagePath;
            bool isSavedSuccessfully = true;
            //string fName = "";
            var counter = 0;
            try
            {
                
                    //var file = httpRequest.Files[fileName];

                    //Save file content goes here
                    //fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        // HttpContext.Current.Server.MapPath genererer absolutt path:

                        var baseDirectory = HttpContext.Current.Server.MapPath(storagePath);

                        string path = Path.Combine(baseDirectory, fileName);

                        if (!Directory.Exists(baseDirectory.ToString()))
                            Directory.CreateDirectory(baseDirectory.ToString());

                        file.SaveAs(path);
                    }
                    counter++;
                
            }
            catch (Exception e)
            {
                var error = e.Message;
                return true;
            }

            if (isSavedSuccessfully)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


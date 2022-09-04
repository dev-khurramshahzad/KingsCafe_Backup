//using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KingsCafe.Utills
{
    public class UploadCloud
    {
        public static async Task<string> firebaseUpload(HttpPostedFileBase pic)
        {
            //var stroageImage = await new FirebaseStorage("kingscafeapp.appspot.com")
            //    .Child("webpics")
            //    .Child(Guid.NewGuid().ToString()+ pic.FileName)
            //    .PutAsync(pic.InputStream);
            //string imgurl = stroageImage;
            //return imgurl;
            return "OK";
        }
    }
}
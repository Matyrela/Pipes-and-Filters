using System;
using System.IO;

namespace CompAndDel.Filters
{
    public class FilterSaveToDisk : IFilter
    {
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            DateTime dateTime = DateTime.UtcNow.Date;



            string path = ("../Program/Steps/");
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            date = date.Replace(":", "-");
            string file = (date + ".jpg");

            string completo = path + file;

            if (File.Exists(completo))
            {
                completo = path + date + "(1)" + ".jpg";
            }

            provider.SavePicture(image, completo);

            return image;
        }
    }
}

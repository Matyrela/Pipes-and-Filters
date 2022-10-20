using System;
using System.IO;
using TwitterUCU;


namespace CompAndDel.Filters
{
    public class FilterUploadToTwitter : IFilter
    {
        public IPicture Filter(IPicture image)
        {
            TwitterImage twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Luke", @"Terminada.jpg"));

            return null;
        }
    }
}

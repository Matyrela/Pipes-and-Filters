using System.Drawing;
using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IFilter GrayScale = new FilterGreyscale();
            IFilter Negative = new FilterNegative();
            IFilter Blur = new FilterBlurConvolution();
            IFilter saveFilter = new SaveFilter();

            //Cargo la imagen
            IPicture picture = provider.GetPicture(@"beer.jpg");
            IPipe step7 = new PipeNull();

            //Aplico filtro Negative y salvo
            IPipe step6 = new PipeSerial(saveFilter, step7);
            IPipe step5 = new PipeSerial(Negative, step6);

            //Aplico filtro Gray y salvo
            IPipe step4 = new PipeSerial(saveFilter, step5);
            IPipe step3 = new PipeSerial(GrayScale, step4);


            IPicture coso = step3.Send(picture);










            //Salvo la imagen
            provider.SavePicture(coso, @"new.jpg");

            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Peñarol > Nacional", @"new.png"));

        }
    }
}

using System.Diagnostics;
using System.Drawing;
using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

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
            IFilter save = new FilterSaveToDisk();
            IFilter twitter = new FilterUploadToTwitter();

            //Cargo la imagen
            IPicture picture = provider.GetPicture(@"luke.jpg");
            IPipe End = new PipeNull();

            

            //Aplico filtro Negative y salvo
            IPipe step6 = new PipeSerial(save, End);
            IPipe step5 = new PipeSerial(Negative, step6);

            //Aplico filtro Gray y salvo
            IPipe step4 = new PipeSerial(save, step5);
            IPipe step3 = new PipeSerial(GrayScale, step4);


            IPicture coso = step3.Send(picture);


            //Salvo la imagen
            provider.SavePicture(coso, @"Filtrada.jpg");

            IPicture FacePict = provider.GetPicture(@"Filtrada.jpg");
            IPipe faceCheck = new PipeBool(save, End);

            IPicture hasFace = faceCheck.Send(FacePict);

            if(hasFace == null){
                return;
            }

            
            
            IPipe upload = new PipeSerial(twitter, End);

            IPicture toUpload = upload.Send(hasFace);


        }
    }
}

using System.Diagnostics;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CognitiveCoreUCU;
using System.IO;

namespace CompAndDel.Pipes
{
    public class PipeBool : IPipe
    {
        protected IFilter filtro;
        protected IPipe nextPipe;
        
        
        public PipeBool(IFilter filtro, IPipe nextPipe)
        {
            this.nextPipe = nextPipe;
            this.filtro = filtro;
        }

        public IPipe Next
        {
            get { return this.nextPipe; }
        }

        public IFilter Filter
        {
            get { return this.filtro; }
        }

        public IPicture Send(IPicture picture)
        {
            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(picture, @"aCheckear.jpg");


            cog.Recognize(@"aCheckear.jpg");

            if(cog.FaceFound){
                Console.WriteLine("Face Found");
                File.Delete(@"aCheckear.jpg"); 
                return this.nextPipe.Send(picture);
                
            }else{
                File.Delete(@"aCheckear.jpg"); 
                Console.WriteLine("Face not Found");
                return null;

            }


            
        }

    }
}

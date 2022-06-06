using System;
using CompAndDel;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 1
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            IPipe pipe = new PipeNull();
            IFilter filter = new FilterNegative();
            IPipe pipe2 = new PipeSerial(filter, pipe);
            IFilter filter2 = new FilterGreyscale();
            IPipe pipe3 = new PipeSerial(filter2, pipe2);
            picture = pipe3.Send(picture);
            provider.SavePicture(picture, @"fotos.jpg");

            // Ejercicio 2
            // Esta la creacion de FilterSavePicture que usa siempre todos los pipe serial para ir guardando la imagen.

            // Ejercicio 3
            // Esta la creacion de FilterTwitter que lo usa todos los pipe serial para ir publicando.

            // Ejercicio 4
            PictureProvider provider2 = new PictureProvider();
            IPicture picture2 = provider2.GetPicture(@"luke.jpg");


            IFilter greyFilter = new FilterGreyscale();
            IFilter negativeFilter = new FilterNegative();
            IFilter twitterFilter = new FilterTwitter();

            
            PipeNull pipe_3 = new PipeNull();
            PipeSerial pipe_2 = new PipeSerial(negativeFilter, pipe_3);
            PipeSerial pipe_1 = new PipeSerial(twitterFilter, pipe_3);
            FilterFaceRecognition conditionalFilter = new FilterFaceRecognition();
            PipeConditional pipeFork = new PipeConditional(pipe_1, pipe_2, conditionalFilter);
            PipeSerial pipe_0 = new PipeSerial(greyFilter, null);
            pipe_0.AddConditionalPipe(pipeFork);
            pipe_0.Send(picture2);
        }
    }
}

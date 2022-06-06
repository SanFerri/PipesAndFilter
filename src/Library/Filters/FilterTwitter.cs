using TwitterUCU;
using System;
using CompAndDel.Pipes;

namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter
    {
        protected int counter = 0;

        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            if (this.counter == 0)
            {
                Console.WriteLine(twitter.PublishToTwitter("Imagen previa al filtro", @"luke.jpg"));
            }
            Console.WriteLine(twitter.PublishToTwitter($"Imagen del filtro N°{this.counter + 1}", @$"C:\Users\sanbr\OneDrive\Escritorio\Programacion II (Recurso)\PipesAndFilter\src\Program\sequence{counter}.jpg"));
            this.counter += 1;
            return image;
        }
    }
}
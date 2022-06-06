using System;
using CompAndDel;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class FilterSavePicture : IFilter
    {
        protected int counter { get; set; } = 0;
        public static string lastPath { get; set; }

        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            FilterSavePicture.lastPath = @$"C:\Users\sanbr\OneDrive\Escritorio\Programacion II (Recurso)\PipesAndFilter\src\Program\sequence{counter}.jpg";
            provider.SavePicture(image, @$"C:\Users\sanbr\OneDrive\Escritorio\Programacion II (Recurso)\PipesAndFilter\src\Program\sequence{counter}.jpg");
            counter += 1;

            return image;
        }
    }
}
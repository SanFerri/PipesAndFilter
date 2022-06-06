using TwitterUCU;
using System;
using CognitiveCoreUCU;
using CompAndDel.Pipes;

namespace CompAndDel.Filters
{
    public class FilterFaceRecognition : IFilter
    {
        protected int counter = 0;
        public bool lastSmile;

        public IPicture Filter(IPicture image)
        {   
            CognitiveFace cog = new CognitiveFace(true);
            FilterSavePicture filter = new FilterSavePicture();
            string path = FilterSavePicture.lastPath;
            cog.Recognize(@$"{path}");
            this.lastSmile = FoundFace(cog);
            return image;
        }

        private static bool FoundFace(CognitiveFace cog)
            {
                if (cog.FaceFound)
                {
                    Console.WriteLine("Face Found!");
                    if (cog.SmileFound)
                    {
                        Console.WriteLine("Found a Smile :)");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("No smile found :(");
                        return false;
                    }
                }
                else
                    Console.WriteLine("No Face Found");
                    return false;
            }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;


namespace CompAndDel.Pipes
{
    public class PipeConditional : IPipe
    {
        IPipe next2Pipe;
        IPipe nextPipe;
        FilterFaceRecognition faceRecognition;
        
        public PipeConditional(IPipe nextPipe, IPipe next2Pipe, FilterFaceRecognition filterConditional) 
        {
            this.next2Pipe = next2Pipe;
            this.nextPipe = nextPipe; 
            this.faceRecognition = filterConditional;          
        }

        public IPicture Send(IPicture picture)
        {
            this.faceRecognition.Filter(picture);
            if(this.faceRecognition.lastSmile == true)
            {
                return this.nextPipe.Send(picture);
            }
            else
            {
                return this.next2Pipe.Send(picture);         
            }
        }
    }
}

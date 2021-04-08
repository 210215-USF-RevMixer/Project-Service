using System;
using System.Collections.Generic;
namespace ProjectModels
{
    public class SamplePlaylist
    {
        private int sampleId;
        private int sampleSetId;
        public int Id { get; set; }
        public int SampleId { 
            get { return sampleId; } 
            set
            {
                if (value.GetType() != typeof(int))
                {
                    throw new ArgumentException("value");
                }
                sampleId = value;
            } 
        }
        public int SampleSetId { 
            get { return sampleSetId; } 
            set
            {
                if (value.GetType() != typeof(int))
                {
                    throw new ArgumentException("value");
                }
                sampleSetId = value;
            } 
        }
    }
}
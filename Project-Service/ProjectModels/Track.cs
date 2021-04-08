using System;
using System.Collections.Generic;
namespace ProjectModels
{
    public class Track
    {
        private int projectId;
        private SavedProject savedProject;
        private Sample sample;
        private Pattern pattern;
        private int sampleId;
        private int patternId;
        public int Id { get; set; }
        public int ProjectId { 
            get { return projectId; } 
            set
            {
                if (value.GetType() != typeof(int))
                {
                    throw new ArgumentException("value");
                }
                projectId = value;
            } 
        }

        public SavedProject SavedProject { get; set; }

        public Sample Sample { get; set; }

        public Pattern Pattern { get; set; }

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
        public int PatternId { 
            get { return patternId; } 
            set
            {
                if (value.GetType() != typeof(int))
                {
                    throw new ArgumentException("value");
                }
                patternId = value;
            } 
        }
    }
}
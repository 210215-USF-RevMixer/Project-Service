using System;
using System.Collections.Generic;
namespace ProjectModels
{
    public class SavedProject
    {
        private string projectName;
        private int bPM;
        private int sampleIds;
        private string pattern;

        public int Id { get; set; }
        public string ProjectName { 
            get { return projectName; }
            set
            {
                if (value == null || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                projectName = value;
            } 
        }
        public int BPM {
            get { return bPM; } 
            set
            {
                if (value.GetType() != typeof(int))
                {
                    throw new ArgumentException("value");
                }
                bPM = value;
            } 
        }

        public int SampleIds { get; set; }
        public string Pattern { get; set; }
    }
}
using System;
using System.Collections.Generic;
namespace ProjectModels
{
    public class SavedProject
    {
        private string projectName;
        private string bPM;
        private string sampleIds;
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
        public string BPM {
            get { return bPM; } 
            set
            {
                if (value.GetType() != typeof(string))
                {
                    throw new ArgumentException("value");
                }
                bPM = value;
            } 
        }

        public string SampleIds { get; set; }
        public string Pattern { get; set; }
    }
}
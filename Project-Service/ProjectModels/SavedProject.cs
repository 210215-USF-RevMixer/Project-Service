using System;
using System.Collections.Generic;
namespace ProjectModels
{
    public class SavedProject
    {
        private string projectName;
        private int bPM;
        ICollection<UserProject> userProjects;
        ICollection<Track> tracks;

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

        public ICollection<UserProject> UserProjects { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
using System;
using System.Collections.Generic;
namespace ProjectModels
{
    public class Sample
    {
        private string sampleName;
        private string sampleLink;
        private ICollection<Track> track;
        private bool isPrivate;
        private bool isApproved;
        private bool isLocked;
        
        public int Id { get; set; }

        public string SampleName { 
            get { return sampleName; }
            set
            {
                if (value == null || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                sampleName = value;
            } 
        }
        public string SampleLink { 
            get { return sampleLink; }
            set
            {
                if (value == null || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                sampleLink = value;
            } 
        }
        public ICollection<Track> Track { get; set; }
        public bool IsPrivate { 
            get { return isPrivate; }
            set
            {
                if (value.GetType() != typeof(bool))
                {
                    throw new ArgumentException("value");
                }
                isPrivate = value;
            }
        }
        public bool IsApproved { 
            get { return isApproved; }
            set
            {
                if (value.GetType() != typeof(bool))
                {
                    throw new ArgumentException("value");
                }
                isApproved = value;
            }
        }
        public bool IsLocked { 
            get { return isLocked; }
            set
            {
                if (value.GetType() != typeof(bool))
                {
                    throw new ArgumentException("value");
                }
                isLocked = value;
            }
        }
    }
}
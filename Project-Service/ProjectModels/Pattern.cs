using System;
using System.Collections.Generic;
namespace ProjectModels
{
    public class Pattern
    {
        private string patternData;
        private ICollection<Track> tracks;
        public int Id { get; set; }
        public string PatternData { 
            get { return patternData; }
            set
            {
                if (value == null || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                patternData = value;
            } 
        }

        public ICollection<Track> Tracks { get; set; }
    }
}
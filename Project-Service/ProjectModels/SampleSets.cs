using System;
using System.Collections.Generic;
namespace ProjectModels
{
    public class SampleSets
    {
        private string name;
        public int Id { get; set; }
        public string Name { 
            get { return name; }
            set
            {
                if (value == null || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                name = value;
            } 
        }
    }
}
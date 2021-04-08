using System;
using System.Collections.Generic;
namespace ProjectModels
{
    public class UserProject
    {
        private int userId;
        private int projectId;
        private bool owner;
        private SavedProject savedProject;

        public int Id { get; set; }
        public int UserId { 
            get { return userId; } 
            set
            {
                if (value.GetType() != typeof(int))
                {
                    throw new ArgumentException("value");
                }
                userId = value;
            }  
        }
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
        public bool Owner { 
            get { return owner; }
            set
            {
                if (value.GetType() != typeof(bool))
                {
                    throw new ArgumentException("value");
                }
                owner = value;
            }
        }

        public SavedProject SavedProject { get; set; }
    }
}
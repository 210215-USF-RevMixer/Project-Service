using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModels
{
    public class UsersSample
    {
        private int userId;
        private int sampleId;
        private bool isOwner;
        public int Id { get; set; }
        public int UserId { get { return userId; } set { userId = value; } }
        public int SampleId { get { return sampleId; } set { sampleId = value; } }
        public bool IsOwner { get { return isOwner; } set { isOwner = value; } }
        
    }
}

namespace ProjectModels
{
    public class UsersSampleSets
    {
        private int userId;
        private int sampleId;
        private bool isOwner;
        public int Id { get; set; }
        public int UserId { get { return userId; } set { userId = value; } }
        public int SampleSetsId { get { return sampleId; } set { sampleId = value; } }
        public bool IsOwner { get{ return isOwner; } set { isOwner = value; } }
    }
}
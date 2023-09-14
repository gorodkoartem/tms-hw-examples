namespace EventsHW
{
    internal class Post
    {
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public User CreatedBy { get; set; }
    }
}

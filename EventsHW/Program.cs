namespace EventsHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User("User1", 10, 10);
            var user2 = new User("User2", 10, 10);
            var user3 = new User("User3", 10, 10);
            var user4 = new User("User4", 10, 10);
            var user5 = new User("User5", 10, 10);
            var user6 = new User("User6", 10, 10);
            var user7 = new User("User7", 10, 10);
            var user8 = new User("User8", 10, 10);
            var user9 = new User("User9", 10, 10);
            var user10 = new User("User10", 10, 10);

            user1.NewPostAdded += user2.OnNewPostAdded;
            user1.NewPostAdded += user3.OnNewPostAdded;
            user1.NewPostAdded += user4.OnNewPostAdded;

            user2.NewPostAdded += user1.OnNewPostAdded;
            user2.NewPostAdded += user3.OnNewPostAdded;
            user2.NewPostAdded += user4.OnNewPostAdded;
            user2.NewPostAdded += user5.OnNewPostAdded;

            user3.NewPostAdded += user6.OnNewPostAdded;
            user3.NewPostAdded += user7.OnNewPostAdded;
            user3.NewPostAdded += user8.OnNewPostAdded;
            user3.NewPostAdded += user9.OnNewPostAdded;
            user3.NewPostAdded += user10.OnNewPostAdded;

            //...

            user1.AddPost(new Post
            {
                CreatedAt = DateTime.Now,
                CreatedBy = user1,
                Description = "Life is good"
            });
            user1.AddPost(new Post
            {
                CreatedAt = DateTime.Now,
                CreatedBy = user1,
                Description = "Life is good!!!!"
            });
            user1.AddPost(new Post
            {
                CreatedAt = DateTime.Now,
                CreatedBy = user1,
                Description = "Life is good!!!!!!!!"
            });
        }
    }
}
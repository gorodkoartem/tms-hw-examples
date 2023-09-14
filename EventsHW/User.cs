namespace EventsHW
{
    internal class User
    {
        private int _myPostsLastIndexUsed;
        private int _postsToSeeLastIndexUsed;

        private readonly Post[] _myPosts;
        private readonly Post[] _postsToSee;

        public event Action<Post> NewPostAdded;

        public string Name { get; }

        public User(string name, int selfPostsLimit, int postsToSeeLimit)
        {
            Name = name;

            _myPosts = new Post[selfPostsLimit];
            _postsToSee = new Post[postsToSeeLimit];
        }

        public void AddPost(Post post)
        {
            if (_myPostsLastIndexUsed >= _myPosts.Length)
            {
                return;
            }

            _myPosts[_myPostsLastIndexUsed++] = post;
            NewPostAdded?.Invoke(post);
        }

        public void OnNewPostAdded(Post post)
        {
            if (_postsToSeeLastIndexUsed >= _postsToSee.Length)
            {
                return;
            }

            _postsToSee[_postsToSeeLastIndexUsed++] = post;
        }
    }
}

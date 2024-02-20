using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift
{
    internal class Diary
    {
        private string title;
        private string owner;
        private DateTime date;
        private List<Post> posts;

        public Diary() 
        {
            this.title = "";
            this.owner = "";
            this.date = DateTime.Now.Date;
            this.posts = new List<Post>();
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine();
                Typewriter.TypewriterEffect("Illegalt titelargument. Ange en giltig titel: ", false);
                SetTitle(Console.ReadLine());
            }
            if (!title.Any(Char.IsLetter) && !title.Any(Char.IsNumber))
            {
                Console.WriteLine();
                Typewriter.TypewriterEffect("Illegalt titelargument. Ange en giltig titel: ", false);
                SetTitle(Console.ReadLine());
            }
            this.title = title;
        }
        
        public void SetOwner(string owner)
        {
            this.owner = owner;
        }

        public string GetTitle()
        {
            if(this.title is null)
            {
                throw new Exception("Titel is null");
            }
            return this.title;
        }
        public string GetOwner()
        {
            if(this.owner is null)
            {
                throw new Exception("Owner is null");
            }
            return this.owner;
        }
        public Post GetPost(string title)
        {
            foreach (Post post in posts)
            {
                if (post.GetTitle() == title)
                {
                    post.UpdateDate();
                    return post;
                }
            }
            Typewriter.TypewriterEffect($"\nKunde inte hitta inlägg med namnet: {title}");
            Console.WriteLine();
            return null;
        }
        public DateTime GetDate()
        {
            return this.date;
        }
        public List<Post> GetPosts()
        {
            return this.posts;
        }
        public void PrintPosts()
        {
            foreach (Post p in this.posts)
            {
                Typewriter.TypewriterEffect(p.GetTitle());
            }
        }

        public void CreatePost(User user)
        {
            Post post = new Post();
            post.SetOwner(user.GetUsername());
            Typewriter.TypewriterEffect("Ange en titel på inlägget: ", false);
            string titel = Console.ReadLine();
            post.SetTitle(titel);
            Console.WriteLine(); // Ser till att det blir ett \n
            post.SetText("");
            AddPost(post);
            Typewriter.TypewriterEffect($"Inlägg med titeln \"{titel}\" skapat!");
        }

        public void RemovePost(string post)
        {

            // Create a copy of the diaryList to iterate over
            List<Post> postsToRemove = new List<Post>(this.posts);

            // Iterate over the copy and remove matching diaries from the original list
            foreach (Post p in postsToRemove)
            {
                if (p.GetTitle() == post)
                {
                    this.posts.Remove(p);
                }
            }
        }

        public void AddPost(Post post)
        {
            this.posts.Add(post);
        }

        public void UpdateDate()
        {
            this.date = DateTime.Today;
        }
    }
}

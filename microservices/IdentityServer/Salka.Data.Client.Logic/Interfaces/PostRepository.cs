using Microsoft.EntityFrameworkCore;
using Salka.Data.Clients.Model.Data;
using Salka.Data.Clients.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Logic.Interfaces
{
    public class PostRepository : IPostRepository
    {
        public async Task<Post> GetPostByPostIdAsync(int postId)
        {
            using (var salkadb = new salkadbclientContext())
            {
                var post = await salkadb.Posts.Where(p => p.Id == postId).SingleAsync();
                return post;
            }
        }

        public async Task<Post> InsertNewPost(Post post)
        {
            using(var salkadb = new salkadbclientContext())
            {
                var postCount = salkadb.Posts.Where(p => p.PostalCode == post.PostalCode).Count();
                if (postCount == 0)
                {
                    await salkadb.Posts.AddAsync(post);
                    await salkadb.SaveChangesAsync();
                    return post;
                }
                return await salkadb.Posts.Where(p => p.PostalCode == post.PostalCode).SingleAsync();
            }
        }
    }
}

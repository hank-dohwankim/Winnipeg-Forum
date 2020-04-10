using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WinnipegForum.Data;
using WinnipegForum.Data.Models;

namespace WinnipegForum.Service
{
    public class PostService : IPost
    {
        public Task Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task AddPostReply(PostReply postReply)
        {
            throw new NotImplementedException();
        }

        public Task AddReplyReply(ReplyReply replyReply)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}

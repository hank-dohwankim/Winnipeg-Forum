﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WinnipegForum.Data.Models;

namespace WinnipegForum.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery);
        IEnumerable<Post> GetPostsByForum(int id);
        IEnumerable<Post> GetLatestPosts(int n);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id, string newContent);
        Task AddPostReply(PostReply postReply);
        Task AddReplyReply(ReplyReply replyReply);
    }
}

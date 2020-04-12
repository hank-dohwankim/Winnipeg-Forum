using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinnipegForum.Data;
using WinnipegForum.Data.Models;

namespace WinnipegForum.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _dbContext;
        public PostService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Post post)
        {
            _dbContext.Add(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddPostReply(PostReply postReply)
        {
            _dbContext.PostReplies.Add(postReply);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddReplyReply(ReplyReply replyReply)
        {
            _dbContext.ReplyReplies.Add(replyReply);
            await _dbContext.SaveChangesAsync();
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
            return _dbContext.Posts
                .Include(post => post.User)
                .Include(post => post.PostReplies).ThenInclude(reply => reply.User)
                .Include(post => post.ReplyReplies).ThenInclude(reply => reply.User)
                .Include(post => post.Forum);
        }

        public Post GetById(int id)
        {
            return _dbContext.Posts.Where(post => post.Id == id)
                .Include(post => post.User)
                .Include(post => post.PostReplies).ThenInclude(reply => reply.User)
                .Include(post => post.ReplyReplies).ThenInclude(reply => reply.User)
                .Include(post => post.Forum)
                .First();
        }

        public IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery)
        {
            return string.IsNullOrEmpty(searchQuery) ? forum.Posts :  
                forum.Posts.Where(post => post.Title.Contains(searchQuery) || post.Content.Contains(searchQuery));
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            return GetAll().Where(post => post.Title.Contains(searchQuery) || post.Content.Contains(searchQuery));
        }

        public IEnumerable<Post> GetLatestPosts(int n)
        {
            return GetAll().OrderByDescending(post => post.Created).Take(n);
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            return _dbContext.Forums
                .Where(forum => forum.Id == id).First()
                .Posts;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinnipegForum.Data;
using WinnipegForum.Data.Models;

namespace WinnipegForum.Service
{
    public class ForumService : IForum
    {
        private readonly ApplicationDbContext _dbContext;
        public ForumService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Forum forum)
        {
            _dbContext.Add(forum);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int forumId)
        {
            var forum = GetById(forumId);
            _dbContext.Remove(forum);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _dbContext.Forums.Include(forum => forum.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers(int id)
        {
            var posts = GetById(id).Posts;
            if(posts != null || !posts.Any())
            {
                var postUsers = posts.Select(p => p.User);
                var replyUsers = posts.SelectMany(p => p.PostReplies).Select(r => r.User);
                return postUsers.Union(replyUsers).Distinct();
            }

            return new List<ApplicationUser>();
        }

        public Forum GetById(int id)
        {
            var forum = _dbContext.Forums.Where(forum => forum.Id == id)
                .Include(f => f.Posts).ThenInclude(p => p.User)
                .Include(f => f.Posts).ThenInclude(p => p.PostReplies).ThenInclude(r => r.User)
                .Include(f => f.Posts).ThenInclude(p => p.ReplyReplies).ThenInclude(r => r.User)
                .FirstOrDefault();

            return forum;
        }

        public bool hasRecentPost(int id)
        {
            const int hoursAgo = 12;
            var window = DateTime.Now.AddHours(-hoursAgo);
            return GetById(id).Posts.Any(post => post.Created > window);
        }

        public Task UpdateForumDescription(int forumId, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int forumId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}

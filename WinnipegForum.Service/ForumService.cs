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

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _dbContext.Forums.Include(forum => forum.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Forum GetById(int id)
        {
            var forum = _dbContext.Forums.Where(forum => forum.Id == id)
                .Include(f => f.Posts).ThenInclude(p => p.User)
                .Include(f => f.Posts).ThenInclude(p =>p.PostReplies).ThenInclude(r => r.User)
                .Include(f => f.Posts).ThenInclude(p =>p.ReplyReplies).ThenInclude(r => r.User)
                .FirstOrDefault();

            return forum;
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

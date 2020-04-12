using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinnipegForum.Data;
using WinnipegForum.Data.Models;

namespace WinnipegForum.Service
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationUserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(ApplicationUser user)
        {
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Deactivate(ApplicationUser user)
        {
            user.IsActive = false;
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public ApplicationUser GetByName(string name)
        {
            return _dbContext.ApplicationUsers.FirstOrDefault(user => user.UserName == name);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _dbContext.ApplicationUsers;
        }

        public ApplicationUser GetById(string id)
        {
            return _dbContext.ApplicationUsers.FirstOrDefault(user => user.Id == id);
        }

        public async Task IncrementRating(string id)
        {
            var user = GetById(id);
            user.Rating += 1;
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SetProfileImage(string id, Uri uri)
        {
            var user = GetById(id);
            user.ProfileImageUrl = uri.AbsoluteUri;
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task BumpRating(string userId, Type type)
        {
            var user = GetById(userId);
            var increment = GetIncrement(type);
            user.Rating += increment;
            await _dbContext.SaveChangesAsync();
        }

        private static int GetIncrement(Type type)
        {
            var bump = 0;

            if (type == typeof(Post))
            {
                bump = 3;
            }

            if (type == typeof(PostReply))
            {
                bump = 2;
            }

            return bump;
        }
    }
}
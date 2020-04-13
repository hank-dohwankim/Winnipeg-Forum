﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WinnipegForum.Data.Models;

namespace WinnipegForum.Data
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers(int id);

        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newTitle);
        Task UpdateForumDescription(int forumId, string newDescription);
        bool hasRecentPost(int id);
    }
}

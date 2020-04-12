﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WinnipegForum.Data.Models;

namespace WinnipegForum.Data
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAll();

        Task UpdateUserRating(string id, Type type);
        Task Add(ApplicationUser user);
        Task Deactivate(ApplicationUser user);
        Task SetProfileImage(string id, Uri uri);
        //Task BumpRating(string userId, Type type);
    }
}

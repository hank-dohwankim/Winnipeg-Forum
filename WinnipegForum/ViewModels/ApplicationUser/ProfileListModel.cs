using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace WinnipegForum.ViewModels.ApplicationUser
{
    public class ProfileListModel
    {
        public IEnumerable<ProfileModel> Profiles { get; set; }
    }
}

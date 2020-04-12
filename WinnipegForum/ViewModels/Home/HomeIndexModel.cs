using System.Collections.Generic;
using WinnipegForum.Models.Post;

namespace WinnipegForum.ViewModels.Home
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<PostListingModel> LatestPosts { get; set; }
    }
}

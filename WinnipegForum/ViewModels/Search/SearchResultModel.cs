using System.Collections.Generic;
using WinnipegForum.Models.Post;

namespace WinnipegForum.ViewModels.Search
{
    public class SearchResultModel
    {
        public IEnumerable<PostListingModel> Posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchResults { get; set; }
    }
}

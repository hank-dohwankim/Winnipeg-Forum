using Microsoft.AspNetCore.Http;

namespace WinnipegForum.ViewModels.Forum
{
    public class AddForumModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImangeUrl { get; set; }
        public IFormFile ImageUpload { get; set; }
    }
}

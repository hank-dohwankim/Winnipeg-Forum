using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WinnipegForum.Data;
using WinnipegForum.Data.Models;
using WinnipegForum.ViewModels.Reply;

namespace WinnipegForum.Controllers
{
    [Authorize]
    public class ReplyController : Controller
    {
        private readonly IPost _postService;
        private readonly IApplicationUser _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReplyController(IPost postService, IApplicationUser userService, UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Create(int id)
        {
            var post = _postService.GetById(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new PostReplyModel()
            {
                PostContent = post.Content,
                PostTitle = post.Title,
                PostId = post.Id,
                
                AuthorId = user.Id,
                AuthorName = User.Identity.Name,
                AuthorImageUrl = user.ProfileImageUrl,
                AuthorRating = user.Rating,
                IsAuthorAdmin = User.IsInRole("Admin"),

                ForumName = post.Forum.Title,
                ForumId = post.Forum.Id,
                ForumImageUrl = post.Forum.ImageUrl,

                Created = DateTime.Now,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(PostReplyModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var reply = BuildReply(model, user);

            await _postService.AddPostReply(reply);
            await _userService.UpdateUserRating(userId, typeof(PostReply));

            return RedirectToAction("Index", "Post", new { id = model.PostId });
        }

        private PostReply BuildReply(PostReplyModel model, ApplicationUser user)
        {
            var post = _postService.GetById(model.PostId);
            return new PostReply
            {
                Post = post,
                Content = model.ReplyContent,
                Created = DateTime.Now,
                User = user
            };
        }
    }
}
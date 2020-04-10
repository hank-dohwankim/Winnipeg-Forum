using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinnipegForum.Data;
using WinnipegForum.Data.Models;
using WinnipegForum.Models.Post;
using WinnipegForum.Models.Post.Reply;

namespace WinnipegForum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postservice;
        public PostController(IPost postService)
        {
            _postservice = postService;
        }

        public IActionResult Index(int id)
        {
            var post = _postservice.GetById(id);
            var postReplies = BuildPostReplies(post.PostReplies);
            var replyReplies = BuildReplyReplies(post.ReplyReplies);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AuthorRating = post.User.Rating,
                PostContent = post.Content,
                PostReplies = postReplies,
                ReplyReplies = replyReplies
            };

            return View(model);
        }

        private IEnumerable<ReplyReplyModel> BuildReplyReplies(IEnumerable<ReplyReply> replyReplies)
        {
            return replyReplies.Select(reply => new ReplyReplyModel
            {
                Id = reply.Id,
                AuthorId = reply.User.Id,
                AuthorName = reply.User.UserName,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                AuthorRating = reply.User.Rating,
                Created = reply.Created,
                ReplyContent = reply.Content
            });
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> postReplies)
        {
            return postReplies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorId = reply.User.Id,
                AuthorName = reply.User.UserName,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                AuthorRating = reply.User.Rating,
                Created = reply.Created,
                ReplyContent = reply.Content
            });
        }
    }
}
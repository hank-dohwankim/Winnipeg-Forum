using System;
using System.Collections.Generic;
using System.Text;

namespace WinnipegForum.Data.Models
{
    public class ReplyReply : PostReply
    {
        public PostReply PostReply { get; set; }
    }
}

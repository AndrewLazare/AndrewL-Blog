using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndrewL_Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostBlogId { get; set; }
        public string AuthorId { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }  

        [AllowHtml]
        public string CommentBody { get; set; }
        public DateTime? Updated { get; set; } 
        public string UpdateReason { get; set; }
      
        //Virtual navigation section...give the ability to the koreign key to ask questions about there parent
        public virtual BlogPost PostBlog { get; set; }   
        public virtual ApplicationUser Author { get; set; }

        
            
        
   
    }
}
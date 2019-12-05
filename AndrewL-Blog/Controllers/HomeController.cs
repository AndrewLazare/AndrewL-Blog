using AndrewL_Blog.Helpers;
using AndrewL_Blog.Models;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AndrewL_Blog.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();  //Giving me access to the database
        
        public ActionResult Index(int? page, string searchStr) //Index action.  this runs when /Home/Index

        {
            //var blogPost = db.Posts.OrderByDescending(x => x.Created).Take(4).ToPagedList();  //taking post from data base ordering by desc=ending order and taking the first 4 and returning that as a list.
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);

            //return View(blogPost);   //this is sending whatever variable to my HomeIndexView....this is chaging it to the model in the view page
            ViewBag.Search = searchStr;
            var blogList = IndexSearch(searchStr);  //this is the post.  its going into the database

            int pageSize = 4; //number of posts you want to display per page
            int pageNumber = (page ?? 1);

            return View(blogList.ToPagedList(pageNumber, pageSize)); //its returning the BLogPost view and allowing you to see it

        }
        public IQueryable<BlogPost> IndexSearch(string searchStr)
        {
            IQueryable<BlogPost> result = null;
            if (searchStr != null)
            {
                result = db.Posts.AsQueryable();
                result = result.Where(p => p.Title.Contains(searchStr) ||
                                      p.BlogPostBody.Contains(searchStr) ||
                                      p.Comments.Any(c => c.Body.Contains(searchStr) ||
                                                          c.Author.FirstName.Contains(searchStr) ||
                                                          c.Author.LastName.Contains(searchStr) ||
                                                          c.Author.DisplayName.Contains(searchStr) ||
                                                          c.Author.Email.Contains(searchStr)));
            }
            else
            {
                result = db.Posts.AsQueryable();
            }

            return result.OrderByDescending(p => p.Created);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            EmailModel model = new EmailModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await EmailHelper.ComposeEmailAsync(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0); 
                }
            }
            return View(model);
        }
    }
}
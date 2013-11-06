using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;
using MVCEmpty.Models;

namespace MVCEmpty.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            // opgepast!! elke keer ene gebruiker inlogd wordt hij opgeslagen in db
			Session["accessToken"] = f["accessToken"];

			var accessToken = Session["AccessToken"].ToString();
			var client = new FacebookClient(accessToken);
			dynamic result = client.Get("me", new { fields = "name,id" });

			VideoModel video = new VideoModel();
			User u = new User();
			u.name = result.name;
			u.facebookId = result.id;

			Session["userId"] = video.insertUser(u);
			Session["name"] = u.name;

            ViewBag.status = "loggedIn";
            return View();
        }

        public ActionResult SubmitVideo()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult SubmitVideo(FormCollection f)
        {
            string url = f["url"];

            VideoModel video = new VideoModel();
            Video v = new Video();
            v.url = url;
            v.fk_userId = (int)Session["userId"];
            
            video.insertVideo(v);
           
            ViewBag.status = "video added";
            return View();
        }

    }
}

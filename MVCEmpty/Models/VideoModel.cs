using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEmpty.Models
{
    public class VideoModel
    {
        private FacebookLoginDataContext dc = new FacebookLoginDataContext();

        public int insertUser(User u)
        {
            dc.Users.InsertOnSubmit(u);
            dc.SubmitChanges();

            return u.Id;
        }

        public void insertVideo(Video v)
        {
            dc.Videos.InsertOnSubmit(v);
            dc.SubmitChanges();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolPortal.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            var db = new NewsDatabase();
            db.Database.CreateIfNotExists();//创建数据库

            var lst = db.Informations.OrderByDescending(o => o.Id).ToList(); //进行降序排序
            ViewBag.Information = lst;

            return View();
        }
    }
}
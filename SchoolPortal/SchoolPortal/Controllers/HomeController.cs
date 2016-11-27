using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new NewsDatabase();
            db.Database.CreateIfNotExists();//创建数据库
            var lst = db.Informations.AsQueryable();

            //不同种类的新闻列表
            var lst1 = lst.Where(o => o.Type.Contains("通知公告"));
            var lst2 = lst.Where(o => o.Type.Contains("科教动态"));
            var lst3 = lst.Where(o => o.Type.Contains("综合新闻"));

            //进行降序排序
            ViewBag.Informations1 = lst1.OrderByDescending(o => o.Id).Take(10).ToList();//降序排序后获取前10行数据
            ViewBag.Informations2 = lst2.OrderByDescending(o => o.Id).Take(10).ToList();
            ViewBag.Informations3 = lst3.OrderByDescending(o => o.Id).Take(10).ToList();
            return View();
        }

        public ActionResult Introduce()
        {            
            return View();
        }

        public ActionResult Faculties()
        {
            return View();
        }

        public ActionResult Teachers()
        {
            return View();
        }

        public ActionResult Students()
        {
            return View();
        }
    }
}
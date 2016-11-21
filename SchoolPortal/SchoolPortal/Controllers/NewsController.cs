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
        public ActionResult Index(string id,string search)
        {
            var db = new NewsDatabase();
            db.Database.CreateIfNotExists();//创建数据库
            var lst = db.Informations.AsQueryable();

            if(!string.IsNullOrWhiteSpace(id) && string.IsNullOrWhiteSpace(search))
            {
                
               lst = lst.Where(o => o.Type.Contains(id)); //导航栏-不同种类的新闻列表
                
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                lst = lst.Where(o => o.Body.Contains(search)); //搜索功能
            }

            ViewBag.Informations = lst.OrderByDescending(o => o.Id).ToList(); //进行降序排序

            ViewBag.id = id;
            ViewBag.search = search;
            
            return View();
        }

        public ActionResult Show(int id)
        {
            var db = new NewsDatabase();
            var article = db.Informations.First(o => o.Id == id);

            ViewData.Model = article;

            return View();
        }
    }
}
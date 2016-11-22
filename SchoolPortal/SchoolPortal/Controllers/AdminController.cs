using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolPortal.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
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
            ViewBag.Informations1 = lst1.OrderByDescending(o => o.Id).ToList(); 
            ViewBag.Informations2 = lst2.OrderByDescending(o => o.Id).ToList();
            ViewBag.Informations3 = lst3.OrderByDescending(o => o.Id).ToList();

            return View();
        }

        /// <summary>
        /// 添加新闻
        /// </summary>
        public ActionResult AddSave(string type, string subject, string body)
        {
            var news = new Information();
            news.Type = type;
            news.Subject = subject;
            news.Body = body;
            news.DataCreated = DateTime.Now;

            var db = new NewsDatabase();
            db.Informations.Add(news);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 编辑界面
        /// </summary>
        public ActionResult Edit(int id)
        {
            var db = new NewsDatabase();
            var news = db.Informations.First(o => o.Id == id);
            ViewData.Model = news;

            return View();
        }

        /// <summary>
        /// 保存编辑内容
        /// </summary>
        public ActionResult EditSave(int id, string subject, string body)
        {
            var db = new NewsDatabase();
            var news = db.Informations.First(o => o.Id == id);

            news.Subject = subject;
            news.Body = body;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
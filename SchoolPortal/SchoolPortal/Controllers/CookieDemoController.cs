using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolPortal.Controllers
{
    public class CookieDemoController : Controller
    {
        // GET: CookieDemo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(int id=0)
        {
            ViewBag.error = null;
            if (id == 1)
            {
                ViewBag.error = "用户名不存在请重新输入！";
            }
            if (id == 2)
            {
                ViewBag.error = "密码错误请重新输入！";
            }
            if (id == 3)
            {
                ViewBag.error = "请先登录！";
            }
            return View();
        }

        public ActionResult LoginValidate(string name, string password)
        {
            var db = new NewsDatabase();
            var users = db.Users.FirstOrDefault(o => o.UserName == name); //LINQ查询操作符--http://blog.csdn.net/anchenyanyue/article/details/6732186
            if (users!=null)
            {
                if(users.Password==password)
                {
                    var cookie = new HttpCookie("loginCookie", "true");
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Login", "CookieDemo", new { id = 2 });
                }
            }
            else
            {
                return RedirectToAction("Login", "CookieDemo", new { id = 1 });
            }           
        }
    }
}
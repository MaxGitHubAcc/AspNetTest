using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject2.Models;
using TestProject2.Filters;



namespace TestProject2.Controllers
{
    public class HomeController : Controller
    {

        Model1Container db = new Model1Container();
        //ApplicationDbContext db = new ApplicationDbContext();

    
    [AuthFilter]
    public ActionResult Index()
    {
        IEnumerable<Message> messages = db.Messages;
        ViewBag.Messages = messages;
        return View();
    }
    
        /*
        [AuthFilter]
        public ActionResult Index(string UserName)
        {
            IQueryable<Message> messages = db.Messages.Include(p =>p.UserName);
            ViewBag.Messages = messages;
            return View();
        }
        */
        public ActionResult About()
        {
            ViewBag.Message = 
                    "Приложение разработано в качестве тестового задания";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контактная информация";

            return View();
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Message message)
        {
            message.Dt = DateTime.Now;
            message.UserName = User.Identity.Name;
            // добавляем информацию о покупке в базу данных
            db.Messages.Add(message);
            // сохраняем в бд все изменения
            db.SaveChanges();

            return View();
        }
        
    }
}
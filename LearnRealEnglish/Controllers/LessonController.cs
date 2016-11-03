using LearnRealEnglish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnRealEnglish.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        public ActionResult Index(LessonModel model)
        {
            return View(model);
        }
    }
}
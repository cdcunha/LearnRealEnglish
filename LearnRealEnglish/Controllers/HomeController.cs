using LearnRealEnglish.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnRealEnglish.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Path = "E:\\Curso LearnRealEnglish\\";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Here you can hear all the MP3 and view the PDF together";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Have a suggestion? Contact me:";

            return View();
        }

        [HttpPost]
        public ActionResult Files(FormCollection collection)
        {
            if (Request.IsAjaxRequest())
            {
                var model = new FilesModel();
                TryUpdateModel(model, collection);

                List<string> filesList = new List<string>();
                if (!string.IsNullOrEmpty(model.Path))
                {
                    String[] Files = System.IO.Directory.GetFiles(model.Path, "*.pdf", System.IO.SearchOption.AllDirectories);
                    
                    foreach (string file in Files)
                    {
                        filesList.Add("<a href='#' class='list-group-item'>" + file + "</a>");
                    }
                }
                return PartialView(filesList);
            }else
            {
                return View();
            }
        }
    }
}
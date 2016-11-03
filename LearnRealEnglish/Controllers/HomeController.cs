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
        public ActionResult Index(FilesModel model)
        {
            if(string.IsNullOrEmpty(model.FilesPath))
                model.FilesPath = "E:\\Curso LearnRealEnglish\\";

            if(model.Files == null)
                model.Files = new List<string>();

            return View(model);
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

        [HttpPost, ValidateAntiForgeryToken]
        public JsonResult GetFiles(FilesModel model)
        {
            if (Request.IsAjaxRequest())
            {
                if(model.Files == null)
                    model.Files = new List<string>();
                else
                    model.Files.Clear();

                if (!string.IsNullOrEmpty(model.FilesPath))
                {
                    if (Directory.Exists(model.FilesPath))
                    {
                        String[] PdfFiles = System.IO.Directory.GetFiles(model.FilesPath, "*.pdf", System.IO.SearchOption.AllDirectories);
                        String[] Mp3Files = System.IO.Directory.GetFiles(model.FilesPath, "*.mp3", System.IO.SearchOption.AllDirectories);

                        if (Mp3Files.Count() > 0)
                        {
                            string txtItem = "<a href=\"javascript:Play('{0}','{1}, {2}');\" class='list-group-item'>{2}</a>";
                            int j = 0;
                            for (int i = 0; i < PdfFiles.Count(); i++)
                            {
                                string nameLesson = Path.GetFileName(PdfFiles[i])
                                    .Replace(".pdf", "").Replace("_"," ")
                                    .Replace(" MS", " Mini Story")
                                    .Replace(" POV", " Point of View");
                                if(PdfFiles[i].Contains("Welcome Guide"))
                                {
                                    model.Files.Add(string.Format(txtItem, PdfFiles[i], "", nameLesson));
                                }
                                else
                                {
                                    model.Files.Add(string.Format(txtItem, PdfFiles[i], Mp3Files[j], nameLesson));
                                    j++;
                                }
                            }
                        }
                    }
                    else
                    {
                        model.Files.Add("The path not exists");
                    }
                }
                return Json(model.Files, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if(model.Files == null)
                    model.Files = new List<string>();

                model.Files.Add("Call this method only by Ajax");
                return Json(model.Files, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult OpenLesson()
        {


            return Json("Ok", JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnRealEnglish.Models
{
    public class FilesModel
    {
        public string FilesPath { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> Files { get; set; }
        
    }
}
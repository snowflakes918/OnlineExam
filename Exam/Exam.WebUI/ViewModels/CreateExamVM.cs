using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.WebUI.ViewModels
{
    public class CreateExamVM
    {
        public string[] A { get; set; }
        public string[] B { get; set; }
        public string[] C { get; set; }
        public string[] D { get; set; }
        public string[] Question { get; set; }
        public int[] correct { get; set; }
        public int wired { get; set; }
    }
}

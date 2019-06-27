using Exam.BOL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.WebUI.ViewModels
{
    public class ExamsVM
    {
        public IEnumerable<Question> question { get; set; }
        public Test Test { get; set; }
    }
}

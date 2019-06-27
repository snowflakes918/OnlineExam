using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.BOL.Entities;
using Exam.DAL.Repositories;
using Exam.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Exam.WebUI.Controllers
{
    public class AJAXController : Controller
    {
        ISqlRepository<Option> repoOption;
        public AJAXController(ISqlRepository<Option> _repoOption)
        {
            repoOption = _repoOption;
        }
        public IActionResult GetWiredContent(int WiredID)
        {
            return Content(Wired.GetWireds().FirstOrDefault(f => f.ID == WiredID).content);
        }
        public int[] ExamResult(string _answers)
        {
            string[] answers = _answers.Split(',');
            int[] result = new int[answers.Length];
            for (int i = 0; i < answers.Length; i++)
            {
                
                int ans = Convert.ToInt32(answers[i]);
                if (ans != 0)
                {
                    if (repoOption.GetAll().FirstOrDefault(w => w.ID == ans).correct)
                        result[i] = 1;//doğru cevap
                    else result[i] = 0;//yanlış cevap
                }
                else result[i] = 2;//cevap verilmediyse
            }
            return result;
        }
    }
}
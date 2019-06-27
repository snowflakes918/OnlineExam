using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.BOL.Entities;
using Exam.DAL.Repositories;
using Exam.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.WebUI.Controllers
{
    [Authorize]
    public class ExamScreenController : Controller
    {
        ISqlRepository<Question> repoQuestion;
        ISqlRepository<Test> repoTest;
        public ExamScreenController(ISqlRepository<Test> _repoTest, ISqlRepository<Question> _repoQuestion)
        {
            repoTest = _repoTest;
            repoQuestion = _repoQuestion;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Test Test = repoTest.GetBy(g => g.ID == id);
            IEnumerable<Question> questions = await repoQuestion.GetAll().Include(i => i.Options).Where(w => w.TestID == id).ToListAsync();

            ExamsVM examsVM = new ExamsVM
            {
                question = questions,
                Test = Test
            };
            return View(examsVM);
        }
    }
}
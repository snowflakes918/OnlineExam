using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.BOL.Entities;
using Exam.DAL.Repositories;
using Exam.WebUI.Helpers;
using Exam.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam.WebUI.Controllers
{
    [Authorize]
    public class ExamsController : Controller
    {
        ISqlRepository<Test> repoTest;
        ISqlRepository<Question> repoQuestion;
        ISqlRepository<Option> repoOption;
        public ExamsController(ISqlRepository<Test> _repoTest, ISqlRepository<Question> _repoQuestion, ISqlRepository<Option> _repoOption)
        {
            repoTest = _repoTest;
            repoQuestion = _repoQuestion;
            repoOption = _repoOption;
        }
        public IActionResult Index()
        {

            return View(repoTest.GetAll());
        }
        public IActionResult Create()
        {
            List<Wired> wireds = Wired.GetWireds();

            return View(wireds);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateExamVM model)
        {
            Wired wired = Wired.GetWireds().FirstOrDefault(f => f.ID == model.wired);
            if (ModelState.IsValid)
            {
                try
                {
                    Test Test = new Test
                    {
                        ReleaseDate = DateTime.Now,
                        title = wired.title,
                        content = wired.content
                    };
                    repoTest.Add(Test);
                    for (int i = 0; i < model.Question.Length; i++)
                    {
                        Question question = new Question
                        {
                            name = model.Question[i],
                            TestID = Test.ID
                        };
                        repoQuestion.Add(question);
                        repoOption.Add(new Option
                        {
                            answer = model.A[i],
                            pIndex = 1,
                            QuestionID = question.ID,
                            correct = model.correct[i] == 1 ? true : false
                        });
                        repoOption.Add(new Option
                        {
                            answer = model.B[i],
                            pIndex = 2,
                            QuestionID = question.ID,
                            correct = model.correct[i] == 2 ? true : false
                        });
                        repoOption.Add(new Option
                        {
                            answer = model.C[i],
                            pIndex = 3,
                            QuestionID = question.ID,
                            correct = model.correct[i] == 3 ? true : false
                        });
                        repoOption.Add(new Option
                        {
                            answer = model.D[i],
                            pIndex = 4,
                            QuestionID = question.ID,
                            correct = model.correct[i] == 4 ? true : false
                        });

                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return View(model);
                }  
            }
            else return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            Test Test = repoTest.GetBy(g => g.ID == id);
            if (Test != null) repoTest.Remove(Test);
            return RedirectToAction(nameof(Index));
        }

    }
}
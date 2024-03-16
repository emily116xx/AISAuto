using AISAutoForms.ViewModels;
using AISAutoForms.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using AISAutoForms.Data;
using Microsoft.EntityFrameworkCore;

namespace AISAutoForms.Controllers
{
    public class ChangeCourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChangeCourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChangeCourse/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChangeCourse/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ChangeCourseVM viewModel)
        {
            if (ModelState.IsValid)
            {
                // Create and save Student
                var student = new Student
                {
                    StudentId = viewModel.StudentId,
                    StudentName = viewModel.StudentName,
                    StudentEmail = viewModel.StudentEmail,
                    StudentPhone = viewModel.StudentPhone,
                    StudentAddress = viewModel.StudentAddress,
                    ProgrammeOfStudy = viewModel.ProgrammeOfStudy
                };
                _context.Students.Add(student);
                _context.SaveChanges();

                // Create and save ChgCourse
                var chgCourse = new ChgCourse
                {
                    // Split and concatenate selected request types
                    //ChgCourseId = viewModel.ChgCourseId,
                    ChgCourseType = string.Join(",", viewModel.ChgCourseType),
                    Status = "Submitted",
                    SubmitDate = viewModel.SubmitDate,
                    Signature = viewModel.Signature,
                    StudentId = student.StudentId
                };
                _context.ChgCourses.Add(chgCourse);
                _context.SaveChanges();

                // Save EnrCourse
                if (!string.IsNullOrEmpty(viewModel.CourseCode))
                {
                    var enrCourse = new EnrCourse
                    {
                        CourseCode = viewModel.CourseCode,
                        CourseName = viewModel.CourseName,
                        ChgCourseId = chgCourse.ChgCourseId
                    };
                    _context.EnrCourses.Add(enrCourse);
                }

                // Save AddCourse
                if (!string.IsNullOrEmpty(viewModel.AddCourseCode))
                {
                    var addCourse = new AddCourse
                    {
                        AddCourseCode = viewModel.AddCourseCode,
                        AddCourseName = viewModel.AddCourseName,
                        ChgCourseId = chgCourse.ChgCourseId
                    };
                    _context.AddCourses.Add(addCourse);
                }

                // Save WitdCourse
                if (!string.IsNullOrEmpty(viewModel.WitdCourseCode))
                {
                    var witdCourse = new WitdCourse
                    {
                        WitdCourseCode = viewModel.WitdCourseCode,
                        WitdCourseName = viewModel.WitdCourseName,
                        ChgCourseId = chgCourse.ChgCourseId
                    };
                    _context.WitdCourses.Add(witdCourse);
                }

                _context.SaveChanges();

                //return RedirectToAction("Success");
                TempData["Message"] = "Record Inserted";
                return View("ChangeCourseDetails", viewModel);
            }

            return View(viewModel);
        }

        public ActionResult View(ChangeCourseVM viewModel)
        {
            return View(viewModel);
        }

        //Original Index page
        //public IActionResult Index()
        //{
        //    var viewModel = new ChangeCourseVM();
        //    return View(viewModel);
        //}


        public IActionResult Index()
        {
            // Retrieve the list of ChgCourse records
            var chgCourses = _context.ChgCourses
                .Include(c => c.Student)
                .Select(c => new ListChgCourseVM
                {
                    ChgCourseId = c.ChgCourseId,
                    StudentId = c.StudentId,
                    SubmitDate = c.SubmitDate,
                    Status = c.Status
                })
                .ToList();

            return View(chgCourses);
        }


        //public IActionResult Details(ApproveChgCourseVM viewModel)
        public IActionResult Details(int id)
        {
            // Retrieve the ChgCourse record by id
            var chgCourse = _context.ChgCourses
                .Include(c => c.Student)
                .Include(c => c.AddCourses)
                .Include(c => c.EnrCourses)
                .Include(c => c.WitdCourses)
                .FirstOrDefault(c => c.ChgCourseId == id);

            if (chgCourse == null)
            {
                return NotFound();
            }


            // Convert ChgCourse to ChangeCourseVM
            //var viewModel = new ChangeCourseVM
            var viewModel = new ApproveChgCourseVM
            {
                // Map properties from ChgCourse to viewModel
                // Example:
                ChgCourseId = chgCourse.ChgCourseId,
                StudentId = chgCourse.StudentId,
                SubmitDate = chgCourse.SubmitDate,
                Status = chgCourse.Status,
                Signature = chgCourse.Signature,
                ChgCourseType = chgCourse.ChgCourseType,

                StudentName = chgCourse.Student.StudentName,
                StudentEmail = chgCourse.Student.StudentEmail,
                StudentPhone = chgCourse.Student.StudentPhone,
                StudentAddress = chgCourse.Student.StudentAddress,
                ProgrammeOfStudy = chgCourse.Student.ProgrammeOfStudy,

                CourseCode = chgCourse.EnrCourses.FirstOrDefault()?.CourseCode,
                CourseName = chgCourse.EnrCourses.FirstOrDefault()?.CourseName,

                AddCourseCode = chgCourse.AddCourses.FirstOrDefault()?.AddCourseCode,
                AddCourseName = chgCourse.AddCourses.FirstOrDefault()?.AddCourseName,

                WitdCourseCode = chgCourse.WitdCourses.FirstOrDefault()?.WitdCourseCode,
                WitdCourseName = chgCourse.WitdCourses.FirstOrDefault()?.WitdCourseName,




                ApproverName = "", // Assuming this will be filled when the approval button is clicked
                ApproverDate = DateTime.Now, // Assuming this will be filled when the approval button is clicked
                ApproverComments = "", // Assuming this will be filled when the approval button is clicked
                RegistrarName = "", // Assuming this will be filled when the approval button is clicked
                ProcessDate = DateTime.Now, // Assuming this will be filled when the approval button is clicked
                ReturnedDate = DateTime.Now, // Assuming this will be filled when the approval button is clicked
                TranscriptUpdate = "", // Assuming this will be filled when the approval button is clicked
                Comments = "", // Assuming this will be filled when the approval button is clicked
                ProcessBy = "", // Assuming this will be filled when the approval button is clicked
                IsChange = false, // Assuming this will be filled when the approval button is clicked
                IsWithdrawal = false, // Assuming this will be filled when the approval button is clicked
                IsCancelled = false, // Assuming this will be filled when the approval button is clicked
                IsRequired = false, // Assuming this will be filled when the approval button is clicked
                PaymentAmt = 0, // Assuming this will be filled when the approval button is clicked
                RefundAmt = 0, // Assuming this will be filled when the approval button is clicked
                TransferAmt = 0, // Assuming this will be filled when the approval button is clicked

                // ...
            };

            return View(viewModel);
        }

        // *----------------------------------------------------------------------------------*
        // *----------------------------------------------------------------------------------*
        //Succeeding buttons should be below
        // *----------------------------------------------------------------------------------*
        // *----------------------------------------------------------------------------------*



    }
}

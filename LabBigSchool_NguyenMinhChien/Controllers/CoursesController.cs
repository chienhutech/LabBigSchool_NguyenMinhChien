
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

using LabBigSchool_NguyenMinhChien.Models;
using Lab_BigSchool_NguyenMinhChien.Models;

public class CoursesController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    public CoursesController()
    {
        _dbContext = new ApplicationDbContext();
    }

    public object Course { get; private set; }

    [Authorize]
    // GET: Courses
    public ActionResult Create()
    {
        var viewModel = new CourseViewModel
        {
            Categories = _dbContext.Categories.ToList()
        };
        return View(viewModel);
    }
    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CourseViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Categories = _dbContext.Categories.ToList();
            return View("Create", viewModel);
        }
        {
            if (ModelState.IsValid)

            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", "viewModel");
            }    
        }
        var course = new Course
        {
            LecturerId = User.Identity.GetUserId(),
            DateTime = viewModel.GetDateTime(),
            CategoryId = viewModel.Category,
            Place = viewModel.Place
        };
        Course course1 = _dbContext.Courses.Add(course);
        _dbContext.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}
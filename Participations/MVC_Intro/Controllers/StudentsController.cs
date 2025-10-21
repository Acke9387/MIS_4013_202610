using Microsoft.AspNetCore.Mvc;
using MVC_Intro.Models;

namespace MVC_Intro.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice Johnson", Email = "Alice.Johnson@ou.edu" },
                new Student { Id = 2, Name = "Bob Smith", Email = "Bob.Smith@ou.edu" },
                new Student { Id = 3, Name = "Charlie Brown", Email = "Charlie.Brown@ou.edu" }
            };


            return View(students);
        }

        public IActionResult Events()

        {
            // create 3-5 events for students off of the StudentEvent model
            List<StudentEvent> events = new List<StudentEvent>
            {
                new StudentEvent { EventName = "Orientation", EventDate = new DateTime(2024, 8, 20), Location = "Main Auditorium" },
                new StudentEvent { EventName = "Career Fair", EventDate = new DateTime(2024, 9, 15), Location = "Student Center" },
                new StudentEvent { EventName = "Homecoming", EventDate = new DateTime(2024, 10, 5), Location = "Campus Grounds" }
            };


            return View(events);
        }

    }
}

using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            //IEnumerable list olarak alınan veri view üzerine aktarılmaktadır.
            var model = Repository.Applications;
            return View(model);
        }

        public IActionResult Apply()
        {
            return View();
        }   

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm]Candidate model)
        {
            // Kayıtlar ile yeni kayıt kontrolü
            if(Repository.Applications.Any(x => x.Email.Equals(model.Email))) 
            {
                ModelState.AddModelError("", "There is already application for you.");
            }
            //Eğer model geçerli ise işlem yapılacaktır
            if (ModelState.IsValid)
            {
                Repository.Add(model);
                return View("Feedback", model);
            }
            return View();
            
        }
    }
}

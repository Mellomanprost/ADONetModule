using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SF.EF.DAL;

namespace SF.EF.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ContextDB _db;

        public UserController(ContextDB db)
        {
            this._db = db;
        }

        //// GET: UserController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: UserController/Details/5

        [HttpGet]
        public async Task<ActionResult> Details([FromQuery] int id)
        {
           var user = await _db.Users.Include(w => w.Post).FirstOrDefaultAsync(r => r.Id == id);

           if (user == null)
               return NotFound();

            return View(user);
        }

        //// GET: UserController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: UserController/Create
        [HttpPost]
        public async Task<ActionResult> Create()
        {
            try
            {
                var user = new User()
                {
                    Company = new Company() { Name = "Компания"},
                    Name = "Имя пользователя",
                    Post = new List<Post> { new Post(){Description = "Технический директор" }, new Post() { Description = "Тимлид" } }
                };

                _db.Users.Add(user);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: UserController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: UserController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UserController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UserController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

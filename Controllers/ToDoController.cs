using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {

        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult AddName()
        {

            return View();

        }

        public IActionResult AllToDo(int Id)
        {

            var newUser = _context.
                Users.Find(Id);
            var ToDosToUSer = _context.ToDos.Where(e => e.UserId == Id).ToList();
            return View(new { User = newUser, ToDos = ToDosToUSer });

        }
        public IActionResult SaveUser(User user)
        {

            var newUser =_context.Users.Add(user);

            _context.SaveChanges();
           

            return RedirectToAction("AllToDo", new { newUser.Entity.Id });
        }

        public IActionResult AddNewToDo(ToDo toDo)
        {

            _context.ToDos.Add(toDo);
            _context.SaveChanges();

            return RedirectToAction("AllToDo", new { Id = toDo.UserId });

        }
        public IActionResult EditToDo(ToDo toDo)
        {

            _context.ToDos.Update(toDo);
            _context.SaveChanges();

            return RedirectToAction("AllToDo", new { Id = toDo.UserId });

        }

        public IActionResult DeleteTodo(int  Id)
        {

            var toDo = _context.ToDos.Find(Id);

            _context.ToDos.Remove(_context.ToDos.Find(Id));
            _context.SaveChanges();

            return RedirectToAction("AllToDo", new { Id = toDo.UserId });
        }

    }
}

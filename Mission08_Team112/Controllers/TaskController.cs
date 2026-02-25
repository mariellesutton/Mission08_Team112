using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team112.Models;
using TaskModel = Mission08_Team112.Models.Task;

namespace Mission08_Team112.Controllers;

public class TaskController : Controller
{
    private readonly ApplicationDbContext _context;

    public TaskController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Quadrants()
    {
        var tasks = _context.Tasks.Include(t => t.Category).ToList();
        return View(tasks);
    }

    // ----- EDIT -----
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task == null) return NotFound();

        ViewBag.Categories = _context.Categories.ToList();
        return View(task);
    }

    [HttpPost]
    public IActionResult Edit(TaskModel updated)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(updated);
        }

        _context.Tasks.Update(updated);
        _context.SaveChanges();
        return RedirectToAction("Quadrants");
    }

    // ----- DELETE -----
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var task = _context.Tasks
            .Include(t => t.Category)
            .FirstOrDefault(t => t.TaskId == id);

        if (task == null) return NotFound();

        return View(task); // confirmation page
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task == null) return NotFound();

        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return RedirectToAction("Quadrants");
    }
}
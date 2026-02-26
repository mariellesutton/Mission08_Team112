using Microsoft.AspNetCore.Mvc;
using Mission08_Team112.Models;

namespace Mission08_Team112.Controllers;

public class TaskController : Controller
{
    private ITaskRepository _taskRepository;

    public TaskController(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public IActionResult Index()
    {
        var tasks = _taskRepository.Tasks;
        return View(tasks);
    }

    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Categories = _taskRepository.Categories;
        return View();
    }

    [HttpPost]
    public IActionResult Add(Task task)
    {
        if (ModelState.IsValid)
        {
            _taskRepository.AddTask(task);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = _taskRepository.Categories;
        return View(task);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _taskRepository.GetTaskById(id);
        ViewBag.Categories = _taskRepository.Categories;
        return View(task);
    }

    [HttpPost]
    public IActionResult Edit(Task task)
    {
        if (ModelState.IsValid)
        {
            _taskRepository.UpdateTask(task);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = _taskRepository.Categories;
        return View(task);
    }

    public IActionResult Delete(int id)
    {
        var task = _taskRepository.GetTaskById(id);
        _taskRepository.DeleteTask(task);
        return RedirectToAction("Index");
    }

    public IActionResult MarkTaskComplete(int id)
    {
        _taskRepository.MarkComplete(id);
        return RedirectToAction("Index");
    }
}
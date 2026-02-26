using Microsoft.AspNetCore.Mvc;
using Mission08_Team112.Models;
using Microsoft.EntityFrameworkCore;
using TaskModel = Mission08_Team112.Models.Task;

namespace Mission08_Team112.Controllers;

public class TaskController : Controller
{

    private ITaskRepository _taskRepository;
    
    public IActionResult Quadrants()
    {
        var tasks = _taskRepository.GetIncompleteTasks();
        return View(tasks);
    }

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
    public IActionResult Add(TaskModel task)
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
    public IActionResult Edit(TaskModel task)
    {
        if (ModelState.IsValid)
        {
            _taskRepository.UpdateTask(task);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = _taskRepository.Categories;
        return View(task);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var task = _taskRepository.GetTaskById(id);
        return View(task);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var task = _taskRepository.GetTaskById(id);
        _taskRepository.DeleteTask(task);
        return RedirectToAction("Index");
    }

    public IActionResult MarkComplete(int id)
    {
        _taskRepository.MarkComplete(id);
        return RedirectToAction("Index");
    }
}
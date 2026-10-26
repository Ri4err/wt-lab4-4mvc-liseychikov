using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class TaskController : Controller
{
    private static List<TaskModel> tasks = new List<TaskModel>
    {
        new TaskModel
        {
            Id = 1,
            Name = "Разработка приложения",
            Category = "Разработка",
            Price = 5000,
            IsAvaliable = true
        },
        new TaskModel
        {
            Id = 2,
            Name = "Оптимизация ПО",
            Category = "Оптимизация",
            Price = 3500,
            IsAvaliable = false
        },
        new TaskModel
        {
            Id = 3,
            Name = "Проверка кода на наличие ошибок",
            Category = "Проверка",
            Price = 2000,
            IsAvaliable = true
        },
        new TaskModel
        {
            Id = 4,
            Name = "Разработка плана для проекта",
            Category = "Разработка",
            Price = 3500,
            IsAvaliable = true
        },
        new TaskModel
        {
            Id = 5,
            Name = "Создание пользовательского интерфейса",
            Category = "Дизайн",
            Price = 6700,
            IsAvaliable = false
        }
    };

    public IActionResult Index()
    {
        return View(tasks);
    }

    public IActionResult Details(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        return View(task);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TaskModel task)
    {
        if (ModelState.IsValid)
        {
            tasks.Add(task);
            return RedirectToAction("Index");
        }
        return View(task);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    [HttpPost]
    public IActionResult Edit(TaskModel task)
    {
        var existingTask = tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existingTask == null)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            existingTask.Name = task.Name;
            existingTask.Category = task.Category;
            existingTask.Price = task.Price;
            existingTask.IsAvaliable = task.IsAvaliable;

            return RedirectToAction("Index");
        }
        return View(task);
    }
}


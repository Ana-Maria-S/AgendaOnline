using System;
using System.Collections.Generic;
using AgendaOnline.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOnline.Controllers
{
    public class ToDoController:Controller
    {
        public IActionResult Index()
        {
            var currentToDos = new List<ToDoItemViewModel>();
            currentToDos.Add(new ToDoItemViewModel
            {
                Date = DateTime.Now,
                Description = "TEST",
                Done = false,
                Title = "ana test",
                ID = 1
            });
            currentToDos.Add(new ToDoItemViewModel
            {
                Date = DateTime.Now,
                Description = "TEST2",
                Done = true,
                Title = "ana test2",
                ID = 1
            });
            return View(currentToDos);
        }
    }
}
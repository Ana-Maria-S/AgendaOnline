using System;
using System.Collections.Generic;
using AgendaOnline.Repository;
using AgendaOnline.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOnline.Controllers
{
    public class ToDoController:Controller
    {
        private IToDoItemsRepository _repo;
        public ToDoController(IToDoItemsRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View(_repo.GetCurrentToDoItems());
        }
        public IActionResult Detalii(int id)
        {
            return View(_repo.GetToDoItemById(id));
        }
        public IActionResult DetaliiPartial(int id)
        {
            return PartialView("Detalii",_repo.GetToDoItemById(id));
        }
        [HttpGet]
        public IActionResult Adauga()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adauga(ToDoItemViewModel item)
        {
            _repo.Adauga(item);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editeaza(int id)
        {
            return View(_repo.GetToDoItemById(id));
        }
        public IActionResult Sterge(int id)
        {
            _repo.Sterge(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Editeaza(int id, ToDoItemViewModel item)
        {
            _repo.UpdateToDoItem(id, item);
            return RedirectToAction(nameof(Index));
        }
    }
}
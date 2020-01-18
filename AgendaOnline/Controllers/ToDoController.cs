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
        //O instanta a repository-ului este transmisa controllerului in constructor prin Dependency Injection 
        //acest lucru se poate vedea si in clasa Startup.cs
        public ToDoController(IToDoItemsRepository repo)
        {
            _repo = repo;
        }
        //returneaza toate ToDo items
        public IActionResult Index()
        {
            return View(_repo.GetCurrentToDoItems());
        }
        //returneaza un ToDo item dupa Id sub forma de View
        public IActionResult Detalii(int id)
        {
            return View(_repo.GetToDoItemById(id));
        }
        //returneaza un ToDo item dupa Id sub forma de View Partial
        public IActionResult DetaliiPartial(int id)
        {
            return PartialView("Detalii",_repo.GetToDoItemById(id));
        }
        //returneaza view-ul cu formularul folosit pentru a adauga un ToDoItem
        [HttpGet]
        public IActionResult Adauga()
        {
            return View();
        }

        //metoda prin care se face Post la un nou to do item
        [HttpPost]
        public IActionResult Adauga(ToDoItemViewModel item)
        {
            _repo.Adauga(item);
            return RedirectToAction(nameof(Index));
        }
        //returneaza view-ul cu formularul folosit pentru a edita un ToDoItem
        [HttpGet]
        public IActionResult Editeaza(int id)
        {
            return View(_repo.GetToDoItemById(id));
        }
        //metoda prin care se sterge un ToDo Item
        public IActionResult Sterge(int id)
        {
            _repo.Sterge(id);
            return RedirectToAction(nameof(Index));
        }
        //metoda prin care se face Post la un item editat
        [HttpPost]
        public IActionResult Editeaza(int id, ToDoItemViewModel item)
        {
            _repo.UpdateToDoItem(id, item);
            return RedirectToAction(nameof(Index));
        }
    }
}
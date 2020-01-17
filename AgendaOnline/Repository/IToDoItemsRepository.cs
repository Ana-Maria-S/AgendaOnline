using AgendaOnline.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaOnline.Repository
{
    public interface IToDoItemsRepository
    {
        List<ToDoItemViewModel> GetCurrentToDoItems();
        ToDoItemViewModel GetToDoItemById(int id);
        void UpdateToDoItem(int id, ToDoItemViewModel item);
        void Sterge(int id);
        void Adauga(ToDoItemViewModel item);
    }
}

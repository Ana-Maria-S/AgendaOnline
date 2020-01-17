using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaOnline.ViewModels;

namespace AgendaOnline.Repository
{
    public class ToDoItemsRepositoryInMemory : IToDoItemsRepository
    {
        List<ToDoItemViewModel> currentToDos;
        int currentIdNumber = 1;
        public ToDoItemsRepositoryInMemory()
        {
            if (currentToDos == null)
            {
                currentToDos = new List<ToDoItemViewModel>();
            }
            if (currentToDos.Count == 0)
            {
                currentToDos.Add(new ToDoItemViewModel
                {
                    Date = DateTime.Now,
                    Description = "TEST",
                    Done = false,
                    Title = "ana test",
                    ID = 0
                });
                currentToDos.Add(new ToDoItemViewModel
                {
                    Date = DateTime.Now,
                    Description = "TEST2",
                    Done = true,
                    Title = "ana test2",
                    ID =1
                });
            }
        }

        public void Adauga(ToDoItemViewModel item)
        {
            item.ID = ++currentIdNumber;
            currentToDos.Add(item);
        }

        public List<ToDoItemViewModel> GetCurrentToDoItems()
        {
                return currentToDos;
        }

        public ToDoItemViewModel GetToDoItemById(int id)
        {
            return currentToDos[id];
        }

        public void Sterge(int id)
        {
            currentToDos.RemoveAt(id);
        }

        public void UpdateToDoItem(int id, ToDoItemViewModel item)
        {
            var itemEditat = currentToDos[id];
            itemEditat.Title = item.Title;
            itemEditat.Description = item.Description;
            itemEditat.Done = item.Done;
            itemEditat.Date = item.Date;
        }
    }
}

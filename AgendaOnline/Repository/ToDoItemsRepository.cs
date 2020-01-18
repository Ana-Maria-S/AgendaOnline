using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AgendaOnline.ViewModels;
using Newtonsoft.Json;

namespace AgendaOnline.Repository
{
    //Repository care citeste/scrie din/in fisierul ToDoItems.txt sub forma de Json din folderul Database
    public class ToDoItemsRepository : IToDoItemsRepository
    {
        List<ToDoItemViewModel> currentToDos;
        int currentIdNumber = 0;
   
        //in constructor se incarca lista de ToDo items din baza de date
        public ToDoItemsRepository()
        {
                currentToDos = LoadItemsAsJson();
        }
        //metoda prin care se citeste din fisierul text si se deserializeaza obiectele
        private List<ToDoItemViewModel> LoadItemsAsJson()
        {
            List<ToDoItemViewModel> items;
            using (StreamReader r = new StreamReader("Database/ToDoItems.txt"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<ToDoItemViewModel>>(json);
            }
            if(items==null)
                items = new List<ToDoItemViewModel>();
            return items;
        }
        //metoda prin care se serializeaza obiectele si se scrie in fisierul text
        private void WriteItemsAsJson()
        {
            File.WriteAllText(@"Database/ToDoItems.txt", JsonConvert.SerializeObject(currentToDos));
        }

        //metoda prin care se adauga un ToDo in lista din memorie si se scrie din nou lista in fisierul text
        public void Adauga(ToDoItemViewModel item)
        {
            //la adaugarea unui item se asigneaza un ID nou unic
            item.ID = currentToDos.Count+1;
            currentToDos.Add(item);
            WriteItemsAsJson();
        }

        public List<ToDoItemViewModel> GetCurrentToDoItems()
        {
            return currentToDos;
        }

        //se citeste un toDoItem din memorie dupa ID
        public ToDoItemViewModel GetToDoItemById(int id)
        {
            return currentToDos.First(x => x.ID == id);
        }

        //se sterge un ToDo item din memorie si se rescrie lista in fisierul text
        public void Sterge(int id)
        {
            var item = currentToDos.First(x => x.ID == id);
            currentToDos.Remove(item);
            WriteItemsAsJson();
        }
        //proprietatile obiectului sunt actualizate si se rescrie lista in fisierul text
        public void UpdateToDoItem(int id, ToDoItemViewModel item)
        {
            var itemEditat = currentToDos.First(x => x.ID == id);
            itemEditat.Title = item.Title;
            itemEditat.Description = item.Description;
            itemEditat.Done = item.Done;
            itemEditat.Date = item.Date;
            WriteItemsAsJson();
        }
    }
}

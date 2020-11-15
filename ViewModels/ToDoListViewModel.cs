using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ToDoDemo.Models;
using Dapper;
using ToDoDemo.Helpers;
/*
 * Represents data that will go between controller and view
 */
namespace ToDoDemo.ViewModels
{
    public class ToDoListViewModel
    {
        public ToDoListViewModel()
        {
            using (var db = DbHelper.GetConnection())
            {
                this.EditableItem = new ToDoListItem();
                this.ToDoItems = db.Query<ToDoListItem>("SELECT * FROM TodoListItems ORDER BY AddDate DESC").ToList();
            }
        }
        public List<ToDoListItem> ToDoItems { get; set; }

        public ToDoListItem EditableItem { get; set; }
    }
}

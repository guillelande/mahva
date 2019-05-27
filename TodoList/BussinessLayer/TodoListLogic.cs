using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Net;
using System.Net.Http;
using Mavha.TodoList.DAL;

namespace Mavha.TodoList.BussinessLayer
{
    public class TodoListLogic : BussinessBase
    {
        private static TodoListLogic _instance;
        public static TodoListLogic Instance
        {
            get { return _instance ?? (_instance = new TodoListLogic()); }

        }

        public List<Tasks> GetTodoList()
        {
            return Context.Tasks.ToList();
        }

        public Tasks GetTodoList(int ID)
        {
            return Context.Tasks.FirstOrDefault(x => x.ID == ID);
        }

        public List<Tasks> GetTodoList(string description)
        {
            return !string.IsNullOrWhiteSpace(description) 
                ? Context.Tasks.Where(x => x.Description.Contains(description)).ToList() 
                : Context.Tasks.ToList();
        }

        public List<Tasks> GetTodoList(bool isDone)
        {
            return Context.Tasks.Where(x => x.IsDone == isDone).ToList();
        }

        public void Add(string description, HttpPostedFile file)
        {
            var responseData = new TodoListEntity();
            responseData.Filename = "file-" + DateTime.Now.ToString("yyyyMMddHHmmssffff");

            var destination = "/App_Data/";
            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~" + destination)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~" + destination));
            }

            var FilePath = HttpContext.Current.Server.MapPath("~" + destination + responseData.Filename + Path.GetExtension(file.FileName));
            responseData.Filename = destination + responseData.Filename + Path.GetExtension(file.FileName);

            //Save file in server
            file.SaveAs(FilePath);

            //Add to DB
            var t = new Tasks
            {
                Description = description,
                IsDone = false,
                Attachment = responseData.Filename
            };

            Context.Tasks.Add(t);
            Context.SaveChanges();
        }

        public void Update(Tasks t)
        {
            Context.Entry(t).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Resolved(int ID)
        {
            var t = GetTodoList(ID);
            t.IsDone = true;
            Update(t);
        }

        public void Delete(Tasks t)
        {
            Context.Tasks.Remove(t);
            Context.SaveChanges();
        }
    }
}

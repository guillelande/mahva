using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mavha.TodoList.BussinessLayer;
using System.IO;
using System.Web;
using Newtonsoft.Json;

namespace Mavha.TodoList.APIRestLayer.Controllers
{
    public class TodoListController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(TodoListLogic.Instance.GetTodoList()));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.InnerException);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int ID)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, TodoListLogic.Instance.GetTodoList(ID));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.InnerException);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(string description)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(TodoListLogic.Instance.GetTodoList(description)));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.InnerException);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(bool isDone)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(TodoListLogic.Instance.GetTodoList(isDone)));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.InnerException);
            }
        }

        //[HttpPost]
        //public HttpResponseMessage Add(Tasks t)
        //{
        //    try
        //    {
        //        TodoListLogic.Instance.Add(t);
        //        return Request.CreateResponse(HttpStatusCode.OK, "");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Forbidden, ex.InnerException);
        //    }

        //}

        [HttpPost]
        public HttpResponseMessage Resolved(int ID)
        {
            try
            {
                TodoListLogic.Instance.Resolved(ID);

                return Request.CreateResponse(HttpStatusCode.OK, "");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.InnerException);
            }
        }

        [HttpPost]
        public HttpResponseMessage Add()
        {
            try
            {
                var request = HttpContext.Current.Request;
                //File
                HttpPostedFile file = request.Files["file"];
                //Description
                var description = request["description"];

                TodoListLogic.Instance.Add(description, file);

                return Request.CreateResponse(HttpStatusCode.OK, "");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.InnerException);
            }
        }
    }
}

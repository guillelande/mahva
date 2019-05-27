using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mavha.TodoList.BussinessLayer
{
    public class TodoListEntity
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public string Filename { get; set; }
        public string Status { get; set; }
    }
}

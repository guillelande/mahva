using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mavha.TodoList.DAL;

namespace Mavha.TodoList.BussinessLayer
{
    public class BussinessBase
    {
        private mavhaEntities context;

        protected mavhaEntities Context
        {
            get { return context ?? (context = new mavhaEntities()); }
        }
        protected mavhaEntities NewContext()
        {
            return new mavhaEntities();
        }
    }
}

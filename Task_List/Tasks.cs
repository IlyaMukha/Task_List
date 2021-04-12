using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_List
{
   public class Tasks
    {
        public int Id {get; set;}
        public int status { get; set; }
        public string textOfTask { get; set; }

        public Tasks(int Id, int status, string textOfTask)
        {
            this.Id = Id;
            this.status = status;
            this.textOfTask = textOfTask;
        }
    }
}

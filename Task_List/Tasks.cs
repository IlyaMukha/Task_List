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
        public DateTime date { get; set; }
        public string textOfTask { get; set; }

        public Tasks(int Id, DateTime date, string textOfTask)
        {
            this.Id = Id;
            this.date = date;
            this.textOfTask = textOfTask;
        }
   }
}

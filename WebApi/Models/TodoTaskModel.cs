using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class TodoTaskModel
    {
   
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string City { get; set; }
        public string AssignedTo { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
    }
}

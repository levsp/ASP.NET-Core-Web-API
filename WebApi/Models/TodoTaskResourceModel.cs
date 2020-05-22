using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Models
{
    public class TodoTaskResourceModel
    {
        public int TodoTaskId { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string City { get; set; }
        public string AssignedTo { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public string PriorityName { get; set; }
        public string StatusName { get; set; }
    }
}

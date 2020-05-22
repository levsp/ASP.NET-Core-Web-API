using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class TodoTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TodoTaskId { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string City { get; set; }
        public string AssignedTo { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}

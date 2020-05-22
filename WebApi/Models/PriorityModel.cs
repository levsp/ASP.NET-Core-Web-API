using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PriorityModel
    {
        public int PriorityId { get; set; }
        public string Name { get; set; }
    }
}

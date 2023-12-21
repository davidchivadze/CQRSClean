using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Domain.Models.EntityModels
{
    public class Currency
    {
        [Key]
        public int Id { get; set; } 
        public string Description { get; set; }
    }
}

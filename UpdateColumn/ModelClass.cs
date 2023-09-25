using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateColumn
{
    public class ModelClass
    {
        [Key]
        public int Id { get; set; }
        [Required]     
        public DateTime CreatedDate { get; set; }
    }
}

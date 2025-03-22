using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svetkavichko.Models
{
    public class Chore
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public bool IsDoneToday { get; set; } = false;
        public DateOnly DateDone {  get; set; }
    }
}

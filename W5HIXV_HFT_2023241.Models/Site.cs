using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5HIXV_HFT_2023241.Models
{
    [Table("Sites")]
    public class Site
    {
        [Key]
        public int Id { get; set; } 

        public string Name { get; set; }    

        public string Address { get; set; }

        [NotMapped]
        public virtual ICollection<Driver> Drivers { get; set; }

        [NotMapped]
        public virtual ICollection<Car> Cars { get; set;}
        
    }
}

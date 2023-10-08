using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5HIXV_HFT_2023241.Models
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string Plate {  get; set; }  

        public string Type { get; set; } 

        public string Brand { get; set; } 

        public int Total_Weith { get; set; }

        [ForeignKey(nameof(Driver))]
        public int DriverId { get; set; }

        [NotMapped]
        public virtual Driver Driver { get; set; }

        [NotMapped]
        public virtual Site Site { get; set; }  
    }
}

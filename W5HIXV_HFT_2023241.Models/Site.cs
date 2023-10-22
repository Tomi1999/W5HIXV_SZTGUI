using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace W5HIXV_HFT_2023241.Models
{
    [Table("Sites")]
    public class Site
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public string Size { get; set; }    

        public string Address { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual List<Driver> Drivers { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual List<Car> Cars { get; set;}
        
    }
}

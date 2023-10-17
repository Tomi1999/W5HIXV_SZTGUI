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
    [Table("Drivers")]
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }    

        public string Name { get; set; }

        public int Distance { get; set; }

        [ForeignKey(nameof(Site))]
        public int SiteId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Site Site { get; set; }  
    }
}

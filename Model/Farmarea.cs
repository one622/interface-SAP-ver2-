using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class Farmarea
    {
        [Key]
        public int my_location_id { get; set; }

        [Required]
        public string dataareaid { get; set; }
        public string my_location_name { get; set; }

        public string crop_year { get; set; }
    }
}

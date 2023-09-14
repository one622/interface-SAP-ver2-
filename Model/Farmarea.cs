using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class Farmarea
    {
        [Key]
        public int uid { get; set; }

        [Required]
        public string truckoil { get; set; }
        public int oilamoun { get; set; }
        public int approvestatus { get; set; }
        public string approver { get; set; }
        public DateTime transdate { get; set; }
         public string vehicle_code { get; set; }

        //[Key]

        // public int my_location_id { get; set; }
        // [Required]
        // public string dataareaid { get; set; }
        // public string my_location_name { get; set; }
        // public string crop_year { get; set; }
    }
}

using BookListRazor.Model;
using BookListRazor.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Pages
{
    public class IndexModel : PageModel
    {

        private IFarmareaRepository _db;
        public IndexModel(IFarmareaRepository db)
        {
            _db = db;
        }
        public void OnGet()
        {
            //Farmareas = await _db.LoadFarmarea.ToListAsync();
            Farmareas = _db.LoadFarmarea().ToList();
        }
        public IEnumerable<Farmarea> Farmareas { get; set; }
    }
}

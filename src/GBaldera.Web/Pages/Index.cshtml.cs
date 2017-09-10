using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GBaldera.Web.Models;

namespace GBaldera.Web.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if(ModelState.IsValid)
            {
                //
            }
        }
    }
}

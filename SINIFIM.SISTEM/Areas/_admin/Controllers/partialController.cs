using SINIFIM.SISTEM.Areas._admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SINIFIM.SISTEM.Areas._admin.Controllers
{
    public class partialController : Controller
    {
        // GET: _admin/partial
        public async Task<PartialViewResult> genelOzet()
        {
            GenelOzetModel result = await
                new
                Models.GenelOzetModel().GetOzetAsync();
            return PartialView(result);
        }
    }
}
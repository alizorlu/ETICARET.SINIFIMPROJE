using SINIFIM.DATABASE;
using SINIFIM.MODEL.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SINIFIM.SISTEM.Areas._admin.Controllers
{
    public class universityController : Controller
    {
        private UniverstyOperations uniOps { get; set; }
        public universityController() {
            uniOps = new UniverstyOperations();
        }
        // GET: _admin/university
        public async Task<ActionResult> operations()
        {
            List<UniversiteTB>
                allResult = await uniOps.GetAllUniverstyAsync();
            return View(allResult);
        }
        [HttpPost]
        public async Task<ActionResult> deleteUni(int id)
        {
           bool result= await uniOps.DeleteUniverstyAsync(id);
            if(result==true)
            {
                TempData["silme"] = "Universite silindi";
            }
            else if(result==false)
            {
                TempData["silme"] = "Silme hatalı";
            }
            return RedirectToAction("operations", "_admin/university");
        }
        public async Task<ActionResult> add()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> add(string uniadi)
        {
            UniversiteTB model = new UniversiteTB();
            model.universite = uniadi;
            var result = await uniOps.AddUniverstyAsync(model);
            return RedirectToAction("operations", "university");
            
        }
    }
}
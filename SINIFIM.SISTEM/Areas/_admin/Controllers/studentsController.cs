using SINIFIM.MODEL.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SINIFIM.SISTEM.Areas._admin.Controllers
{
    public class studentsController : Controller
    {
        //Ogrenci tablosuyla yapılabilecek operasyonlar....
        private OgrenciOperations ogrenciOps { get; set; }
        public studentsController()
        {
            ogrenciOps = new OgrenciOperations();
        }
        // GET: _admin/students
        public async Task<ActionResult> operations()
        {
            //Tüm öğrencilerin listelendiği view
            var allStudents = await ogrenciOps.GetAllOgrenciAsync();
            return View(allStudents.ToList());
        }
    }
}
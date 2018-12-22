using SINIFIM.MODEL.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SINIFIM.SISTEM.Areas._teacher.Controllers
{
    public class teacheroperationsController : Controller
    {
        private int varsayilanHocaid { get; set; }
        private HocalarOperations hocaOps { get; set; }
       
        // GET: _teacher/teacheroperations
       
        public async Task<ActionResult> virtualclassoperations()
        {
            //Sanal Sınıfların listesini belirtir.
            #region NOT!:HOCA GİRİŞ İŞLEMİ YAPILDIĞINDA BURASI DÜZELTİLECEK
            var ilkHocaBul = await hocaOps.GetAllArGorAsync();
            var hoca = ilkHocaBul.Find(sa => sa.id == varsayilanHocaid);
            if (hoca == null) return null;
            var allVClass = hoca.SanalSinifTB.ToList();
            #endregion
            return View(allVClass);
        }
    }
}
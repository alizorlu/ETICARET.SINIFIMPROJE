using SINIFIM.DATABASE;
using SINIFIM.MODEL.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SINIFIM.SISTEM.Areas._admin.Models
{
    public class GenelOzetModel
    {
        public int UniSayisi { get; set; } = 0;
        public int OgrSayisi { get; set; } = 0;
        public int HocaSayisi { get; set; } = 0;
        public int YoneticiSayisi { get; set; } = 0;

        private readonly AdminOperations adminOp;
        private readonly UniverstyOperations uniOp;
        public GenelOzetModel() {
            adminOp = new AdminOperations();
            uniOp = new UniverstyOperations();
        }
        public async Task<GenelOzetModel> GetOzetAsync()
        {
            GenelOzetModel genelOzet = new GenelOzetModel();
            var yonetSayisi = await adminOp.GetAllAdmins();
            var uniSayisi = await uniOp.GetAllUniverstyAsync();
            genelOzet.YoneticiSayisi = yonetSayisi.ToList().Count;
            genelOzet.UniSayisi = uniSayisi.Count;
            return genelOzet;
        }
    }
}
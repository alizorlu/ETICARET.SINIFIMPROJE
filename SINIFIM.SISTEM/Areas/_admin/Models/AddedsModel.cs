using SINIFIM.DATABASE;
using SINIFIM.MODEL.Models.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.WebPages.Html;
using System.Linq;
namespace SINIFIM.SISTEM.Areas._admin.Models
{
    /// <summary>
    /// Tüm Ekleme Modelleri Burada Çalışacak
    /// </summary>
    public class AddedsModel
    {
        public List<SelectListItem> uniList { get; set; }
        public ArgorTB argormodel { get; set; }
        public async Task<AddedsModel> getEklemeModel()
        {
            AddedsModel model = new AddedsModel();
            List<UniversiteTB> universiteTBs
                = await new UniverstyOperations().GetAllUniverstyAsync();
            model.uniList = (from x in universiteTBs
                             select new SelectListItem()
                             {
                                 Text = $"{x.universite.ToString()}",
                                 Value = x.id.ToString()
                             }).ToList();
            model.argormodel = new ArgorTB();
            return model;
        }
    }
}
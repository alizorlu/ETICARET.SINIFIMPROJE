using SINIFIM.DATABASE;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace SINIFIM.MODEL.Models.Admin
{
    public class UniverstyOperations
    {
        private SinifimCom_SinifimDB2018DBEntities db { get; set; }
        public UniverstyOperations() => db = new SinifimCom_SinifimDB2018DBEntities();
        public async Task<List<UniversiteTB>> GetAllUniverstyAsync()
        {
            return db.UniversiteTB.ToList();
        }
        public async Task<bool> AddUniverstyAsync(UniversiteTB model)
        {
            try
            {

                db.UniversiteTB.AddOrUpdate(model);
                await db.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
        public async Task<bool> DeleteUniverstyAsync(int id)
        {
            try
            {
                var findedUni
                        = await db.UniversiteTB.FindAsync(id);
                db.UniversiteTB.Remove(findedUni);
                db.Entry(findedUni).State = System.Data.Entity.EntityState.Deleted;
                await db.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
        public async Task<UniversiteTB> ReadUniAsync(int id)
        {

            var asd = db.UniversiteTB.Find(id);
            return asd;


        }
        public async Task<UniversiteTB> UpdateAsync(UniversiteTB model)
        {
            db.UniversiteTB.AddOrUpdate(model);
            db.SaveChangesAsync();

            return model;
        }
    }
}

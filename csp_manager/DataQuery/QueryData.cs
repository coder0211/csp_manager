using csp_manager.DataContext;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csp_manager.DataQuery
{
    //public class PlantTypeDTO
    //{
    //    public int pt_id { get; set; }
    //    public string pt_name { get; set; }
    //}
    class QueryData
    {
        public List<plant_type> GetPlantType()
        {
            using (var dbContext = new CSPDbModel())
            {
                return dbContext.plant_type.ToList();
            }
        }
        public bool PostPlant(plants plant, out string err)
        {
            err = string.Empty;
            try
            {
                using (var dbContext = new CSPDbModel())
                {
                    dbContext.plants.Add(plant);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
        }
    }
}

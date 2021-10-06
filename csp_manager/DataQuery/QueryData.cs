using csp_manager.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csp_manager.DataQuery
{
    class PlantTypeDTO
    {
        public int pt_id { get; set; }
        public string pt_name { get; set; }
    }
    class QueryData
    {
        public List<PlantTypeDTO> GetPlantType()
        {
            using (var dbContext = new CSPDbModel())
            {
                return (from pt in dbContext.plant_type
                        select new PlantTypeDTO()
                        {
                            pt_id = pt.pt_id,
                            pt_name = pt.pt_name
                        }).ToList();
            }
        }
    }
}

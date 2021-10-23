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
        public List<plants> GetPlants()
        {
            using (var dbContext = new CSPDbModel())
            {
                return dbContext.plants.ToList();
            }
        }
        public plants GetPlant(int plant_id, out string err)
        {
            err = string.Empty;
            try
            {
                using (var dbContext = new CSPDbModel())
                {
                    return dbContext.plants.SingleOrDefault(s => s.plant_id == plant_id);
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return null;
            }
        }
        public int PostPlant(plants plant, out string err)
        {
            err = string.Empty;
            try
            {
                using (var dbContext = new CSPDbModel())
                {
                    dbContext.plants.Add(plant);
                    dbContext.SaveChanges();
                    return plant.plant_id;
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return 0;
            }
        }
        public bool UpdatePlant(plants plant, out string err)
        {
            err = string.Empty;
            try
            {
                using (var dbContext = new CSPDbModel())
                {
                    var plantUpdate = dbContext.plants.SingleOrDefault(s => s.plant_id == plant.plant_id);
                    if (plantUpdate == null)
                    {
                        err = "Sản phẩm không tìm thấy!";
                        return false;
                    }
                    if (plantUpdate.plant_name != plant.plant_name) plantUpdate.plant_name = plant.plant_name;
                    if (plantUpdate.plant_img != plant.plant_img) plantUpdate.plant_img = plant.plant_img;
                    if (plantUpdate.plant_amount != plant.plant_amount) plantUpdate.plant_amount = plant.plant_amount;
                    if (plantUpdate.plant_unit != plant.plant_unit) plantUpdate.plant_unit = plant.plant_unit;
                    if (plantUpdate.plant_price != plant.plant_price) plantUpdate.plant_price = plant.plant_price;
                    if (plantUpdate.plant_note != plant.plant_note) plantUpdate.plant_note = plant.plant_note;
                    if (plantUpdate.plant_type_id != plant.plant_type_id) plantUpdate.plant_type_id = plant.plant_type_id;
                    if (plantUpdate.plant_supplier_name != plant.plant_supplier_name) plantUpdate.plant_supplier_name = plant.plant_supplier_name;
                    if (plantUpdate.plant_supplier_address != plant.plant_supplier_address) plantUpdate.plant_supplier_address = plant.plant_supplier_address;
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

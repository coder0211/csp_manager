using csp_manager.DataContext;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csp_manager.DataQuery
{
    class Plant_
    {
        public plants Plant { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
    public class Income
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Total { get; set; }
    }

    class QueryData
    {
        Func f = new Func();

        public bool TestConnect()
        {
            using (var dbContext = new CSPDbModel())
            {
                return dbContext.Database.Exists();
            }
        }

        // Hàm Login trả về: -1: Tài khoản không có / 0: Sai mật khẩu / >=1: Đăng nhập thành công!
        public int Login(string email, string pass)
        {
            string pass_md5 = f.CreateMD5(pass);
            using (var dbContext = new CSPDbModel())
            {
                users x = dbContext.users.SingleOrDefault(s => s.user_email == email);
                if (x == null) return -1;
                else
                {
                    if (x.user_password.Equals(pass_md5)) return x.user_id;
                    else return 0;
                }
            }
        }
        public int Reg(string fullname, string email, string pass, out string err)
        {
            err = string.Empty;
            try
            {
                using (var dbContext = new CSPDbModel())
                {
                    users x = dbContext.users.SingleOrDefault(s => s.user_email == email);
                    if (x == null)
                    {
                        x = new users();
                        x.user_fullname = fullname.ToLower();
                        x.user_email = email.ToLower();
                        x.user_password = f.CreateMD5(pass);
                        x.user_created_at = DateTime.Now;
                        dbContext.users.Add(x);
                        dbContext.SaveChanges();
                        return x.user_id;
                    }
                    else
                    {
                        err = "Email đã tồn tại!";
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return -1;
            }
        }
        public bool ChangePass(int user_id, string pass_old, string pass_new, out string err)
        {
            err = string.Empty;
            try
            {
                string pass_md5 = f.CreateMD5(pass_old);
                string pass_md5_ = f.CreateMD5(pass_new);
                using (var dbContext = new CSPDbModel())
                {
                    users x = dbContext.users.SingleOrDefault(s => s.user_id == user_id);
                    if (x == null)
                    {
                        err = "Tài khoản không tìm thấy!";
                        return false;
                    }
                    else
                    {
                        if (x.user_password.Equals(pass_md5))
                        {
                            x.user_password = pass_md5_;
                            dbContext.SaveChanges();
                            return true;

                        }
                        else
                        {
                            err = "Mật khẩu cũ không chính xác!";
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
        }

        public List<plant_type> GetPlantType()
        {
            using (var dbContext = new CSPDbModel())
            {
                return dbContext.plant_type.ToList();
            }
        }
        //public List<plants> GetPlants()
        //{
        //    using (var dbContext = new CSPDbModel())
        //    {
        //        return dbContext.plants.ToList();
        //    }
        //}
        public List<plants> GetPlants(string search = "")
        {
            using (var dbContext = new CSPDbModel())
            {
                if (string.IsNullOrEmpty(search)) return dbContext.plants.ToList();
                else return dbContext.plants.Where(oh => oh.plant_name.ToLower().Contains(search.ToLower())).ToList();
            }
        }
        public List<Plant_> GetPlantsWithSold()
        {
            return null;
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
        public bool DeletePlant(int plant_id)
        {
            using (var dbContext = new CSPDbModel())
            {
                var p = dbContext.plants.SingleOrDefault(s => s.plant_id == plant_id);
                if (p != null)
                {
                    dbContext.plants.Remove(p);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<invoices> GetInvoices()
        {
            using (var dbContext = new CSPDbModel())
            {
                return dbContext.invoices.ToList();
            }
        }
        public List<invoices> GetInvoices(int year)
        {
            using (var dbContext = new CSPDbModel())
            {
                return dbContext.invoices.Where(w => w.invoice_created_at.Year == year).ToList();
            }
        }
        public List<invoices> GetInvoices(int year, int month)
        {
            using (var dbContext = new CSPDbModel())
            {
                return dbContext.invoices.Where(w => w.invoice_created_at.Year == year && w.invoice_created_at.Month == month).ToList();
            }
        }
        public List<invoices> GetInvoices(int year, int month, int day)
        {
            using (var dbContext = new CSPDbModel())
            {
                return dbContext.invoices.Where(w => w.invoice_created_at.Year == year && w.invoice_created_at.Month == month && w.invoice_created_at.Day == day).ToList();
            }
        }
        public invoices GetInvoice(int invoice_id, out string err)
        {
            err = string.Empty;
            try
            {
                using (var dbContext = new CSPDbModel())
                {
                    return dbContext.invoices.SingleOrDefault(s => s.invoice_id == invoice_id);
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return null;
            }
        }
        public int PostInvoice(invoices invoice, out string err)
        {
            err = string.Empty;
            try
            {
                using (var dbContext = new CSPDbModel())
                {
                    dbContext.invoices.Add(invoice);
                    dbContext.SaveChanges();
                    return invoice.invoice_id;
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return 0;
            }
        }
        public List<invoice_details> GetInvoiceDetails()
        {
            using (var dbContext = new CSPDbModel())
            {
                return dbContext.invoice_details.ToList();
            }
        }
        public List<invoice_details> GetInvoiceDetails(int invoice_id)
        {
            using (var dbContext = new CSPDbModel())
            {
                return dbContext.invoice_details.Where(w => w.invoice_id == invoice_id).ToList();
            }
        }
        public bool PostInvoiceDetail(invoice_details invoice_detail, out string err)
        {
            err = string.Empty;
            try
            {
                using (var dbContext = new CSPDbModel())
                {
                    dbContext.invoice_details.Add(invoice_detail);
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

        public int GetIncomes(int year)
        {
            using (var dbContext = new CSPDbModel())
            {
                return dbContext.invoices.Where(s => s.invoice_created_at.Year == year).Distinct().Sum(r => r.invoice_total);
            }
        }
        public int GetIncomes(int year, int month)
        {
            try
            {
                using (var dbContext = new CSPDbModel())
                {
                    return dbContext.invoices.Where(s => s.invoice_created_at.Year == year && s.invoice_created_at.Month == month).Distinct().Sum(r => r.invoice_total);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int GetQuantitySold(int plant_id)
        {
            try
            {
                using (var dbContext = new CSPDbModel())
                {
                    return dbContext.invoice_details.Where(s => s.plant_id == plant_id).Distinct().Sum(r => r.plant_amount);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
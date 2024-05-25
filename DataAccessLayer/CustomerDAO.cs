using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class CustomerDAO
    {
        public static List<Customer> GetCustomers()
        {
            var listCustomers = new List<Customer>();
            try
            {
                using var db = new FuminiHotelManagementContext();
                listCustomers = db.Customers.ToList();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCustomers;
        }

        public static void SaveCustomer(Customer c)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Customers.Add(c);
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateCustomer(Customer c)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Entry<Customer>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCustomer(Customer c)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                var c1 = context.Customers.SingleOrDefault(x => x.CustomerId == c.CustomerId);
                context.Customers.Remove(c);
                context.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Customer GetCustomerById(int id)
        {
            using var context = new FuminiHotelManagementContext();
            return context.Customers.FirstOrDefault(x => x.CustomerId.Equals(id));
        }

    }
}

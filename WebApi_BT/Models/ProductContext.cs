﻿using MySql.Data.MySqlClient;

namespace WebApi_BT.Models
{
    public class ProductContext : IProductContext
    {
        public ProductResponse Add(Product item)
        {
            ProductResponse response = new ProductResponse();
            SqlManager sql = new SqlManager();
            if (!sql.Connect("server=gsw.dnsalias.net;uid=brandtransparency;" +
                             "pwd=db23/M3rm2EA;database=brandtransparency"))
            {
                Console.WriteLine("Failed to connect to the database!");
            }
            Console.WriteLine("Connect to the database was successful.\n");
            int i = sql.ExecuteQuery("INSERT INTO brandtransparency " + " VALUES (1, 'Pelle' )");
            if (i < 0)
            {
                response.Status = false;
                response.Error = new Error { ErrorMessage = "Unable to save the record. Please try again." };
            }
            else
            {
                response.Status = true;
            }
            return response;
        }

        public ProductResponse Get(int id)
        {
            ProductResponse response = new ProductResponse();
            Product product = new Product();
            SqlManager sql = new SqlManager();
            if (!sql.Connect("server=gsw.dnsalias.net;uid=brandtransparency;" +
                             "pwd=db23/M3rm2EA;database=brandtransparency"))
            {
                Console.WriteLine("Failed to connect to the database!");
            }
            Console.WriteLine("Connect to the database was successful.\n");
            response.Product = new Product();
            try
            {
                MySqlCommand cmd = sql.GetSqlCommand("SELECT * FROM brandtransparency where BarCode='" + id + "'");

                sql.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product = new Product();
                        product.BarCode = reader.GetString(1);
                        product.Marks = reader.GetString(0);
                        product.Description = reader.GetString(1);
                        product.Origin = reader.GetString(1);
                        product.Manufacturer = reader.GetString(1);
                        product.Product_Name = reader.GetString(1);
                        product.Co2 = reader.GetString(1);
                        product.Index = reader.GetInt32(1);
                    }
                }
                response.Product = product;
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false; response.Error = new Error { ErrorMessage = "Unable to retrieve the records." + ex.Message };
            }

            return response;
        }

        public ProductResponse GetAll()
        {
            ProductResponse response = new ProductResponse();
            Product product = new Product();
            List<Product> products = new List<Product>();
            SqlManager sql = new SqlManager();
            if (!sql.Connect("server=gsw.dnsalias.net;uid=brandtransparency;" +
                             "pwd=db23/M3rm2EA;database=brandtransparency"))
            {
                Console.WriteLine("Failed to connect to the database!");
            }
            Console.WriteLine("Connect to the database was successful.\n");
            response.Products = new List<Product>();
            try
            {
                MySqlCommand cmd = sql.GetSqlCommand("SELECT * FROM brandtransparency");

                sql.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product = new Product();
                        product.BarCode = reader.GetString("BarCode");
                        product.Marks = reader.GetString("Marks");
                        product.Description = reader.GetString("Description");
                        product.Origin = reader.GetString("Origin");
                        product.Manufacturer = reader.GetString("Manufacturer");
                        product.Product_Name = reader.GetString("Product_Name");
                        product.Co2 = reader.GetString("Co2");
                        product.Index = reader.GetInt32("Index");
                        products.Add(product);
                    }
                }
                response.Products = products;
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false; response.Error = new Error { ErrorMessage = "Unable to retrieve the records." + ex.Message };
            }

            return response;
        }

        public ProductResponse Remove(int id)
        {
            ProductResponse response = new ProductResponse();
            SqlManager sql = new SqlManager();
            if (!sql.Connect("server=gsw.dnsalias.net;uid=brandtransparency;" +
                             "pwd=db23/M3rm2EA;database=brandtransparency"))
            {
                Console.WriteLine("Failed to connect to the database!");
            }
            Console.WriteLine("Connect to the database was successful.\n");
            int i = sql.ExecuteQuery("DELETE FROM brandtransparency where index=" + id);
            if (i < 0)
            {
                response.Status = false;
                response.Error = new Error { ErrorMessage = "Unable to delete the record. Please try again." };
            }
            else
            {
                response.Status = true;
            }
            return response;
        }

        public ProductResponse Update(Product item)
        {
            ProductResponse response = new ProductResponse();
            SqlManager sql = new SqlManager();
            if (!sql.Connect("server=gsw.dnsalias.net;uid=brandtransparency;" +
                             "pwd=db23/M3rm2EA;database=brandtransparency"))
            {
                Console.WriteLine("Failed to connect to the database!");
            }
            Console.WriteLine("Connect to the database was successful.\n");
            int i = sql.ExecuteQuery("Update brandtransparency set Product_Name=" + item.Product_Name + ",BarCode='" + item.BarCode + "',Co2=" + item.Co2 + ",Description='" + item.Description + "',Marks=" + item.Marks + ",Manufacturer='" + item.Manufacturer + "',Origin='" + item.Origin + "' where index=" + item.Index);
            if (i < 0)
            {
                response.Status = false;
                response.Error = new Error { ErrorMessage = "Unable to update the record. Please try again." };
            }
            else
            {
                response.Status =true;
            }
            return response;
        }
    }
}

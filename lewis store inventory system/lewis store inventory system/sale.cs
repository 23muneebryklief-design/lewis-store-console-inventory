using Microsoft.Data.SqlClient;
using N_Product;
using System.Collections;

namespace N_Sale { 

public class Sale
{
    public int SaleID { get; set; }
    public int ProductID { get; set; }
    public int QuantitySold { get; set; }
    public decimal Subtotal { get; set; }
    public decimal VATAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime SaleDate { get; set; }

    string connectionString = "Data Source=RPS-SD;Initial Catalog=LewisStoreDB;Integrated Security=True;Trust Server Certificate=True"; //connection string for DB connection

        //method to insert
        public void InsertSale(int productId, int quantity, decimal subtotal, decimal vat, decimal total)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Sales 
                        (ProductID, QuantitySold, Subtotal, VATAmount, TotalAmount, SaleDate)
                        VALUES (@pid, @qty, @sub, @vat, @total, @date)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@pid", productId);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@sub", subtotal);
                cmd.Parameters.AddWithValue("@vat", vat);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        //selling product method
        public void SellProduct(int productId, int quantity)
        {
            Product productDb = new Product();
            Product product = productDb.GetProductById(productId);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            if (quantity <= 0 || quantity > product.QuantityInStock)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            decimal subtotal = product.PriceExcludingVAT * quantity;
            decimal vat = subtotal * 0.15m;
            decimal total = subtotal + vat;

            InsertSale(productId, quantity, subtotal, vat, total);

            productDb.UpdateStock(productId, product.QuantityInStock - quantity);

            Console.WriteLine("Sale completed successfully!");
        }



    }
}

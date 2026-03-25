using Microsoft.Data.SqlClient;

namespace N_Product
{

    //
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal PriceExcludingVAT { get; set; }
        public int QuantityInStock { get; set; }

        string connectionString = "Data Source=RPS-SD;Initial Catalog=LewisStoreDB;Integrated Security=True;Trust Server Certificate=True";

        //add product method
        public void AddProduct(Product product)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Products VALUES (@name, @desc, @price, @qty)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", product.ProductName);
                cmd.Parameters.AddWithValue("@desc", product.Description);
                cmd.Parameters.AddWithValue("@price", product.PriceExcludingVAT);
                cmd.Parameters.AddWithValue("@qty", product.QuantityInStock);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //get by id method
        public Product GetProductById(int productId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products WHERE ProductID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", productId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Product
                    {
                        ProductID = (int)reader["ProductID"],
                        ProductName = reader["ProductName"].ToString(),
                        Description = reader["Description"].ToString(),
                        PriceExcludingVAT = (decimal)reader["PriceExcludingVAT"],
                        QuantityInStock = (int)reader["QuantityInStock"]
                    };
                }
            }

            return null;
        }


        //update stock method
        public void UpdateStock(int productId, int newQuantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET QuantityInStock = @qty WHERE ProductID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@qty", newQuantity);
                cmd.Parameters.AddWithValue("@id", productId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //VIEW STOCK METHOD
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product
                    {
                        ProductID = (int)reader["ProductID"],
                        ProductName = reader["ProductName"].ToString(),
                        Description = reader["Description"].ToString(),
                        PriceExcludingVAT = (decimal)reader["PriceExcludingVAT"],
                        QuantityInStock = (int)reader["QuantityInStock"]
                    };

                    products.Add(p);
                }
            }

            return products;
        }
        public void DeleteProduct(int productId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Products WHERE ProductID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", productId);

                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Product deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Assessment3
{
    internal class Program
    {
        static void Main()
        {
            string connectionString = "Data Source=DESKTOP-1SI2RLO\\SQLEXPRESS;Initial Catalog=Assessment3;Integrated Security=true;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("InsertProductDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductName", "iphone 16");
                    cmd.Parameters.AddWithValue("@Price",95000);

                    SqlParameter productIdParam = new SqlParameter("@GeneratedProductId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(productIdParam);

                    SqlParameter discountedPriceParam = new SqlParameter("@DiscountedPrice", SqlDbType.Decimal)
                    {
                        Precision = 10,
                        Scale = 2,
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(discountedPriceParam);

                    cmd.ExecuteNonQuery();

                    int generatedProductId = (int)productIdParam.Value;
                    decimal discountedPrice = (decimal)discountedPriceParam.Value;

                    Console.WriteLine($"Generated ProductId: {generatedProductId}");
                    Console.WriteLine($"Discounted Price: {discountedPrice}");

                    Console.Read();
                }
            }
        }
    
    }
}

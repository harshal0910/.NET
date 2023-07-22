using BOL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DBManager
    {
        public static string conString = @"server=localhost;port=3306;user=root; password=root123;database=dotnetproj";

        public static List<Product> getAllProducts()
        {
            List<Product> products = new List<Product>();
            MySqlConnection con=new MySqlConnection();

            con.ConnectionString = conString;

            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                string query = "Select * from Products";
                cmd.CommandText = query;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Name = reader["name"].ToString(),
                        Description = reader["description"].ToString(),
                        category = Enum.Parse<Category>(reader["category"].ToString()),
                        price = double.Parse(reader["price"].ToString()),
                        mfgDate = DateOnly.FromDateTime(DateTime.Parse(reader["mfgDate"].ToString()))
                    };
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { con.Close(); }
            return products;
        }


        public static void addNewProduct(Product product)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(); 
                cmd.Connection = con;
                string query = "insert into products values('" + product.Id + "','"+product.Name+"','"+product.Description+"','"+product.category+"','"+product.price+"','"+ product.mfgDate.ToString("yyyy-MM-dd") + "')";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) { 
            Console.WriteLine(ex.Message);  }
            finally { con.Close(); }
        }


    }
}
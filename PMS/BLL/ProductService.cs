using BOL;
using DAL;

namespace BLL
{
    public class ProductService
    {

        public static List<Product> getAllProdList()
        {
            return DBManager.getAllProducts();
        }
        public static void addNewProduct(Product product)
        {
            DBManager.addNewProduct(product);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Web_API.Pages.Customer
{
    public class IndexModel : PageModel
    {
        public List<CustomerInfo> listCustomer = new List<CustomerInfo>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=DESKTOP-3N94N7M;Initial Catalog=WebAPI_DB;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM customers";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerInfo customerInfo = new CustomerInfo();
                                customerInfo.id = "" + reader.GetInt32(0);
                                customerInfo.name = reader.GetString(1);
                                customerInfo.address = reader.GetString(2);
                                customerInfo.phone = reader.GetString(3);
                                customerInfo.email = reader.GetString(4);

                                listCustomer.Add(customerInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class CustomerInfo
    {
        public String id;
        public String name;
        public String address;
        public String phone;
        public String email;
    }
}

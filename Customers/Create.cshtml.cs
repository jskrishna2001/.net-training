using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Web_API.Pages.Customer
{
    public class CreateModel : PageModel
    {
        public CustomerInfo customerInfo = new CustomerInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            customerInfo.name = Request.Form["name"];
            customerInfo.address = Request.Form["address"];
            customerInfo.phone = Request.Form["phone"];
            customerInfo.email = Request.Form["email"];
            
            

            if(customerInfo.name.Length == 0 || customerInfo.email.Length == 0 || 
                customerInfo.phone.Length == 0 || customerInfo.address.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            try
            {
                String connectionString = "Data Source=DESKTOP-3N94N7M;Initial Catalog=WebAPI_DB;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO customers " +
                                 " (name, address, phone, email) VALUES " +
                                 "(@name, @address, @phone, @email);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", customerInfo.name);
                        command.Parameters.AddWithValue("@address", customerInfo.address);
                        command.Parameters.AddWithValue("@phone", customerInfo.phone); 
                        command.Parameters.AddWithValue("@email", customerInfo.email);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            customerInfo.name = ""; customerInfo.address = ""; customerInfo.phone = "";  customerInfo.email = "";
            successMessage = "New customer added correctly";

            Response.Redirect("/Customers/Index");
        }
    }
}

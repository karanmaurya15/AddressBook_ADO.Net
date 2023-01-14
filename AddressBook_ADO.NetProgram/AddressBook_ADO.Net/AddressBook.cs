using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ADO.Net
{
    public class AddressBook
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBook;";
        public string AddContactInDB(AddressBookModle addresBook)
        {
            SqlConnection sQLConnection = new SqlConnection(connectionString);
            try
            {
                using (sQLConnection)
                {
                    sQLConnection.Open();
                    SqlCommand command = new SqlCommand("SPAddNewContact", sQLConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName",addresBook.FirstName);
                    command.Parameters.AddWithValue("@LastName", addresBook.LastName);
                    command.Parameters.AddWithValue("@Address", addresBook.Address);
                    command.Parameters.AddWithValue("@City", addresBook.City);
                    command.Parameters.AddWithValue("@State", addresBook.State);
                    command.Parameters.AddWithValue("@Zip", addresBook.Zip);
                    command.Parameters.AddWithValue("@PhoneNumber", addresBook.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", addresBook.Email);
                    command.Parameters.AddWithValue("@AdressBookName", addresBook.AdressBookName);
                    command.Parameters.AddWithValue("@Type", addresBook.Type);
                    int result = command.ExecuteNonQuery();
                    sQLConnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Contact Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No Data found");
                    }
                }
                return "Contact Added Successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}

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
        public string RetriveData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                List <AddressBookModle> contact = new List<AddressBookModle>();
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("SPRetrieveAllDetails", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader obj = command.ExecuteReader();
                    if (obj.HasRows)
                    {
                        while (obj.Read())
                        {
                            AddressBookModle contactItem = new AddressBookModle();
                            contactItem.FirstName = obj.GetString(0);
                            contactItem.LastName = obj.GetString(1);
                            contactItem.Address = obj.GetString(2);
                            contactItem.City = obj.GetString(3);
                            contactItem.State = obj.GetString(4);
                            contactItem.Zip = obj.GetInt32(5);
                            contactItem.PhoneNumber = obj.GetInt64(6);
                            contactItem.Email = obj.GetString(7);
                            contactItem.AdressBookName = obj.GetString(8);
                            contactItem.Type = obj.GetString(9);
                            contact.Add(contactItem);
                        }
                        Console.WriteLine("FirstName" + " " + "LastName" + "  " + "Address" + "  " + "City" + "  " + "State" + "  " + "Zip" + " " + "PhoneNumber" + " " + "Email" + " " + "AdressbookName" + " " + "Type");
                        foreach (var data in contact)
                        {
                            Console.WriteLine(data.FirstName + ", " + data.LastName + ", " + data.Address + ", " + data.City + ", " + data.State + ",  " + data.Zip + ", " + data.PhoneNumber + ",  " + data.Email + ", " + data.AdressBookName + " " + data.Type);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Database Found");
                    }
                }
                return "Retrive Data Successfull";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return string.Empty;
        }
        public string UpdateContactInDB(AddressBookModle addresBook)
        {
            SqlConnection sQLConnection = new SqlConnection(connectionString);
            try
            {
                using (sQLConnection)
                {
                    sQLConnection.Open();
                    SqlCommand command = new SqlCommand("SPUpdateDataInDB", sQLConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SurName", addresBook.LastName);
                    command.Parameters.AddWithValue("@Mobile", addresBook.PhoneNumber);
                    command.Parameters.AddWithValue("@TypeOfAddressBook", addresBook.Type);
                    int result = command.ExecuteNonQuery();
                    sQLConnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Contact Updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No Data found");
                    }
                }
                return "Contact Updated Successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return string.Empty;
        }
        public string DeleteContactInDB(string lastname)
        {
            SqlConnection sQLConnection = new SqlConnection(connectionString);
            try
            {
                using (sQLConnection)
                {
                    sQLConnection.Open();
                    SqlCommand command = new SqlCommand("SPDeleteDataFromDB", sQLConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LastName",lastname);
                    int result = command.ExecuteNonQuery();
                    sQLConnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Contact Deleted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No Data found");
                    }
                }
                return "Contact Deleted Successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return string.Empty;
        }
    }
}

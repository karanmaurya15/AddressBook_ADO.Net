namespace AddressBook_ADO.Net;

internal class Program
{
    static void Main(string[] args)
    {
        AddressBook addressBook = new AddressBook();
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("Enter : 1.Add Contact in Database \n 2.Retrive Data \n 3.UpdateData \n 4.Exit : ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    AddressBookModle addressBookModle = new AddressBookModle()
                    {
                        FirstName = "Irbaz",
                        LastName = "Patel",
                        Address = "Place",
                        City = "Citis",
                        State = "Hindustan",
                        Zip = 56789,
                        PhoneNumber = 89675432367,
                        Email = "ip@xx.com",
                        AdressBookName = "Bookname",
                        Type = "Friends"
                    };
                    addressBook.AddContactInDB(addressBookModle);
                    break;
                case 2:
                    addressBook.RetriveData();
                    break;
                case 3:
                    AddressBookModle addressBookModles = new AddressBookModle()
                    {
                        FirstName = "Karan",
                        LastName = "Maurya",
                        Address = "India",
                        Type = "Permanent"
                    };
                    addressBook.UpdateContactInDB(addressBookModles);
                    break;
                case 4:
                    flag = false;
                    break;
            }
        }
    }
}
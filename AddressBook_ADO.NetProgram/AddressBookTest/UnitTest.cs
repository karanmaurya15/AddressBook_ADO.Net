using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.X86;
using AddressBook_ADO.Net;

namespace AddressBookTest
{
    [TestClass]
    public class UnitTest
    {
        AddressBook addressBook = new AddressBook();
        [TestMethod]
        public void TestAddContactInDB()
        {
            AddressBookModle contact = new AddressBookModle()
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
            string result = addressBook.AddContactInDB(contact);
            Assert.AreEqual("Contact Added Successfully", result);
        }
        [TestMethod]
        public void TestRetriveData()
        {
            string result = addressBook.RetriveData();
            Assert.AreEqual("Retrive Data Successfull", result);
        }
        [TestMethod]
        public void TestUpdatedata()
        {
            AddressBookModle addressBookModles = new AddressBookModle()
            {
                FirstName = "Karan",
                LastName = "Maurya",
                Address = "India",
                Type = "Perament"
            };
            string result = addressBook.UpdateContactInDB(addressBookModles);
            Assert.AreEqual("Contact Updated Successfully", result);
        }
        [TestMethod]
        public void TestDeleteData()
        {
            string result = addressBook.DeleteContactInDB("kk");
            Assert.AreEqual("Contact Deleted Successfully", result);
        }
    }
}
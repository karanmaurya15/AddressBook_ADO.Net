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
                FirstName = "KK",
                LastName = "Dok",
                Address = "1236St",
                City = "AnyCity",
                State = "US",
                Zip = 12345,
                PhoneNumber = 9877656434,
                Email = "jon@gmail.com",
                AdressBookName = "My AddressBook",
                Type = "Personalls"
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
            string result =  addressBook.UpdateContactInDB(addressBookModles);
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
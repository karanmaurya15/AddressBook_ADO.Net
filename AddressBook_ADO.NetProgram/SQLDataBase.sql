--Create
CREATE PROCEDURE SPAddNewContact(
@FirstName varchar(30),
@LastName VARCHAR(30),
@Address varchar(50),
@City varchar(40),
@State varchar(30),
@Zip int,
@PhoneNumber bigint,
@Email varchar(100),
@AdressBookName varchar(50),
@Type varchar(50)
)
AS BEGIN
INSERT INTO Address_Book_Table  VALUES(@FirstName,@LastName,@Address,@City,@State,@Zip,@PhoneNumber,@Email,@AdressBookName,@Type)
END

--Retrive
CREATE PROCEDURE SPRetrieveAllDetails
AS BEGIN 
SELECT * FROM Address_Book_Table
END

--Update
CREATE PROCEDURE SPUpdateDataInDB(
@SurName VARCHAR(30),
@TypeOfAddressBook VARCHAR(30),
@Mobile bigint
)
AS BEGIN
UPDATE Address_Book_Table SET Type = @TypeOfAddressBook, PhoneNumber = @Mobile WHERE LastName = @SurName
END

--Delete
CREATE PROCEDURE SPDeleteDataFromDB(
@LastName VARCHAR(30)
)
AS BEGIN
DELETE FROM Address_Book_Table WHERE LastName =@LastName
END

Select * From Address_Book_Table
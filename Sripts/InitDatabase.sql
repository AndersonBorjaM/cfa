CREATE TABLE Client(
ClientId INT IDENTITY(1,1) PRIMARY KEY,
DocumentType VARCHAR(2) NOT NULL,
Document BIGINT NOT NULL,
Name VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
LastName2 VARCHAR(30) NULL,
Gender VARCHAR(2) NOT NULL,
DateOfBirth DATE NOT NULL,
Email VARCHAR(250) NOT NULL
)

CREATE TABLE Address(
AddressId INT IDENTITY(1,1) PRIMARY KEY,
ClientId INT FOREIGN KEY REFERENCES Client(ClientId) NOT NULL,
AddressText VARCHAR(MAX) NOT NULL,
AddressType VARCHAR(250) NOT NULL
)

CREATE TABLE Phone(
PhoneId INT IDENTITY(1,1) PRIMARY KEY,
ClientId INT FOREIGN KEY REFERENCES Client(ClientId) NOT NULL,
PhoneType VARCHAR(250) NOT NULL,
PhoneNumber BIGINT NOT NULL
)

CREATE PROCEDURE SP_GetAddressClient 
AS
BEGIN
    SELECT CONCAT(CL.Name,' ', CL.LastName, ' ', CL.LastName2) FullName, AD.AddressText 
	FROM Client AS CL
	LEFT JOIN 
        (SELECT 
             ClientId,
             AddressText,
             ROW_NUMBER() OVER (PARTITION BY ClientId ORDER BY AddressId ASC) AS RowNum
         FROM 
             Address
        ) AD
	ON AD.ClientId = CL.ClientId AND  AD.RowNum = 1
	WHERE (SELECT COUNT(AddressId) FROM Address WHERE ClientId = CL.ClientId) >1
END;
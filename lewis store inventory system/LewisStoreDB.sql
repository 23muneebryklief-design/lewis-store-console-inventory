CREATE DATABASE LewisStoreDB;
GO
USE LewisStoreDB;

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    Description VARCHAR(255),
    PriceExcludingVAT DECIMAL(10,2) NOT NULL,
    QuantityInStock INT NOT NULL
);

CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT,
    QuantitySold INT NOT NULL,
    Subtotal DECIMAL(10,2),
    VATAmount DECIMAL(10,2),
    TotalAmount DECIMAL(10,2),
    SaleDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

select * from Products;
select * from Sales;


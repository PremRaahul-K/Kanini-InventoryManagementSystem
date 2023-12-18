-- Create Database
CREATE DATABASE InventoryManagementSystem;
GO

-- Use the Database
USE InventoryManagementSystem;
GO

-- Create Products Table
CREATE TABLE Products
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Quantity INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL
);
GO

-- Insert Sample Data
INSERT INTO Products (Name, Description, Quantity, Price) VALUES
('Product1', 'Description for Product1', 50, 19.99),
('Product2', 'Description for Product2', 30, 29.99),
('Product3', 'Description for Product3', 20, 39.99),
('Product4', 'Description for Product4', 10, 49.99);
GO



CREATE TABLE Users
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(255) NOT NULL UNIQUE,
    PasswordHash VARBINARY(MAX) NOT NULL,
    PasswordKey VARBINARY(MAX) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);
GO

select * from products;
GO
select *  from users;

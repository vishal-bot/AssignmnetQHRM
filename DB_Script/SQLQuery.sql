/****** Creating Database ******/
create database products1;
use products1;

/****** Object:  Creating Table [dbo].[Product] ******/
CREATE TABLE [dbo].[Product](
	[Id] [int] Primary Key IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Quantity] [int] NULL,
)

/****** Object:  StoredProcedure [dbo].[ProductViewByID] ******/
GO
CREATE PROC [dbo].[ProductViewByID]

@Id int

AS

Select * from Product
Where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[ProductViewAll] ******/
GO
CREATE PROC [dbo].[ProductViewAll]

As

Select * from Product
GO
/****** Object:  StoredProcedure [dbo].[ProductDeleteByID] ******/
GO
CREATE PROC [dbo].[ProductDeleteByID]
@Id int

AS

Delete from Product
Where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[ProductAddOrEdit] ******/
GO
CREATE PROC [dbo].[ProductAddOrEdit]
@Id int,
@ProductName varchar(50),
@Description varchar(50),
@Quantity int

As 

IF (@Id = 0 )
	INSERT INTO Product (ProductName,Description,Quantity)
	VALUES (@ProductName,@Description,@Quantity)

ELSE
	UPDATE Product
	SET 
	ProductName = @ProductName,
	Description = @Description,
	Quantity= @Quantity
	WHERE Id = @Id
GO

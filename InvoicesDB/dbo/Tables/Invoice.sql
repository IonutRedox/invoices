CREATE TABLE [dbo].[Invoice]
(
	[Id] INT IDENTITY,
	[InvoiceId] INT,
	[LocationId] INT,
	[InvoiceNumber] NVARCHAR(50),
	[Date] DATE,
	[ClientName] NVARCHAR(50),
	PRIMARY KEY (InvoiceId, LocationId)
)

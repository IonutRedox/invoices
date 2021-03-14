CREATE TABLE [dbo].[InvoiceDetails]
(
	[Id] INT IDENTITY,
	[InvoiceDetailsId] INT,
	[LocationId] INT,
	[InvoiceId] INT,
	[ProductName] NVARCHAR(50),
	[Quantity] DECIMAL,
	[Price] DECIMAL,
	[Value] DECIMAL,
	PRIMARY KEY (InvoiceDetailsId, LocationId),
	FOREIGN KEY (InvoiceId,LocationId) REFERENCES Invoice(InvoiceId,LocationId) ON UPDATE CASCADE ON DELETE CASCADE
)

using InvoicesDataLIbrary.DataAccess;
using InvoicesDataLIbrary.Models;
using System;
using System.Collections.Generic;

namespace InvoicesDataLIbrary.BusinessLogic
{
    public static class InvoiceProcessor
    {
        public static int CreateInvoice(int invoiceId, int locationId, string invoiceNumber, DateTime date, string clientName)
        {
            InvoiceModel invoice = new InvoiceModel
            {
                InvoiceId = invoiceId,
                LocationId = locationId,
                InvoiceNumber = invoiceNumber,
                Date = date,
                ClientName = clientName
            };

            string sql = @"INSERT INTO dbo.Invoice (InvoiceId, LocationId, InvoiceNumber, Date, ClientName)
                           VALUES (@InvoiceId, @LocationId, @InvoiceNumber, @Date, @ClientName)";

            return SqlDataAccess<InvoiceModel>.SaveData(sql, invoice);
        }

        public static int CreateInvoiceDetail(int invoiceDetailsId, int invoiceId, int locationId, string productName, decimal quantity, decimal price, decimal value)
        {
            InvoiceDetailsModel invoiceDetails = new InvoiceDetailsModel
            {
                InvoiceDetailsId = invoiceDetailsId,
                InvoiceId = invoiceId,
                LocationId = locationId,
                ProductName = productName,
                Price = price,
                Quantity = quantity,
                Value = value
            };

            string sql = @"INSERT INTO dbo.InvoiceDetails (InvoiceDetailsId, InvoiceId, LocationId, ProductName, Price, Quantity, Value)
                           VALUES (@InvoiceDetailsId, @InvoiceId, @LocationId, @ProductName, @Price, @Quantity, @Value)";

            return SqlDataAccess<InvoiceDetailsModel>.SaveData(sql, invoiceDetails);
        }

        public static List<InvoiceModel> LoadInvoices()
        {
            string sql = @"SELECT InvoiceId, LocationId, InvoiceNumber, Date, ClientName FROM dbo.Invoice";

            return SqlDataAccess<InvoiceModel>.LoadData(sql);
        }

        public static List<InvoiceDetailsModel> LoadInvoiceDetails()
        {
            string sql = @"SELECT InvoiceDetailsId, InvoiceId, LocationId, ProductName, Price, Quantity, Value FROM dbo.InvoiceDetails";

            return SqlDataAccess<InvoiceDetailsModel>.LoadData(sql);
        }

        public static int UpdateInvoice(int invoiceId, int locationId, string invoiceNumber, DateTime date, string clientName)
        {
            InvoiceModel invoice = new InvoiceModel
            {
                InvoiceId = invoiceId,
                LocationId = locationId,
                InvoiceNumber = invoiceNumber,
                Date = date,
                ClientName = clientName
            };

            string sql = @"UPDATE dbo.Invoice 
                           SET InvoiceId = @InvoiceId,
                               LocationId = @LocationId,
                               InvoiceNumber = @InvoiceNumber,
                               Date = @Date,
                               ClientName = @ClientName
                           WHERE InvoiceId = @InvoiceId AND LocationId = @LocationId";


           return SqlDataAccess<InvoiceModel>.SaveData(sql, invoice);
        }

        public static int UpdateInvoiceDetails(int invoiceDetailsId, int invoiceId, int locationId, string productName, decimal quantity, decimal price, decimal value)
        {
            InvoiceDetailsModel invoiceDetails = new InvoiceDetailsModel
            {
                InvoiceDetailsId = invoiceDetailsId,
                InvoiceId = invoiceId,
                LocationId = locationId,
                ProductName = productName,
                Price = price,
                Quantity = quantity,
                Value = value
            };

            string sql = @"UPDATE dbo.InvoiceDetails
                           SET InvoiceDetailsId = @InvoiceDetailsId,
                               InvoiceId = @InvoiceId,
                               LocationId = @LocationId,
                               ProductName = @ProductName,
                               Price = @Price,
                               Quantity = @Quantity,
                               Value = @Value
                           WHERE InvoiceDetailsId = @InvoiceDetailsId AND LocationId = @LocationId";

            return SqlDataAccess<InvoiceDetailsModel>.SaveData(sql, invoiceDetails);
        }

        public static int DeleteInvoice(int invoiceId, int locationId)
        {
            InvoiceModel invoice = new InvoiceModel
            {
                InvoiceId = invoiceId,
                LocationId = locationId
            };

            string sql = "DELETE FROM dbo.Invoice WHERE InvoiceId = @InvoiceId AND LocationId = @LocationId";

            return SqlDataAccess<InvoiceModel>.SaveData(sql, invoice);
        }

        public static int DeleteInvoiceDetails(int invoiceDetailsId, int locationId)
        {
            InvoiceDetailsModel invoiceDetails = new InvoiceDetailsModel
            {
                InvoiceDetailsId = invoiceDetailsId,
                LocationId = locationId
            };


            string sql = "DELETE FROM dbo.InvoiceDetails WHERE InvoiceDetailsId = @InvoiceDetailsId AND LocationId = @LocationId";

            return SqlDataAccess<InvoiceDetailsModel>.SaveData(sql, invoiceDetails);
        }
    }
}

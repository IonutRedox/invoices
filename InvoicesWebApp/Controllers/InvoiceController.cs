using InvoicesDataLIbrary.BusinessLogic;
using InvoicesWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InvoicesWebApp.Controllers
{
    public class InvoiceController : Controller
    {
        public ActionResult ViewInvoices()
        {
            ViewBag.Message = "Invoices";

            var data = InvoiceProcessor.LoadInvoices();
            List<InvoiceModel> invoices = new List<InvoiceModel>();

            foreach(var row in data)
            {
                invoices.Add(new InvoiceModel
                {
                    InvoiceId = row.InvoiceId,
                    LocationId = row.LocationId,
                    InvoiceNumber = row.InvoiceNumber,
                    ClientName = row.ClientName,
                    Date = row.Date
                });
            }

            return View(invoices);
        }

        public ActionResult CreateInvoice()
        {
            ViewBag.Message = "Create invoice";

            return View();
        }

        [HttpPost]
        public ActionResult CreateInvoice(InvoiceModel model)
        {
            if (ModelState.IsValid)
            {
                bool invoiceFound = InvoiceProcessor.LoadInvoices().Any(invoice => invoice.InvoiceId == model.InvoiceId && invoice.LocationId == model.LocationId);

                if (invoiceFound)
                {
                    return View();
                }

                InvoiceProcessor.CreateInvoice(
                     model.InvoiceId,
                     model.LocationId,
                     model.InvoiceNumber,
                     model.Date,
                     model.ClientName
                 ); 

                InvoiceProcessor.CreateInvoiceDetail(
                    model.InvoiceDetailsId,
                    model.InvoiceId,
                    model.LocationId,
                    model.ProductName,
                    model.Quantity,
                    model.Price,
                    model.Value
                );

                return RedirectToAction("ViewInvoices");
            }

            return View();
        }

        public ActionResult UpdateInvoice(int invoiceId, int locationId)
        {
            var invoices = InvoiceProcessor.LoadInvoices();
            var invoicesDetails = InvoiceProcessor.LoadInvoiceDetails();
            bool invoiceFound = invoices.Any(invoice => invoice.InvoiceId == invoiceId && invoice.LocationId == locationId);

            if (!invoiceFound)
            {
                return HttpNotFound();
            }

            var invoiceData = invoices.SingleOrDefault(invoice => invoice.InvoiceId == invoiceId && invoice.LocationId == locationId);
            var invoiceDetailsData = invoicesDetails.SingleOrDefault(invoiceDetails => invoiceDetails.InvoiceId == invoiceId && invoiceDetails.LocationId == locationId);

            InvoiceModel invoiceToUpdate = new InvoiceModel
            {
                InvoiceId = invoiceId,
                LocationId = locationId,
                InvoiceNumber = invoiceData.InvoiceNumber,
                Date = invoiceData.Date,
                ClientName = invoiceData.ClientName,
                InvoiceDetailsId = invoiceDetailsData.InvoiceDetailsId,
                ProductName = invoiceDetailsData.ProductName,
                Price = invoiceDetailsData.Price,
                Quantity = invoiceDetailsData.Quantity
            };

            return View(invoiceToUpdate);
        }

        [HttpPost,ActionName("UpdateInvoice")]
        public ActionResult UpdateInvoice(InvoiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool invoiceFound = InvoiceProcessor.LoadInvoices().Any(invoice => invoice.InvoiceId == model.InvoiceId && invoice.LocationId == model.LocationId);

            if (!invoiceFound)
            {
                return View(model);
            }

            if (ModelState.IsValid)
            {
                InvoiceProcessor.UpdateInvoiceDetails(
                 model.InvoiceDetailsId,
                 model.InvoiceId,
                 model.LocationId,
                 model.ProductName,
                 model.Quantity,
                 model.Price,
                 model.Value
             );

                InvoiceProcessor.UpdateInvoice(
                    model.InvoiceId,
                    model.LocationId,
                    model.InvoiceNumber,
                    model.Date,
                    model.ClientName
                );


                return RedirectToAction("ViewInvoices");
            }

            return View(model);
        }

        public ActionResult DeleteInvoice(int invoiceId, int locationId)
        {
            var invoices = InvoiceProcessor.LoadInvoices();
            var invoicesDetails = InvoiceProcessor.LoadInvoiceDetails();
            var invoiceData = invoices.SingleOrDefault(invoice => invoice.InvoiceId == invoiceId && invoice.LocationId == locationId);
            var invoiceDetailsData = invoicesDetails.SingleOrDefault(invoiceDetails => invoiceDetails.InvoiceId == invoiceId && invoiceDetails.LocationId == locationId);

            InvoiceModel invoiceToDelete = new InvoiceModel
            {
                InvoiceId = invoiceId,
                LocationId = locationId,
                InvoiceNumber = invoiceData.InvoiceNumber,
                Date = invoiceData.Date,
                ClientName = invoiceData.ClientName,
                InvoiceDetailsId = invoiceDetailsData.InvoiceDetailsId,
                ProductName = invoiceDetailsData.ProductName,
                Price = invoiceDetailsData.Price,
                Quantity = invoiceDetailsData.Quantity
            };

            return View(invoiceToDelete);
        }

        [HttpPost, ActionName("DeleteInvoice")]
        public ActionResult DeleteInvoice(InvoiceModel model)
        {
            InvoiceProcessor.DeleteInvoice(model.InvoiceId, model.LocationId);
            //InvoiceProcessor.DeleteInvoiceDetails(model.InvoiceDetailsId, model.LocationId);
            
            return RedirectToAction("ViewInvoices");
        }
    }
}
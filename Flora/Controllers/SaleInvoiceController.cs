using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;


namespace Flora.Controllers
{
    public class SaleInvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult SaleInvoice_Read([DataSourceRequest] DataSourceRequest request)
        {
            var newObject = new SalesModel();
            newObject.SaleNo = "1";
            newObject.CustomerID = 1;
            newObject.SaleID = 1;
            newObject.CreatedOn = DateTime.Now;
            newObject.TotalSaleAmount = 24400;
            newObject.TaxAmount = 1200;

            var listobj = new List<SalesModel>();
            listobj.Add(newObject);

            return Json(listobj.ToDataSourceResult(request));
        }
    }
}

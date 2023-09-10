using System.ComponentModel.DataAnnotations;

namespace Flora
{
    public class SalesModel
    {
        [Key]
        public long SaleID { get; set; }
        public string SaleNo { get; set; }
        public string STSaleNo { get; set; }
        public long CustomerID { get; set; }
        public DateTime SaleDate { get; set; }
        public long InvoiceTypeID { get; set; }
        public long SchemeID { get; set; }
        public long BookerID { get; set; }
        public long SalesmanID { get; set; }
        public decimal Commission { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmountwithoutTax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string Remarks { get; set; }
        public long StatusID { get; set; }
        public long CompanyID { get; set; }
        public DateTime CreatedOn { get; set; }
        public long UserID { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public long LastModifiedBy { get; set; }

    }

    public class SaleDetailModel
    {
        [Key]
        public long SaleDetailID { get; set; }
        [Required]
        public long SaleID { get; set; }
        [Required]
        public long CustomerID { get; set; }
        public string SaleNo { get; set; }
        public long ProductCategoryID { get; set; }
        public long ProductSubCategoryID { get; set; }
        [Required]
        public long ProductID { get; set; }
        public decimal Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public decimal TradePrice { get; set; }
        public decimal TotalWithoutTax { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime SaleDate { get; set; }
        public int StatusID { get; set; }

    }
}

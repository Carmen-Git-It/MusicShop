using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CW2237A2.Data;

namespace CW2237A2.Models
{
    public class InvoiceLineBaseViewModel
    {
        [Key]
        [Display(Name ="Line ID")]
        public int InvoiceLineId { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display (Name ="Unit Price")]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Line Total")]
        public decimal LinePrice
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }
    }
}
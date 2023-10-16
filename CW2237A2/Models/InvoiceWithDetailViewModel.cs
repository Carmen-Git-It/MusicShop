using CW2237A2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CW2237A2.Models
{
    public class InvoiceWithDetailViewModel : InvoiceBaseViewModel
    {
        [Display(Name ="Customer First Name")]
        public String CustomerFirstName { get; set; }

        [Display(Name ="Customer Last Name")]
        public String CustomerLastName { get; set; }
        
        [Display(Name ="Customer State")]
        public String CustomerState {  get; set; }
        
        [Display(Name = "Customer Country")]
        public String CustomerCountry { get; set; }
        
        [Display(Name = "Employee Last Name")]
        public String CustomerEmployeeLastName { get; set; }
        
        [Display(Name ="Employee First Name")]
        public String CustomerEmployeeFirstName { get; set; }

        public ICollection<InvoiceLineWithDetailViewModel> InvoiceLines { get; set; }

        public InvoiceWithDetailViewModel()
        {
            InvoiceLines = new List<InvoiceLineWithDetailViewModel>();
        }
    }
}
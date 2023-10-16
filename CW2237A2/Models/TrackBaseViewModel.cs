using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CW2237A2.Models
{
    public class TrackBaseViewModel
    {
        [Key]
        [Display(Name="ID")]
        [Editable(false)]
        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name="Track Name")]
        public string Name { get; set; }

        [StringLength(220)]
        [Display(Name="Composer Name(s)")]
        public string Composer { get; set; }

        [Display(Name="Length (ms)")]
        public int Milliseconds { get; set; }

        [Display(Name="Size (Bytes)")]
        public int? Bytes { get; set; }

        [Display(Name="Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal UnitPrice { get; set; }
    }
}
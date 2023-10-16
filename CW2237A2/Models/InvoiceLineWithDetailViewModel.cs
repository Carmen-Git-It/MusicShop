using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CW2237A2.Models
{
    public class InvoiceLineWithDetailViewModel : InvoiceLineBaseViewModel
    {
        [Display(Name = "Name")]
        public String TrackName {  get; set; }

        [Display(Name = "Composer(s)")]
        public String TrackComposer {  get; set; }

        [Display(Name ="Album")]
        public String TrackAlbumTitle { get; set; }

        [Display(Name ="Artist")]
        public String TrackAlbumArtistName { get; set; }

        [Display(Name ="Genre")]        
        public String TrackGenreName {  get; set; }

        [Display(Name ="Media Type")]
        public String TrackMediaTypeName {  get; set; }
    }
}
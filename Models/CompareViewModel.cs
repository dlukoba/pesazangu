using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace pesazangu.Models
{
    public class CompareViewModel
    {
        [Required]
        [Display(Name = "Loan amount")]
        public decimal LoanAmount { get; set; }
        
        [Required]
        [Display(Name = "Payback duration type")]
        public int PaybackDurationType { get; set; }
        public IEnumerable<SelectListItem> PaybackDurationTypes { get; set; }

        [Required]
        [Display(Name = "Payback duration")]
        public int PaybackDuration { get; set; }
    }
}
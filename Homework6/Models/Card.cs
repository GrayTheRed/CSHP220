using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Homework6.Models
{
    public class Card
    {
        [Required(ErrorMessage="Please enter a Recipient")]
        public string To { get; set; }
        [Required(ErrorMessage = "Please enter a Sender")]
        public string From { get; set; }
        [Required(ErrorMessage = "Please enter a Message")]
        public string Message { get; set; }
    }
}
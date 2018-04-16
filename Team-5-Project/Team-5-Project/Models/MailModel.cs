using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team_5_Project.Models
{
    public class MailModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
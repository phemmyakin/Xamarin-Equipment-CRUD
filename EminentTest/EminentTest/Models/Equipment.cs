using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;





namespace EminentTest.Models
{
   public class Equipment
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public string StatusName { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}

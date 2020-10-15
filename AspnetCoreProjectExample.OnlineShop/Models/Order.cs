using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreProjectExample.OnlineShop.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        [Required(ErrorMessage ="Please enter your fitst name")]
        [Display(Name ="First name")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your fitst name")]
        [Display(Name = "Last name")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your address")]
        [Display(Name = "Address Line 1")]
        [StringLength(100)]
        public string AddressLine1 { get; set; }
        
        [Display(Name = "Address Line 1")]
        [StringLength(100)]
        public string AddressLine2 { get; set; }
 
        [Display(Name = "Zip Code")]
        [StringLength(2 , MinimumLength =1)]
        public string ZipCode { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your Phone Number")]
        [Display(Name = "Phone Number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Enter you Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindNever]
        public decimal OrderTotal { get; set; }

        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }
    }
}

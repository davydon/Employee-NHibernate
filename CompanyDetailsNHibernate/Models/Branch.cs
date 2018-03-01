using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyDetailsNHibernate.Models
{
    public class Branch
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage ="Field required")]
        public virtual string BranchId { get; set; }

        [Required(ErrorMessage = "Field required")]
        public virtual string Address { get; set; }

        [Required(ErrorMessage = "Field required")]
        public virtual string Manager { get; set; }

        [Required(ErrorMessage = "Field required")]
        public virtual string Phone { get; set; }

        [Required(ErrorMessage = "Field required")]
        [DataType(DataType.EmailAddress)]
        public virtual string Email { get; set; }
        
    }
}
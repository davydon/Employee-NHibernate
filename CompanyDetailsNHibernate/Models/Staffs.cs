using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyDetailsNHibernate.Models
{
    public class Staffs
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Field required")]
        public virtual string Surname { get; set; }

        [Required(ErrorMessage = "Field required")]
        public virtual string Firstname { get; set; }

        [Required(ErrorMessage = "Field required")]
        public virtual string Address { get; set; }

        [Required(ErrorMessage = "Field required")]
        public virtual string Phone { get; set; }

        [Required(ErrorMessage = "Field required")]
        [DataType(DataType.EmailAddress)]
        public virtual string Email { get; set; }

        [Required(ErrorMessage = "Field required")]
        public virtual string Salary { get; set; }
    }
}
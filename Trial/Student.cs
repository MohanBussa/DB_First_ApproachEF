//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int StandardId { get; set; }
        [Required]
        /* [RegularExpression(@"^(\d{13})$", ErrorMessage = "Enter 10 Digit Mobile No.")]*/
        /*[RegularExpression(@"^[\+\-\@\d]{10}$", ErrorMessage = "Enter a 10-digit mobile number")]*/
        public string MobileNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        public string StandardName { get; set; }
        public int CountryCodeId { get; set; }
        public virtual CountryCode CountryCode { get; set; }
        public virtual Standard Standard { get; set; }
    }
}
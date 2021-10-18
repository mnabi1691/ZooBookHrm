using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZooBook.Hrm.Domain.Entities
{
    public class Employee
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(400)]
        public string FirstName { get; set; }

        [MaxLength(400)]
        public string MiddleName { get; set; }

        [MaxLength(400)]
        public string LastName { get; set; }
    }
}

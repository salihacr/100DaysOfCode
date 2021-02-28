using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace React_Project.Models
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(16)")]
        public string Mobile { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        public int Age { get; set; }
        [Column(TypeName = "nvarchar(3)")]
        public string BloodGroup { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
    }
}

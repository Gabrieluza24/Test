using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Fullname { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

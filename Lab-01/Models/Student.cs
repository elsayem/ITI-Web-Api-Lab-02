using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_01.Models
{
    public class Student
    {
        public int Id { get; set; }        

        [Display(Name = "Full Name")]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        
        [MaxLength(11),MinLength(11)]
        public String Phone { get; set; }


        [Range(20, 45)]
        public int Age { get; set; }

        public string Image { get; set; }

        [ForeignKey("Department")]
        public int DeparmentId {  get; set; }

        public virtual Department? Department { get; set; }
    }
}

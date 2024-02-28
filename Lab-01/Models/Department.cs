
using Lab_01.Data.Context;
//using Lab_01.Validator;
using Lab_01.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab_01.Models
{

    public class Department
    {
        //private readonly StudentContext _dbContext;

        //public Department(StudentContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        public int Id { get; set; }

        //[UniqueDepartmentName(new StudentContext()[ErrorMessage ="Unique"])]
        //[UniqueNameValidationAttribute]
        //[UniqueName]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Manager { get; set; }


        public virtual ICollection<Student>? Students { get; set; }
        //public Department(StudentContext dbContext)
        //{
        //    // Pass the DbContext instance to the attribute constructor
        //    var Name = new UniqueNameValidationAttribute(dbContext);
        //}
    }
}

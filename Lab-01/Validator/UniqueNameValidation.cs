//using Lab_01.Data.Context;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;

//namespace Lab_01.Validator
//{
//    //[AttributeUsage(AttributeTargets.Property)]
//    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]

//    public class UniqueNameValidationAttribute : ValidationAttribute
//    {
//        public class UniqueDepartmentNameAttribute : ValidationAttribute
//        {
//            //private readonly StudentContext _dbContext;

//            //public UniqueDepartmentNameAttribute()
//            //{
//            //}

//            //public UniqueDepartmentNameAttribute(StudentContext dbContext)
//            //{
//            //    _dbContext = dbContext;
//            //}
//            StudentContext _dbContext = new StudentContext();
//            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//            {
//                string enteredName = value as string;

//                if (string.IsNullOrEmpty(enteredName))
//                {
//                    return new ValidationResult("Name cannot be empty");
//                }
//                var c = _dbContext.Departments.FirstOrDefault(x => x.Name == enteredName);
//                // Check if the name already exists in the database
//                if (c != null)
//                {
//                    return new ValidationResult("Name must be unique");
//                }

//                return ValidationResult.Success;
//            }
//        }
//    }
//}



////using System.ComponentModel.DataAnnotations;
////using System.Linq;
////using Lab_01.Data.Context;

////namespace Lab_01.Validator
////{
////    public class UniqueDepartmentNameAttribute : ValidationAttribute
////    {
////        private readonly StudentContext _dbContext;

////        public UniqueDepartmentNameAttribute()
////        {
////        }

////        public UniqueDepartmentNameAttribute(StudentContext dbContext)
////        {
////            _dbContext = dbContext;
////        }

////        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
////        {
////            string departmentName = value as string;

////            if (string.IsNullOrEmpty(departmentName))
////            {
////                return ValidationResult.Success; // Return success if the department name is null or empty
////            }

////            Check if any other department already has the same name
////            bool isNameUnique = !_dbContext.Departments.Any(d => d.Name == departmentName);

////            if (!isNameUnique)
////            {
////                Return error message if the name is not unique
////                return new ValidationResult("Department name must be unique");
////            }

////            return ValidationResult.Success; //Unique
////        }
////    }
////}


//using Lab_01.Data.Context;
//using System.ComponentModel.DataAnnotations;
//using System.Reflection.Metadata.Ecma335;
//using Lab_01.Data.Context;
//using Lab_01.DTOS;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//namespace Lab_01.Validator
//{
//    public class UniqueName : ValidationAttribute
//    {
//        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//        {
//            var name = value as string; //the given name
//            if(name != null)
//            {
//                //return new ValidationResult("The Name Should Be Unique");
//                StudentContext studentContext = new StudentContext();
//                var isDeptExist = studentContext.Departments.Any(x => x.Name == name);

//                if (isDeptExist)
//                {
//                    return new ValidationResult("The Name Should Be Unique");

//                }
//            }
           

//            return ValidationResult.Success;

//        }

//    }
//}

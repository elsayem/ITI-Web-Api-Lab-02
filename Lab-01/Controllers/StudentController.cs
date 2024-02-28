using Lab_01.Data.Context;
using Lab_01.DTOS;
using Lab_01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Data.Common;

namespace Lab_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext db;


        public StudentController(StudentContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var std = db.students.Include(d =>d.Department).ToList();
            var AllStdDept = new List<StudentWithDepartment>();
            if (ModelState.IsValid)
            {
                foreach(var s  in std)
                {
                    var StdDept = new StudentWithDepartment();
                    StdDept.Student_name = s.Name;
                    StdDept.Student_phone = s.Phone;
                    StdDept.Student_Department = s.Department.Name;

                    AllStdDept.Add(StdDept);
                }

                return Ok(AllStdDept);
            }
            else
            {
                return NotFound();
            }
        }



        [Route("{id:int}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            //var d=  db.students.FirstOrDefault(x => x.Id == id);
            var std = db.students.Include(d=>d.Department).FirstOrDefault(i => i.Id ==id);
            if (std != null)
            {
                StudentWithDepartment stdDept = new StudentWithDepartment();
                stdDept.Student_phone = std.Phone;
                stdDept.Student_name=std.Name;
                stdDept.Student_Department = std.Department.Name;
                return Ok(new { msg = $"Student ID: {std.Id}, ",student=stdDept });
            }
            else
            {
                return NotFound(new { msg = $"The Student with ID:{id} is not Found !!" });
            };
        }

        //Get by Name
        [Route("{name:alpha}")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var std = db.students.SingleOrDefault(n => n.Name.ToLower() == name.ToLower());
            if (std != null)
            {
                return Ok(new { msg = $"The Student Name is : {std.Name} and Phone :{std.Phone}" });
            }
            return NotFound(new { msg = $"The Student not Found" });
        }

        [HttpPost]
        public IActionResult Add(Student std)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(std);
                db.SaveChanges();
                //return Ok(new {msg=$"{std.Name} Data Saved Successfully " });
                return CreatedAtAction("GetById", new { id = std.Id }, std);

                //return CreatedAtAction(actionName: "GetById", routeValues: new { id = std.Id }, "Studend Added");
            }
            return NotFound(new { msg = $"The Student is not complete !" });
        }




        //Update
        [HttpPut("{id}")]

        public IActionResult Update(int id, Student std)
        {
            var s = db.students.Find(id);

            if (s != null)
            {
                s.Name = std.Name;
                s.Age = std.Age;
                s.Phone = std.Phone;
                s.Image = std.Image;

                db.SaveChanges();

                return NoContent();
            }
            return BadRequest();


        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delStd = db.students.Find(id);
            if (delStd != null)
            {
                db.students.Remove(delStd);
                db.SaveChanges();
                return NoContent();
            }
            return BadRequest();


        }

    }


}

using Lab_01.Data.Context;
using Lab_01.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab_01.CustomFilter;
using Lab_01.Models;

namespace Lab_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly StudentContext db;


        public DepartmentController(StudentContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [LocationFilter]

        public IActionResult GetAll()
        {
            var dept = db.Departments.Include(s => s.Students).ToList();
            var AlldeptStd = new List<DeptWithStudentNames>();

            if (ModelState.IsValid)
            {

                foreach (var d in dept)
                {
                    DeptWithStudentNames deptStd = new DeptWithStudentNames();

                    //var deptStd = new DeptWithStudentNames();
                    deptStd.Department_Number = d.Id;
                    deptStd.Department_Name = d.Name;
                    deptStd.Department_Manger = d.Manager;
                    deptStd.Department_Location = d.Location;
                    foreach (var s in d.Students)
                    {
                        deptStd.Student_Names.Add(s.Name);
                    };
                    AlldeptStd.Add(deptStd);
                }
                //DeptWithStudentNames deptStd = new DeptWithStudentNames();
                return Ok(AlldeptStd);


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
            //var std = db.students.FirstOrDefault(x => x.Id == id);
            var dept = db.Departments.Include(s => s.Students).FirstOrDefault(i => i.Id ==id);

            
            
            if (dept != null)
            {
                DeptWithStudentNames stdAndDept = new DeptWithStudentNames();
                stdAndDept.Department_Number = id;
                stdAndDept.Department_Name =  dept.Name;
                stdAndDept.Department_Manger = dept.Manager;
                stdAndDept.Department_Location = dept.Location;
                foreach (var s in dept.Students)
                {
                    stdAndDept.Student_Names.Add(s.Name);
                }

                return Ok(new { msg = $"Department Found ID: {id}, Name:{dept.Name}",dept = stdAndDept });
            }
            else
            {
                return NotFound(new { msg = $"The Department with ID:{id} is not Found !!" });
            };
        }

        [HttpPost]
        [LocationFilter]

        public IActionResult Add(Department dept)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(dept);
                db.SaveChanges();
                //return Ok(new {msg=$"{std.Name} Data Saved Successfully " });
                return CreatedAtAction("GetById", new { id = dept.Id }, dept);

                //return CreatedAtAction(actionName: "GetById", routeValues: new { id = std.Id }, "Studend Added");
            }
            return NotFound(new { msg = $"The Department is not complete !" });
        }


    }
}

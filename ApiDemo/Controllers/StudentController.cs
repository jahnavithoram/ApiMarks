using ApiDemo.Data;
using ApiDemo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       

            private readonly IBaseRepositry<StudentModel> _repo;

            public StudentController(IBaseRepositry<StudentModel> repo)
            {
                this._repo = repo;
            }

            [HttpGet("Get")]
            public async Task<IActionResult> Get()
            {
                return Ok(await _repo.GetAll());
            }


            [HttpGet("GetById/{id}")]
            public async Task<IActionResult> Get(string id)
            {
                if (id == null)
                {
                    return BadRequest();
                }

                var StudentModel = await _repo.Get(id);
                if (StudentModel == null)
                {
                    return NotFound();
                }

                return Ok(StudentModel);
            }
     //   [HttpPost("PostMarks/{id}/{subid}")]

     
        
        /*    public  List<MarksModel> PostMarks(string id,string subid)
            {
               // if (id == null)
                //{
                //    return BadRequest();
                //}
                var subject = new SubjectModel();
                var marks = new MarksModel();
                List<MarksModel> m = new List<MarksModel>();
                marks.ID = id;
                marks.SubName = (subid);
                //m.Add(marks);
             //  var MarksModel = await _repo.Get(id);
              //  if (StudentModel == null)
              //  {
              //      return NotFound();
               // }

                return m;
            }*/

        [HttpPost("Post")]
            public async Task<IActionResult> Post(StudentModel StudentModel)
            {
                if (ModelState.IsValid)
                {
                    await _repo.Insert(StudentModel);
                    return Ok();
                }
                return BadRequest();
            }

           
            [HttpPut]
           
            public async Task<IActionResult> Put(StudentModel StudentModel)
            {
                if (string.IsNullOrEmpty(StudentModel.ID))
                {
                    return BadRequest();
                }

                if (ModelState.IsValid)
                {
                    await _repo.Update(StudentModel);

                    return Ok(StudentModel);
                }
                return BadRequest();
            }

            // GET: Student/Delete/5
            public async Task<IActionResult> Delete(string id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var StudentModel = await _repo.Get(id);
                if (StudentModel == null)
                {
                    return NotFound();
                }
                await _repo.Delete(id);
                return Ok();
            }

        }
    }



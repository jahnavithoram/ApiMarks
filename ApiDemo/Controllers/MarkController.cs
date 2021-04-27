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
    public class MarkController : ControllerBase
    {


        private readonly IBaseRepositry<MarksModel> _repo;

        public MarkController(IBaseRepositry<MarksModel> repo)
        {
            this._repo = repo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetAll());
        }


        [HttpGet("GetById/{id}/")]
        public async Task<IActionResult> Get(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var MarkModel = await _repo.Get(id);
           if (MarkModel == null)
            {
                return NotFound();
            }

            return Ok(MarkModel);
        }


        [HttpPost("Post/{id}/{subName}")]
        public async Task<IActionResult> Post(MarksModel MarkModel,string id,string subname)
        {
            if (ModelState.IsValid)
            {
                MarkModel.ID = id;
                MarkModel.SubName = subname;
               await _repo.Insert(MarkModel);
                return Ok();
            }
            return BadRequest();
        }


        [HttpPut("Put")]

        public async Task<IActionResult> Put(MarksModel MarkModel)
        {
            if (string.IsNullOrEmpty(MarkModel.ID))
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _repo.Update(MarkModel);

                return Ok(MarkModel);
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MarkModel = await _repo.Get(id);
            if (MarkModel == null)
            {
                return NotFound();
            }
            await _repo.Delete(id);
            return Ok();
        }

    }
}



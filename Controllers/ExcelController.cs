using System.Text.Json;
using BlazorAppExcel.API.Interfaces;
using BlazorAppExcel.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorAppExcel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IExcelRepository service;

        public ExcelController(IExcelRepository excelService) {
            this.service = excelService;
        }
        // GET: api/<ExcelController>
         // GET: api/<ExcelController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableExcel>>> Get()
        {
            var list = await this.service.ListAsync();
            var jsonList = JsonSerializer.Serialize<IList<TableExcel>>(list);
            return Ok(jsonList);
        }

        // GET api/<ExcelController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TableExcel>> Get(string id)
        {
            var Excel = await this.service.GetById(id);

            return Ok(Excel);
        }

        // POST api/<ExcelController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] TableExcel value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            await this.service.SaveAsync(value);

            //await this.service.InsertAsync(value);
            return Ok();
        }

        // PUT api/<ExcelController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] TableExcel value)
        {
            await this.service.Update(value);
            return Ok();
        }

        // DELETE api/<ExcelController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await this.service.DeleteAsync(new TableExcel() {  Id = id});
            return Ok();
        }
    }
}

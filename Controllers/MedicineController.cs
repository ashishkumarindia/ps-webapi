using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicineController : ControllerBase
    {

        private readonly IMedicineDetailsService medicineDetailsService;

        public MedicineController(IMedicineDetailsService medicineDetailsService)
        {
            this.medicineDetailsService = medicineDetailsService;
        }

        [HttpGet("Get/{id}")]
        [ProducesResponseType(typeof(MedicineDetails), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var data = (await this.medicineDetailsService.GetAll()).FirstOrDefault(s => s.Id == id);

            if (data == null)
            {
                return NotFound($"No record found for id{id}");
            }
            return Ok(data);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<MedicineDetails>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.medicineDetailsService.GetAll());
        }

        [HttpPost("Create")]
        [ProducesResponseType(typeof(ResponseStatus), StatusCodes.Status200OK)]
        public async Task<IActionResult> add([FromBody] MedicineDetails medicineDetails)
        {
            if (medicineDetails == null)
            {
                return BadRequest($"{nameof(MedicineDetails)} object is null");
            }

            var Id = await this.medicineDetailsService.Add(medicineDetails);
            return Ok($"New record added with id {Id}");
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(MedicineDetails), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Patch(int id, [FromBody] MedicineDetails medicineDetails)
        {

            var data = (await this.medicineDetailsService.GetAll()).FirstOrDefault(s => s.Id == id);

            if (data == null)
            {
                return NotFound($"No record found for id{id}");
            }

            this.medicineDetailsService.Update(id, medicineDetails);
            return NoContent();
        }


        [HttpGet("Reset")]
        [ProducesResponseType(typeof(IEnumerable<MedicineDetails>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Reset()
        {
            return Ok(await this.medicineDetailsService.Reset());
        }
    }
}

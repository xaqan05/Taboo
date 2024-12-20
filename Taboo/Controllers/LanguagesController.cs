
using Microsoft.AspNetCore.Mvc;
using Taboo.DTOs.Languages;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguagesController(ILanguageService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Read()
        {

            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(LanguageUpdateDto dto,string code)
        {
            await _service.UpdateAsync(dto,code);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string code)
        {
            await _service.DeleteAsync(code);
            return Ok();
        }

    }
}

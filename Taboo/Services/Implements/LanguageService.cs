using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Taboo.DataAccesLayer;
using Taboo.DTOs.Languages;
using Taboo.Entities;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements
{
    public class LanguageService(TabooDbContext _context) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            await _context.Languages.AddAsync(new Language
            {
                Code = dto.Code,
                Name = dto.Name,
                Icon = dto.Icon,
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var data = await _context.Languages.FindAsync(code);
            _context.Languages.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            return await _context.Languages.Select(x => new LanguageGetDto
            {
                Name = x.Name,
                Code = x.Code,
                Icon = x.Icon,
            }).ToListAsync();
        }

        public async Task UpdateAsync(LanguageUpdateDto dto, string code)
        {
            var data = await _context.Languages.FindAsync(code);

            data.Name = dto.Name;
            data.Icon = dto.Icon;

            await _context.SaveChangesAsync();

        }

    }
}

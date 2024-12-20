using Taboo.DTOs.Languages;

namespace Taboo.Services.Abstracts
{
    public interface ILanguageService
    {
        Task CreateAsync(LanguageCreateDto dto);
        Task<IEnumerable<LanguageGetDto>> GetAllAsync();
        Task UpdateAsync(LanguageUpdateDto dto,string code);
        Task DeleteAsync(string code);
    }
}

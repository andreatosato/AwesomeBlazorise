using AwesomeBlazor.Services.Abstractions;
using AwesomeBlazor.Services.Models;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeBlazor.Services
{
    public interface ILanguageService
    {
        string GetLanguageSelected();
        void SetLanguageSelected(string isoCode);
        Task<Language[]> GetLanguagesAvailable(CancellationToken cancellationToken = default);
        CultureInfo GetCultureInfo();
    }

    public class LanguageService : ILanguageService
    {
        private string selectedLanguage;
        private ITMDbService TMDbService;

        public LanguageService(ITMDbService TMDbService)
        {
            this.TMDbService = TMDbService;
        }

        public async Task<Language[]> GetLanguagesAvailable(CancellationToken cancellationToken = default)
        {
            return await TMDbService.GetAvailableLanguages(cancellationToken: cancellationToken);
        }

        public string GetLanguageSelected()
        {
            if (string.IsNullOrEmpty(selectedLanguage))
                selectedLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            return selectedLanguage;
        }

        public void SetLanguageSelected(string isoCode)
        {
            selectedLanguage = isoCode;
        }

        public CultureInfo GetCultureInfo()
        {
            return CultureInfo.CreateSpecificCulture(GetLanguageSelected());
        }
    }
}

using Blazorise;

namespace AwesomeBlazor.Services
{
    public interface IThemeService
    {
        Theme CurrentTheme { get; set; }
    }

    public class ThemeService : IThemeService
    {
        public Theme CurrentTheme { get; set; } = new Theme();
    }
}

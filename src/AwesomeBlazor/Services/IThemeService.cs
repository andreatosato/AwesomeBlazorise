using Blazorise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Interfaces.Parsers
{
    public interface IPageParser<out T> where T : Page
    {
        T Parse(RawPage page);
    }
}

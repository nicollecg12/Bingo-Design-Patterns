using Bingo_Design_Patterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Design_Patterns
{
    public interface IPalabraRepository
    {
        Dictionary<string, string> ObtenerPatrones();
    }
}

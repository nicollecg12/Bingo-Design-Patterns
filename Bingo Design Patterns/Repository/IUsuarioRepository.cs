using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Design_Patterns.Repository
{
    public interface IUsuarioRepository
    {
        string ObtenerRol(string loginName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Design_Patterns.Repository
{
    public interface IUsuarioActivoRepository
    {
        List<Jugador> GetAll();
    }
}

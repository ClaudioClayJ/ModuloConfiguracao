using System.Collections.Generic;

namespace Models
{
    public class Permissao
    {
        public int Id { get; set; }
        public string Descrissao { get; set; }

        public List<GrupoUsuario> Grupos { get; set; }
    }
}

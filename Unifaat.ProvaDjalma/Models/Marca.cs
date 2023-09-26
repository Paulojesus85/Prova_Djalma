using System.ComponentModel.DataAnnotations;
using Unifaat.ProvaDjalma.Models.Interfaces;

namespace Unifaat.ProvaDjalma.Models
{
    public class Marca : IStatusModificacao  
    {
        public int MarcaId { get; set; }

        [MaxLength(128)]
        public string NomeMarca { get; set; }

        #region Interface
        [ScaffoldColumn(false)]
        [Display(Name = "Excluído")]
        public bool Excluido { get; set; }
        #endregion

        public ICollection<Produto>? produtos { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using Unifaat.ProvaDjalma.Models.Interfaces;

namespace Unifaat.ProvaDjalma.Models
{
    public class Vendedor  : IStatusModificacao
    {
        public int VendedorId { get; set; }

        [MaxLength(128)]
        public string NomeCompleto {  get; set; }

        [MaxLength(11)]
        public string Telefone { get; set; }

        [MaxLength(128)]
        [EmailAddress]
        public string Email { get; set; }

        #region Interface
        [ScaffoldColumn(false)]
        [Display(Name = "Excluído")]
        public bool Excluido { get; set; }
        #endregion

        public ICollection<Cliente>? clientes { get; set; }
    }
}

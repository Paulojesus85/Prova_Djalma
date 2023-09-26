using System.ComponentModel.DataAnnotations;
using Unifaat.ProvaDjalma.Models.Interfaces;

namespace Unifaat.ProvaDjalma.Models
{
    public class Cliente : IStatusModificacao
    {
        public int ClienteId { get; set; }

        [MaxLength(128)]
        public string NomeCompleto { get; set; }

        [MaxLength(11)]
        public string Telefone { get; set; }

        [MaxLength(128)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(11)]
        public string CPF { get; set; }

        [MaxLength(14)]
        public string? CNPJ { get; set; }

        #region Interface
        [ScaffoldColumn(false)]
        [Display(Name = "Excluído")]
        public bool Excluido { get; set; }
        #endregion

        public int VendedorId { get; set; }
        public Vendedor? Vendedor { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }
    }
}

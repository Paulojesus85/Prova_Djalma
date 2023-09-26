using System.ComponentModel.DataAnnotations;
using Unifaat.ProvaDjalma.Models.Interfaces;

namespace Unifaat.ProvaDjalma.Models
{
    public class Pedido : IStatusModificacao
    {
        public int PedidoId { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        #region Interface
        [ScaffoldColumn(false)]
        [Display(Name = "Excluído")]
        public bool Excluido { get; set; }
        #endregion

        public ICollection<Produto>? Produtos { get; set; }
    }
}

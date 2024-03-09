using GestaoDeClientes.Domain.Enum;
using System.ComponentModel;

namespace GestaoDeClientes.Domain.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        [DisplayName("Nome Completo")]
        public string NomeCompleto { get; set; }
        [DisplayName("CPF")]
        public string CPF { get; set; }
        [DisplayName("Gênero")]
        public Genero Genero { get; set; }
        [DisplayName("Telefone / Celular")]
        public string Telefone { get; set; }
        [DisplayName("Cliente Ativo")]
        public bool Ativo { get; set; }

    }
}

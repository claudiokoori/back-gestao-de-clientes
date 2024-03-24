using GestaoDeClientes.Domain.Enum;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace GestaoDeClientes.Domain.Model
{
    public class Cliente
    {
        [JsonIgnore]
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
        public int? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

    }
}

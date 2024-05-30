using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjAula1B
{
    public class PenalidadesAplicadas
    {
        [JsonProperty("razao_social")]
        public string RazaoSocial { get; set; }
        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }
        [JsonProperty("nome_motorista")]
        public string NomeMotorista { get; set; }
        [JsonProperty("cpf")]
        public string CPF { get; set; }
        [JsonProperty("vigencia_do_cadastro")]
        public DateTime VigenciaCadastro { get; set; }

        public PenalidadesAplicadas()
        {
            
        }
        public PenalidadesAplicadas(string razaoSocial, string cNPJ, string nomeMotorista, string cPF, DateTime vigenciaCadastro)
        {
            RazaoSocial = razaoSocial;
            CNPJ = cNPJ;
            NomeMotorista = nomeMotorista;
            CPF = cPF;
            VigenciaCadastro = vigenciaCadastro;
        }

        public override string? ToString() => $"RazãoSocial: {RazaoSocial},CNPJ: {CNPJ},NomeMotorista: {NomeMotorista}\nCPF: {CPF}";
    }


}

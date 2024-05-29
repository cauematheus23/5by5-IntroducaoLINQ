using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAula1B
{
    public class Conexao_Banco
    {
        string strConexao = "";

        public Conexao_Banco()
        {
            strConexao += "Data Source=127.0.0.1;";             //Endereco do Servidor
            strConexao += "Initial Catalog=PenalidadesAplicadas;";    //Nome da Base de Dados
            strConexao += "User Id=sa; Password=SqlServer2019!;";  //Usuario e Senha
            strConexao += "TrustServerCertificate=true;";  //Usuario e Senha
        }

        public string Caminho()
        {
            return strConexao;
        }
    }
}

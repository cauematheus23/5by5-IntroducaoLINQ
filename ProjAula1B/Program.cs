using Microsoft.Data.SqlClient;
using ProjAula1B;
using System.Data;

string path = "C:\\Users\\Cauê\\JSONS\\motoristas-habilitados.json";

SqlConnection ConectarBD()
{
    Conexao_Banco conn = new Conexao_Banco();
    SqlConnection conexaosql = new SqlConnection(conn.Caminho());
    try
    {
        conexaosql.Open();
    }
    catch (SqlException e)
    {
        Console.WriteLine(e.ToString());
    }
    catch (Exception e)
    {
        e.ToString();
    }
    return conexaosql;
}

var lst = ReadFile.GetData(path);
void InserirNoBD(List<PenalidadesAplicadas> lst)
{
   
    var conexaosql = ConectarBD();
        foreach (var enterprise in lst)
        {
        SqlCommand cmd = new SqlCommand("Insert into EmpresaMotorista (RazaoSocial,CNPJ,NomeMotorista,CPF,VigenciaCadastro)\r\n\tValues\r\n\t(@razao_social,@cnpj,@nome_motorista,@cpf,@vigencia_cadastro)\r\n\t;", conexaosql);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@razao_social", SqlDbType.VarChar,50)).Value = enterprise.RazaoSocial;
        cmd.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar,50)).Value = enterprise.CNPJ;
        cmd.Parameters.Add(new SqlParameter("nome_motorista", SqlDbType.VarChar,50)).Value = enterprise.NomeMotorista ;
        cmd.Parameters.Add(new SqlParameter("cpf", SqlDbType.VarChar,50)).Value = enterprise.CPF;
        cmd.Parameters.Add(new SqlParameter("vigencia_cadastro", SqlDbType.DateTime,10)).Value = enterprise.VigenciaCadastro;
        cmd.ExecuteNonQuery();
        }
    conexaosql.Close();
}

//Console.WriteLine(TestFilters.GetCountRecords(lst));

//TestFilters.PrintRecords(TestFilters.FilterByCPF237(lst));
//TestFilters.PrintRecords(TestFilters.FilterByYear2021(lst));
//TestFilters.PrintRecords(TestFilters.FilterByLTDA(lst));
//TestFilters.PrintRecords(TestFilters.OrderByRazaoSocial(lst));
//TestFilters.PrintRecords(lst
//InserirNoBD(lst);

Console.WriteLine(TestFilters.GenerateXML(lst));



using Microsoft.Data.SqlClient;
using MongoDB.Driver;
using ProjAula1B;
using System.Data;

string path = @"C:\Users\cauem\JSONS\motoristas_habilitados.json";
var lst = ReadFile.GetData(path);

List<PenalidadesAplicadas> DataOfSqlBD()
{
    var list = new List<PenalidadesAplicadas>();
    var conexaosql = ConectarBD();
    SqlCommand cmd = new SqlCommand("Select RazaoSocial,Cnpj,NomeMotorista,Cpf,VigenciaCadastro FROM EmpresaMotorista",conexaosql);
    cmd.CommandType = CommandType.Text;

    using (SqlDataReader reader = cmd.ExecuteReader())
        while (reader.Read())
        {

        string razao_social = reader["RazaoSocial"].ToString();
        string cnpj = reader["Cnpj"].ToString();
        string nome_motorista = reader["NomeMotorista"].ToString();
        string cpf = reader["Cpf"].ToString();
        DateTime vigencia_cadastro = DateTime.Parse(reader["VigenciaCadastro"].ToString());
        list.Add(new(razao_social, cnpj, nome_motorista,cpf,vigencia_cadastro));
        }

    
    return list;
}
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

async Task InserirNoMongo(List<PenalidadesAplicadas> list)
{
    bool inserted = false;
    try
    {
        Conexao_Mongo cm = new Conexao_Mongo();
        MongoClient mongoconnection = new MongoClient(cm.PathMongo());
        var database = mongoconnection.GetDatabase("PenalidadesAplicadas");
        var collection = database.GetCollection<PenalidadesAplicadas>("DepositoDeDados");
        collection.InsertMany(list);
        inserted = true;

    }
    catch (Exception e){ Console.WriteLine(e.ToString()); }
    finally
    {
        if (inserted)
        {
            Console.WriteLine("successfully inserted");
            var conexaosql = ConectarBD();
            SqlCommand cmd = new SqlCommand("INSERT INTO MetaDado (descripton, DataInsertion,NumberOfRecords) Values (@desc,@date,@numinsert)", conexaosql);
            cmd.CommandType = CommandType.Text;
            Console.WriteLine("Type a description of insertion");
            cmd.Parameters.Add(new SqlParameter("@desc", SqlDbType.VarChar,50)).Value = Console.ReadLine(); ;
            cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime)).Value = DateTime.Now;
            cmd.Parameters.Add(new SqlParameter("@numinsert", SqlDbType.Int)).Value = list.Count();
            cmd.ExecuteNonQuery();
            conexaosql.Close();
        }
    }
}
void InserirNoBD(List<PenalidadesAplicadas> lst)
{
    var conexaosql = ConectarBD();
    int batchSize = 2000;

    for (int i = 0; i < lst.Count; i += batchSize)
    {
        var batch = lst.Skip(i).Take(batchSize).ToList();
        InserirLoteNoBD(batch, conexaosql);
    }

    conexaosql.Close();
}
void InserirLoteNoBD(List<PenalidadesAplicadas> batch, SqlConnection conexaosql)
{
    foreach (var enterprise in batch)
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO EmpresaMotorista (RazaoSocial, Cnpj, NomeMotorista, Cpf, VigenciaCadastro) VALUES (@razao_social, @cnpj, @nome_motorista, @cpf, @vigencia_cadastro)", conexaosql);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("@razao_social", SqlDbType.VarChar, 50)).Value = enterprise.RazaoSocial;
        cmd.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar, 50)).Value = enterprise.CNPJ;
        cmd.Parameters.Add(new SqlParameter("@nome_motorista", SqlDbType.VarChar, 50)).Value = enterprise.NomeMotorista;
        cmd.Parameters.Add(new SqlParameter("@cpf", SqlDbType.VarChar, 50)).Value = enterprise.CPF;
        cmd.Parameters.Add(new SqlParameter("@vigencia_cadastro", SqlDbType.DateTime)).Value = enterprise.VigenciaCadastro;
        cmd.ExecuteNonQuery();
    }
}

//Console.WriteLine(TestFilters.GetCountRecords(lst));

//TestFilters.PrintRecords(TestFilters.FilterByCPF237(lst));
//TestFilters.PrintRecords(TestFilters.FilterByYear2021(lst));
//TestFilters.PrintRecords(TestFilters.FilterByLTDA(lst));
//TestFilters.PrintRecords(TestFilters.OrderByRazaoSocial(lst));
//TestFilters.PrintRecords(lst
//InserirNoBD(lst);
InserirNoMongo(DataOfSqlBD());

//Console.WriteLine(TestFilters.GenerateXML(lst));



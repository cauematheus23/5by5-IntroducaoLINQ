public class Conexao_Mongo
{
    private readonly string strConexaoMongo = "mongodb://root:Mongo%402024%23@localhost:27017";

    public Conexao_Mongo()
    {
        // O campo strConexaoMongo já está inicializado com o valor padrão
    }

    public string PathMongo()
    {
        return strConexaoMongo;
    }
}

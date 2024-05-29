using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjAula1B
{
    public class TestFilters
    {
        public static int GetCountRecords(List<PenalidadesAplicadas> list) => list.Count;
        public static void PrintRecords(List<PenalidadesAplicadas> list) {foreach (var r in list) { Console.WriteLine(r); } }
        public static List<PenalidadesAplicadas> FilterByCPF237(List<PenalidadesAplicadas> list) => list.Where(l => l.CPF.Substring(0,3) == "237").ToList();
        public static List<PenalidadesAplicadas> FilterByYear2021(List<PenalidadesAplicadas> list) => list.Where(l => l.VigenciaCadastro.Year == 2021).ToList();
        public static List<PenalidadesAplicadas> FilterByLTDA(List<PenalidadesAplicadas> list) => list.Where(l => l.RazaoSocial.Contains("LTDA",StringComparison.OrdinalIgnoreCase)).ToList();
        public static List<PenalidadesAplicadas> OrderByRazaoSocial(List<PenalidadesAplicadas> list) => list.OrderBy(l => l.RazaoSocial).ToList();

        public static string GenerateXML(List<PenalidadesAplicadas> list)
        {
            if (list.Count > 0)
            {
                var PenalidadeAplicada = new XElement("Root", from data in list
                                                              where data.CPF == "465.***.***-53"
                                                              select new XElement("Motorista",
                                                              new XElement("razao_social", data.RazaoSocial),
                                                              new XElement("cnpj", data.CNPJ),
                                                              new XElement("nome_motorista", data.NomeMotorista),
                                                              new XElement("cpf", data.CPF),
                                                              new XElement("vigencia_do_cadastro", data.VigenciaCadastro)
                                                              )
                                                             );

                return PenalidadeAplicada.ToString();
            }
            else
            {
                return "Register Empty";
            }
        }
    }
}

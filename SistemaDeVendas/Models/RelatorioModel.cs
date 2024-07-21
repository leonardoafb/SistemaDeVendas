using SistemaDeVendas.Uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Models
{
    public class RelatorioModel
    {
        public DateTime DataDe { get; set; }

        public DateTime DataAte { get; set; }

    }

    public class GraficoProdutos
    {
        public double QtdVendido { get; set; }

        public int CodigoProduto { get; set; }

        public string DescricaoProduto { get; set; }

        public List<GraficoProdutos> RetornarGrafico()
        {
            DAL dal = new DAL();
            string sql = "SELECT SUM(CONVERT(INT, qtd_produto)) AS QTD, p.nome AS Produto FROM Itens_Venda i INNER JOIN Produto p ON i.Produto_id = p.id GROUP BY p.nome";
            DataTable dt = dal.RetDataTable(sql);

            List<GraficoProdutos> lista = new List<GraficoProdutos>();
            GraficoProdutos item;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new GraficoProdutos();
                item.QtdVendido = double.Parse(dt.Rows[i]["qtd"].ToString());
                item.DescricaoProduto = dt.Rows[i]["produto"].ToString();
                lista.Add(item);
            }
            return lista;
        }
    }
}

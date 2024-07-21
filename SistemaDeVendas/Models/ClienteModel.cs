using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeVendas.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeVendas.Models
{
    public class ClienteModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF ou CNPJ do Cliente")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe o Email do Cliente")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O Email informado é inválido!")]
        public string Email { get; set; }

        public string Senha { get; set; }

        public List<ClienteModel> ListarTodosClientes()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            DAL dal = new DAL();
            string sql = "SELECT id, nome, cpf_cnpj, email, senha FROM Cliente ORDER BY nome ASC";
            DataTable dt = dal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ClienteModel
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Nome = dt.Rows[i]["Nome"].ToString(),
                    CPF = dt.Rows[i]["cpf_cnpj"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    Senha = dt.Rows[i]["Senha"].ToString()
                };

                lista.Add(item);
            }
            return lista;
        }

        public ClienteModel RetornarClienteId(int? id)
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            DAL dal = new DAL();
            string sql = $"SELECT id, nome, cpf_cnpj, email, senha FROM Cliente WHERE id = '{id}' ORDER BY nome ASC";
            DataTable dt = dal.RetDataTable(sql);

                item = new ClienteModel
                {
                    Id = dt.Rows[0]["Id"].ToString(),
                    Nome = dt.Rows[0]["Nome"].ToString(),
                    CPF = dt.Rows[0]["cpf_cnpj"].ToString(),
                    Email = dt.Rows[0]["Email"].ToString(),
                    Senha = dt.Rows[0]["Senha"].ToString()
                };

            return item;
        }

        public void Gravar()
        {
            DAL dal = new DAL();
            string sql = string.Empty;
            if (Id != null)
            {
                 sql = $"UPDATE Cliente SET NOME='{Nome}', CPF_CNPJ='{CPF}', EMAIL='{Email}' WHERE ID = '{Id}'";
            }
            else
            {
                DAL dalID = new DAL();
                string sqlID = "SELECT MAX(CAST(ID AS INT))+1 FROM Cliente";
                DataTable dtID = dalID.RetDataTable(sqlID);
                string ID = dtID.Rows[0][0].ToString();
                if (string.IsNullOrEmpty(ID))
                {
                    ID = ID + 1;
                    sql = $"INSERT INTO Cliente(ID,NOME, CPF_CNPJ, EMAIL, SENHA) VALUES ('{ID}','{Nome}','{CPF}','{Email}', '123456')";

                }
                else
                {
                    sql = $"INSERT INTO Cliente(ID,NOME, CPF_CNPJ, EMAIL, SENHA) VALUES ('{ID}','{Nome}','{CPF}','{Email}', '123456')";
                }



                    

            }

            dal.ExecutarComandoSQL(sql);
        }

        public void Excluir(int id)
        {
            DAL dal = new DAL();
            string sql = $"DELETE FROM Cliente WHERE ID ='{id}'";
            dal.ExecutarComandoSQL(sql);
        }

    }
}

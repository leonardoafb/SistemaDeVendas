using SistemaDeVendas.Uteis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Models
{
    public class LoginModel
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o seu e-mail de usuário")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string Senha { get; set; }


        public bool ValidarLogin()
        {
            string sql = $"SELECT ID, NOME FROM VENDEDOR WHERE EMAIL=@email AND SENHA=@senha";
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@email", Email);
            command.Parameters.AddWithValue("@senha", Senha);

            DAL dal = new DAL();
            DataTable dt = dal.RetDataTable(command);
            if (dt.Rows.Count == 1)
            {
                Id = dt.Rows[0]["ID"].ToString();
                Nome = dt.Rows[0]["NOME"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


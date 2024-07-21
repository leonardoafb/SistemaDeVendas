using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeVendas.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeVendas.Models
{
    public class SenhaModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "A Senha atual está incorreta")]
        public string SenhaAtual { get; set; }

        public string Senha1 { get; set; }

        
        public string Senha2 { get; set; }

        


        public void AlterarSenha()
        {
            DAL dal = new DAL();
            string sql = string.Empty;
            if (Id != null)
            {
                sql = $"UPDATE Vendedor SET Senha='{Senha2}' WHERE ID = '{Id}'";
            }           
            

            dal.ExecutarComandoSQL(sql);
        }


    }
}

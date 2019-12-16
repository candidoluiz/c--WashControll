using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace WashControl.repository.dao
{
    class ConnectionFactory
       
    {
        private string strConn = "Server=localhost;Database=washcontroll;Uid=root;Pwd=";
        private MySqlConnection con;
        private MySqlCommand cmd;
        private DataTable data;
        private MySqlDataAdapter da;
        private MySqlCommandBuilder cb;

        public  MySqlConnection Conectar()
        {
            try
            {
                con = new MySqlConnection(strConn);
                con.Open();
                return con;
            }
            catch (Exception e)
            {
                throw new Exception(e.StackTrace+" Erro ao tentar acessar o banco de dados");
            }
        }

        public void Desconectar()
        {
            try
            {
                con = new MySqlConnection();
                con.Close();
            }
            catch (Exception e)
            {

                throw new Exception(e.StackTrace + " Erro ao tentar fechar o banco de dados");
            }
        }

        public bool ExecutarComandoSql(string sql)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.StackTrace + " Erro ao tentar executar comando sql");
            }
        }

        public DataTable RetornarDataTable(string sql)
        {
            try
            {
                Conectar();
                data = new DataTable();
                da = new MySqlDataAdapter(sql, con);
                cb = new MySqlCommandBuilder(da);
                da.Fill(data);
                Desconectar();
                return data;
            }
            catch (Exception e)
            {

                throw new Exception(e.StackTrace + " Erro ao tentar retornar um DataTable");
            }
            
        }
    }
}

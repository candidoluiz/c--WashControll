using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashControl.model;

namespace WashControl.repository.dao
{
    class EmpresaDao
    {
        ConnectionFactory db = new ConnectionFactory();
        DataTable dt;
        string sql;

        public bool inserir(Empresa empresa)
        {
            return true;
        } 

        public DataTable listar()
        {
            sql = "select * from empresa";
            dt = new DataTable();
            db.Conectar();
            dt = db.RetornarDataTable(sql);
            return dt;

        }
    }
}

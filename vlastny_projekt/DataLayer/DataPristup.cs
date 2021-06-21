using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace vlastny_projekt.DataLayer
{
    internal class DataPristup : IDisposable
    {
        private IDbConnection _pripojenie;
        private IDbTransaction _transakcia;
        private bool _zatvorena = false;
        public string ZiskajCnnString(string meno)
        {
            return ConfigurationManager.ConnectionStrings[meno].ConnectionString;
        }

        public List<T> NacitajData<T, U>(string ulozenaProcedura, U parametre, string cnnMeno)
        {
            var cnnString = ZiskajCnnString(cnnMeno);
            using (var pripojenie = new SqlConnection(cnnString))
            {
                List<T> nacitaneData = pripojenie.Query<T>(ulozenaProcedura, parametre,
                    commandType: CommandType.StoredProcedure).ToList();
                return nacitaneData;
            }
        }
        public void UlozData<T>(string ulozenaProcedura, T parametre, string cnnMeno)
        {
            var cnnString = ZiskajCnnString(cnnMeno);
            using (var pripojenie = new SqlConnection(cnnString))
            {
                pripojenie.Execute(ulozenaProcedura, parametre,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<T> NacitajDataTransakcia<T, U>(string ulozenaProcedura, U parametre)
        {
            
            List<T> nacitaneData = _pripojenie.Query<T>(ulozenaProcedura, parametre,
                commandType: CommandType.StoredProcedure, transaction: _transakcia).ToList();
            return nacitaneData;
        }
        public void UlozDataTransakcia<T>(string ulozenaProcedura, T parametre)
        {

            _pripojenie.Execute(ulozenaProcedura, parametre,
                commandType: CommandType.StoredProcedure, transaction: _transakcia);

        }

        public void ZacatTransakciu(string cnnMeno)
        {
            var cnnString = ZiskajCnnString(cnnMeno);

            _pripojenie = new SqlConnection(cnnString);
            _pripojenie.Open();
            _transakcia = _pripojenie.BeginTransaction();

            _zatvorena = false;
        }

        public void CommitTrasnakcia()
        {
            _transakcia?.Commit();
            _pripojenie?.Close();

            _zatvorena = true;
        }

        public void RollbackTransakcia()
        {
            _transakcia?.Rollback();
            _pripojenie?.Close();
           
            _zatvorena = true;
        }

        public void Dispose()
        {
            if (_zatvorena == false)
            {
                try
                {
                    CommitTrasnakcia();
                }
                catch
                { }
            }
            _transakcia = null;
            _pripojenie = null;
        }
    }
}

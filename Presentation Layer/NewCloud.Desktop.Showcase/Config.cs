using System.Configuration;
using NewCloud.ApplicationServer.Dal;
using NewCloud.ApplicationServer.Entities;

namespace NewCloud.Desktop.Showcase
{
    public static class Config
    {
        private static string _sqlConnectionString;

        private static NewCloudModel _model;

        private static DaoRegistry _dao;

        public static string SqlConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_sqlConnectionString))
                    _sqlConnectionString =
                        ConfigurationManager.ConnectionStrings[
                            ConnectionNameHelper.GetName(ConfigConnection.NewCloudConnection)].ToString();
                return _sqlConnectionString;
            }
        }

        public static NewCloudModel Model
        {
            get { return _model ?? (_model = CreateModel()); }
            set { _model = value; }
        }

        public static DaoRegistry Dao => _dao ?? (_dao = new DaoRegistry(Model));

        public static NewCloudModel CreateModel()
            => new NewCloudModel("name=" + ConnectionNameHelper.GetName(ConfigConnection.NewCloudConnection));
    }
}
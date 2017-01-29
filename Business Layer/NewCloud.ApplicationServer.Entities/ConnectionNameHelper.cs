using System;

namespace NewCloud.ApplicationServer.Entities
{
    public enum ConfigConnection
    {
        NewCloudConnection
    }

    public static class ConnectionNameHelper
    {
        public static string GetName(ConfigConnection configConnection)
        {
            var machineName = Environment.MachineName;

            if (machineName.ToLower() == "acerv3")
                switch (configConnection)
                {
                    case ConfigConnection.NewCloudConnection:
                        return "ACERV3_NewCloudConnection";
                    default:
                        throw new NotImplementedException();
                }
            if (machineName.ToLower() == "asusx200m")
                switch (configConnection)
                {
                    case ConfigConnection.NewCloudConnection:
                        return "ASUSX200M_NewCloudConnection";
                    default:
                        throw new NotImplementedException();
                }
            throw new NotImplementedException("Unknown Machinename: '" + machineName + "'");
        }
    }
}
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace NewCloud.ApplicationServer.Entities
{
    public partial class NewCloudModel
    {
        public NewCloudModel(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public ObjectContext ObjectContext => ((IObjectContextAdapter) this).ObjectContext;

        public void Detach(object entity)
        {
            if (entity != null)
                ObjectContext.Detach(entity);
        }

        public void ChangeObjectState(object entity, EntityState entityState)
        {
            if (entity != null)
                ObjectContext.ObjectStateManager.ChangeObjectState(entity, entityState);
        }

        public ObjectResult<TOutput> FunctionTableValue<TOutput>(string functionName, SqlParameter[] parameters)
        {
            parameters = parameters ?? new SqlParameter[] {};

            var commandText =
                $"SELECT * FROM dbo.{$"{functionName}({string.Join(",", parameters.Select(x => x.ParameterName))})"}";

            return ObjectContext.ExecuteStoreQuery<TOutput>(commandText, parameters);
        }
    }
}
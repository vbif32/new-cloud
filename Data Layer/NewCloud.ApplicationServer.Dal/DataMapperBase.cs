using System;
using System.Data.Entity.Validation;
using NewCloud.ApplicationServer.Entities;

namespace Mirea.ProCat.ApplicationServer.Dal
{
    /// <summary>
    ///     Реализуем шаблон Repository
    ///     <see
    ///         cref="http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application" />
    /// </summary>
    public abstract class DataMapperBase : IDisposable
    {
        private bool _disposed;
        protected NewCloudModel _model;

        protected DataMapperBase()
        {
        }

        protected DataMapperBase(NewCloudModel model) : this()
        {
            _model = model;
        }

        public NewCloudModel Model => _model;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            try
            {
                Model.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var errorMessage = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    errorMessage += Environment.NewLine +
                                    $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}";
                throw new Exception(errorMessage, dbEx);
            }
            catch (Exception e)
            {
                // TODO
                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    Model.Dispose();
            _disposed = true;
        }
    }
}
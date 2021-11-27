using System.Data.SqlClient;

namespace DataAccess
{
   public abstract class DataReaderDelegate<T> : DataDelegate, IDataReaderDelegate<T>
   {
      protected DataReaderDelegate(string procedureName)
         : base(procedureName)
      {
      }

      public abstract T Translate(SqlCommand command, IDataRowReader reader);
   }
}
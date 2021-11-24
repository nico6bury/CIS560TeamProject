using System.Data.SqlClient;

namespace DataAccess
{
   public interface IDataDelegate
   {
      string ProcedureName { get; }

      void PrepareCommand(SqlCommand command);
   }
}
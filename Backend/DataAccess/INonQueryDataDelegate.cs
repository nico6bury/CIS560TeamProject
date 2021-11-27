using System.Data.SqlClient;

namespace DataAccess
{
   public interface INonQueryDataDelegate<out T> : IDataDelegate
   {
      T Translate(SqlCommand command);
   }
}
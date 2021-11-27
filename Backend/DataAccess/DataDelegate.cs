using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
   public abstract class DataDelegate : IDataDelegate
   {
      public string ProcedureName { get; }

      protected DataDelegate(string procedureName)
      {
         if (string.IsNullOrWhiteSpace(procedureName))
            throw new ArgumentException("The procedure name cannot be null or empty.", nameof(procedureName));

         ProcedureName = procedureName;
      }

      public virtual void PrepareCommand(SqlCommand command)
      {
         command.CommandType = CommandType.StoredProcedure;
      }
   }
}
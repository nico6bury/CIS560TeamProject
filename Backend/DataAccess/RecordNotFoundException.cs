using System;
using System.Runtime.Serialization;

namespace DataAccess
{
   [Serializable]
   public class RecordNotFoundException : Exception
   {
      public RecordNotFoundException(string key)
         : base($"The requested record with key [{key}] does not exist.")
      {
      }

      protected RecordNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext)
         : base(serializationInfo, streamingContext)
      {
      }
   }
}

using System.Collections.Generic;
using Member.Data.Models;

namespace Member.Data.Interface {
    public interface IMembers {
        List<Members> GetAllMember();
        Members GetMember(int id);

        void Add(Members item);
        Members Find(string key);
        Members Remove(string key);
        void Update(Members item);
    }
}
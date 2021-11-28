using Member.Data.Interface;
using Member.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Member.Data.Repository {
    public class MembersRepository : IMembers {
        List<Members> lisMembers = new List<Members>
        {
            new Members{userId=1, userName="sdiener", password="Shah"},
            new Members{userId=2, userName="Nitya", password="Shah" },
            new Members{userId=3, userName="Dilip", password="Shah"},

        };

        public MembersRepository() {
            Add(new Members { userName = "Item1" });
        }

        public List<Members> GetAllMember() {
            return lisMembers;
        }

        public Members GetMember(int id) {
            return lisMembers.FirstOrDefault(x => x.userId == id);
        }

        public void Add(Members item) {
            item.userId = 65;
            lisMembers.Add(item);
        }

        public Members Find(string key) {
            return lisMembers[1];
        }

        public Members Remove(string key) {
            Members item = new Members();
            lisMembers.Remove(item);
            return item;
        }

        public void Update(Members item) {
            lisMembers[0] = item;
        }

    }
}
using RocksDbSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atom.HR.WebAssistant.Areas.Account
{
    public class AccountStoreHolder
    {
        private static Lazy<RocksDb> store = new Lazy<RocksDb>(CreateStore);
        public static RocksDb Store => store.Value;
      
        private static RocksDb CreateStore()
        {
            var options = new DbOptions().SetCreateIfMissing(true);
            using (var db = RocksDb.Open(options, "accountdb"))
            {
                return db;
            }            
        }

    }
}

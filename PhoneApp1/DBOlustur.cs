using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace MaksiYakit
{
    public class YakitlarDataContext : DataContext

    {

        public const string ConnectionString = "isostore:/yakitlar.sdf";
        public Table<Yakit> Yakitlar { get; set; }

        public YakitlarDataContext(string connectionString)
            : base(connectionString)
        { this.Yakitlar = this.GetTable<Yakit>(); }
    
    
    }
    class DBOlustur
    {

    }
}

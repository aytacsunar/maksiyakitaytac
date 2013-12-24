using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace MaksiYakit
{
    [Table(Name="Yakitlar")]
    public class Yakit
    {
        [Column(IsPrimaryKey = true, Name = "YakitNo")]
        public int YakitNo { get; set; }

        [Column(Name="TuketilenYakitMiktari")]
        public decimal TuketilenYakitMiktari { get; set; }
        
        [Column(Name = "HarcananTLMiktari")]
        public decimal HarcananTLMiktari { get; set; }

        [Column(Name = "GidilenKMMiktari")]
        public decimal GidilenKMMiktari { get; set; }

        [Column(Name = "YakitBirimFiyati")]
        public decimal YakitBirimFiyati { get; set; }

        [Column(Name = "KM1TLSonuc")]
        public decimal KM1TLSonuc { get; set; }

        [Column(Name = "KM1LTSonuc")]
        public decimal KM1LTSonuc { get; set; }

        [Column(Name = "KM100TLSonuc")]
        public decimal KM100TLSonuc { get; set; }

        [Column(Name = "KM100LTSonuc")]
        public decimal KM100LTSonuc { get; set; }

        [Column(Name = "KayitAdi")]
        public string KayitAdi { get; set; }

        [Column(Name = "KayitTarihi")]
        public DateTime KayitTarihi { get; set; }

    }
}

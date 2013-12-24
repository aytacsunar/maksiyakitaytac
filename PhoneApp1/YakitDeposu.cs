using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaksiYakit
{
    public class YakitDeposu
    {
        public static void Baslat()
        {
            YakitlarDataContext bst = new YakitlarDataContext(YakitlarDataContext.ConnectionString);
            if (bst.DatabaseExists()==false)
            {
                bst.CreateDatabase();
                bst.SubmitChanges();
            }
            
           
        
        
        }
        
        /*private static void VeriEkle()
        {
            YakitlarDataContext bst = new YakitlarDataContext(YakitlarDataContext.ConnectionString);
            bst.Yakitlar.InsertOnSubmit(new Yakit(
        
        }*/

    }
}

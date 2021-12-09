using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOIR.Infrastructure;

namespace TOIR.Models
{
    // ТО для списка
    internal class TO
    {
        public int ID { get; set; }
        public KindTO kindTO { get; set; }               // вид ТО
        public string Name { get; set; }                // наименование ТО
        public int WarrantyMonth { get; set; }          // действие гарантии в месяцах
        public List<Works> listWorks { get; set; }      // список работ для ТО
        public List<WorkForTO> listWorkTO { get; set; } // список работ на выполнение
    }
}

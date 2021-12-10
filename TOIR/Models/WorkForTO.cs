using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOIR.Models
{
    // Работа с отметкой для проведения ТО
    internal class WorkForTO : Works
    {
        //public int ID { get; set; }
        public int TO_ID { get; set; }           // ID для ТО
        public bool CheckedTO { get; set; }     // флаг работа проведена

        //public Works work { get; set; }         // ссылка на работу
        //public int WorkID { get; set; }         // ID для работы

        public WorkForTO(Works parent)
        {
            ID = parent.ID;
            Num = parent.Num;
            Name = parent.Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOIR.Models
{
    internal class WorkForTO
    {
        public int ID { get; set; }
        public int TOID { get; set; }           // ID для ТО
        public int WorkID { get; set; }         // ID для работы
        public bool CheckedTO { get; set; }     // флаг работа проведена
        public Works work { get; set; }         // ссылка на работу

    }
}

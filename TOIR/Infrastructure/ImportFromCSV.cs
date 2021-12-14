using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOIR.Models;

namespace TOIR.Infrastructure
{
    internal class ImportFromCSV
    {
        EquipTO to;

        public ImportFromCSV(EquipTO t)
        {
            to = t;
        }

        public void LoadFromCSV(string FileName)
        {
            string[] lines = File.ReadAllLines(FileName);
            foreach(string s in lines)
            {
                string[] split = s.Split( new char[] { ';', ',' });
                int num = int.Parse(split[0]);

                WorkForTO wft =  to.listWorkTO.Where(w => w.Num == num).FirstOrDefault();
                if(wft != null)
                {
                    wft.CheckedTO = int.Parse(split[1]) == 1;
                }

            }
        }
    }
}

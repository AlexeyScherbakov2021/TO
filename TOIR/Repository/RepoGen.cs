using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOIR.Infrastructure;
using TOIR.Models;

namespace TOIR.Repository
{
    internal class RepoGen : IRepository
    {
        List<Works> listWorks;
        List<TO> listTO;

        public RepoGen()
        {
            listWorks = GetListWorks();
            listTO = GetListTO();
        }

        //------------------------------------------------------------------------------------------------------------
        // получение текущего планового ТО для указанного оборудования
        //------------------------------------------------------------------------------------------------------------
        public void GetCurrentPlanTO(Equip eqip)
        {
            eqip.PlanTO = eqip.listPlanTO.Where(r => r.DateSet.Year < 2000 ).FirstOrDefault();
        }

        //------------------------------------------------------------------------------------------------------------
        // получение текущего регламентного ТО для указанного оборудования
        //------------------------------------------------------------------------------------------------------------
        public void GetCurrentReglamentTO(Equip eqip)
        {
            eqip.ReglamentTO = eqip.listReglamnetTO.Where(r => r.DateSet.Year < 2000).FirstOrDefault();
        }

        //------------------------------------------------------------------------------------------------------------
        // получение списка обрудования
        //------------------------------------------------------------------------------------------------------------
        public List<Equip> GetListEquipment()
        {
            List<Equip> list = new List<Equip>()
            {
                new Equip() { ID = 1, DateStart = new DateTime(2018, 3, 4), Name = "КИП №2"},
                new Equip() { ID = 2, DateStart = new DateTime(2016, 2, 28), Name = "КИП №4"},
                new Equip() { ID = 3, DateStart = new DateTime(2019, 5, 1), Name = "КИП №12"},
                new Equip() { ID = 4, DateStart = new DateTime(2017, 3, 10), Name = "КИП №16"},
                new Equip() { ID = 5, DateStart = new DateTime(2018, 11, 5), Name = "КИП №20"},
            };

            foreach(Equip e in list)
            {
                GetListPlanTO(e);
                GetListReglamentTO(e);
                GetCurrentPlanTO(e);
                GetCurrentReglamentTO(e);
                e.EndWarranty = e.ReglamentTO.DatePlan;
            }

            return list;
        }

        //------------------------------------------------------------------------------------------------------------
        // получение планового ТО для указанного оборудования
        //------------------------------------------------------------------------------------------------------------
        public void GetListPlanTO(Equip eqip)
        {

            switch(eqip.ID)
            {
                case 1:
                    eqip.listPlanTO = new ObservableCollection<EquipTO>()
                    {
                        new EquipTO(listTO[0]) { equip = eqip, DatePlan = new DateTime(2018, 2, 15), EqipID = eqip.ID, DateSet = new DateTime(2018, 8, 10) },
                        new EquipTO(listTO[0]) { equip = eqip, DatePlan = new DateTime(2019, 2, 10), EqipID = eqip.ID }
                    };
                    break;
                case 2:
                    eqip.listPlanTO = new ObservableCollection<EquipTO>()
                    {
                        new EquipTO(listTO[0]) { equip = eqip, DatePlan = new DateTime(2019, 12, 5), EqipID = eqip.ID, DateSet = new DateTime(2020, 5, 1) },
                        new EquipTO(listTO[0]) { equip = eqip, DatePlan = new DateTime(2020, 12, 10), EqipID = eqip.ID }
                    };
                    break;
                case 3:
                    eqip.listPlanTO = new ObservableCollection<EquipTO>()
                    {
                        new EquipTO(listTO[0]) { equip = eqip, DatePlan = new DateTime(2018, 3, 8), EqipID = eqip.ID, DateSet = new DateTime(2018, 9, 7) },
                        new EquipTO(listTO[0]) { equip = eqip, DatePlan = new DateTime(2019, 3, 7), EqipID = eqip.ID }
                    };
                    break;
                case 4:
                    eqip.listPlanTO = new ObservableCollection<EquipTO>()
                    {
                        new EquipTO(listTO[0]) { equip = eqip, DatePlan = new DateTime(2019, 7, 24), EqipID = eqip.ID, DateSet = new DateTime(2020, 1, 22) },
                        new EquipTO(listTO[0]) { equip = eqip, DatePlan = new DateTime(2020, 7, 22), EqipID = eqip.ID }
                    };
                    break;
                case 5:
                    eqip.listPlanTO = new ObservableCollection<EquipTO>()
                    {
                        new EquipTO(listTO[0]) { equip = eqip, DatePlan = new DateTime(2018, 2, 15), EqipID = eqip.ID, DateSet = new DateTime(2018, 8, 10) },
                        new EquipTO(listTO[0]) { equip = eqip, DatePlan = new DateTime(2019, 2, 10), EqipID = eqip.ID }
                    };
                    break;

            }


        }

        //------------------------------------------------------------------------------------------------------------
        // получение регламентного ТО для указанного оборудования
        //------------------------------------------------------------------------------------------------------------
        public void GetListReglamentTO(Equip eqip)
        {
            switch (eqip.ID)
            {
                case 1:
                    eqip.listReglamnetTO = new ObservableCollection<EquipTO>()
                    {
                        new EquipTO(listTO[1]) { DatePlan = new DateTime(2019, 3, 5), EqipID = eqip.ID, DateSet = new DateTime(2020, 2, 7) },
                        new EquipTO(listTO[2]) { DatePlan = new DateTime(2020, 6, 15), EqipID = eqip.ID, DateSet = new DateTime(2021, 11, 10) },
                        new EquipTO(listTO[2]) { DatePlan = new DateTime(2020, 6, 15), EqipID = eqip.ID, DateSet = new DateTime(2021, 11, 10) },
                        new EquipTO(listTO[2]) { DatePlan = new DateTime(2021, 12, 24), EqipID = eqip.ID },
                    };
                    break;
                case 2:
                    eqip.listReglamnetTO = new ObservableCollection<EquipTO>()
                    {
                        new EquipTO(listTO[1]) { DatePlan = new DateTime(2019, 3, 5), EqipID = eqip.ID, DateSet = new DateTime(2020, 2, 7) },
                        new EquipTO(listTO[2]) { DatePlan = new DateTime(2023, 6, 2), EqipID = eqip.ID },
                    };
                    break;
                case 3:
                    eqip.listReglamnetTO = new ObservableCollection<EquipTO>()
                    {
                        new EquipTO(listTO[1]) { DatePlan = new DateTime(2019, 3, 5), EqipID = eqip.ID, DateSet = new DateTime(2020, 2, 7) },
                        new EquipTO(listTO[2]) { DatePlan = new DateTime(2020, 6, 15), EqipID = eqip.ID, DateSet = new DateTime(2021, 11, 10) },
                        new EquipTO(listTO[2]) { DatePlan = new DateTime(2020, 6, 15), EqipID = eqip.ID, DateSet = new DateTime(2021, 11, 10) },
                        new EquipTO(listTO[2]) { DatePlan = new DateTime(2020, 6, 15), EqipID = eqip.ID, DateSet = new DateTime(2021, 11, 10) },
                        new EquipTO(listTO[2]) { DatePlan = new DateTime(2022, 1, 11), EqipID = eqip.ID },
                    };
                    break;
                case 4:
                    eqip.listReglamnetTO = new ObservableCollection<EquipTO>()
                    {
                        new EquipTO(listTO[1]) { DatePlan = new DateTime(2019, 3, 5), EqipID = eqip.ID, DateSet = new DateTime(2020, 2, 7) },
                        new EquipTO(listTO[2]) { DatePlan = new DateTime(2020, 6, 15), EqipID = eqip.ID, DateSet = new DateTime(2021, 11, 10) },
                        new EquipTO(listTO[2]) { DatePlan = new DateTime(2020, 6, 15), EqipID = eqip.ID, DateSet = new DateTime(2021, 11, 10) },
                        new EquipTO(listTO[2]) { DatePlan = new DateTime(2022, 8, 20), EqipID = eqip.ID },
                    };
                    break;
                case 5:
                    eqip.listReglamnetTO = new ObservableCollection<EquipTO>()
                    {
                        new EquipTO(listTO[1]) { DatePlan = new DateTime(2019, 3, 5), EqipID = eqip.ID, DateSet = new DateTime(2020, 2, 7) },
                        new EquipTO(listTO[2]) { DatePlan = new DateTime(2020, 6, 15), EqipID = eqip.ID, DateSet = new DateTime(2021, 11, 10) },
                        new EquipTO(listTO[2]) { DatePlan = new DateTime(2023, 2, 4), EqipID = eqip.ID },
                    };
                    break;

            }

        }

        //------------------------------------------------------------------------------------------------------------
        // получение списка ТО
        //------------------------------------------------------------------------------------------------------------
        public List<TO> GetListTO()
        {
            List<TO> list = new List<TO>()
            {
                new TO() { ID=1, WarrantyMonth=6, kindTO = KindTO.Planned, Name = "Плановое ТО" },
                new TO() { ID=2, WarrantyMonth=24, kindTO = KindTO.TO1, Name = "ТО-1", NumTO = 1},
                new TO() { ID=3, WarrantyMonth=12, kindTO = KindTO.TO2, Name = "ТО-2", NumTO = 2},
                new TO() { ID=4, WarrantyMonth=12, kindTO = KindTO.TOLong, Name = "ТО-3", NumTO = 3 },
            };

            // привязка работ для каждого ТО
            foreach (TO t in list)
                GetListWorkForTO(t);

            return list;
        }


        //------------------------------------------------------------------------------------------------------------
        // получение списка работ для указанного ТО
        //------------------------------------------------------------------------------------------------------------
        public void GetListWorkForTO(TO to)
        {
            int[] arrayPlannned = new int[] { 0,1,3,4,5,6,7,14,18,23,26};
            int[] arrayTO1 = new int[] { 0,1,2,3,4,5,6,7,8,9,10,14,17,18,19,20,23,25,26,27,28,29};
            int[] arrayTO2 = new int[] { 0,1,2,3,4,5,6,7,8,9,10,12,13,15,16,17,18,19,20,21,22,24,25,26,27,28,29};
            int[] arrayTOLong = new int[] { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,15,16,17,18,19,20,21,22,24,25,26,27,28,29};

            to.listWorks = new ObservableCollection<Works>();
            switch (to.kindTO)
            {
                case KindTO.Planned:
                    foreach(int i in arrayPlannned)
                        to.listWorks.Add(listWorks[i]);
                    break;

                case KindTO.TO1:
                    foreach (int i in arrayTO1)
                        to.listWorks.Add(listWorks[i]);
                    break;

                case KindTO.TO2:
                    foreach (int i in arrayTO2)
                        to.listWorks.Add(listWorks[i]);
                    break;

                default:
                    foreach (int i in arrayTOLong)
                        to.listWorks.Add(listWorks[i]);
                    break;
            }



        }

        //------------------------------------------------------------------------------------------------------------
        // получение общего списка работ
        //------------------------------------------------------------------------------------------------------------
        public List<Works> GetListWorks()
        {
            List<Works> listWorks = new List<Works>()
            {
                new Works() { ID =  1, Num =  1, Name = "Внешний осмотр шкафа и всех модулей на наличие повреждений, следов коррозии, ослабления крепежных винтов и сочленений электрических разъёмов и контактов." },
                new Works() { ID =  2, Num =  2, Name = "Проверка сопротивления заземления между шкафом и общей шиной." },
                new Works() { ID =  3, Num =  3, Name = "Проверка целостности УЗИП." },
                new Works() { ID =  4, Num =  4, Name = "Проверка энкодеров и кнопок НГК-БУ-Евро на работоспособность. Проверка дисплея на отсутствие внешних повреждений." },
                new Works() { ID =  5, Num =  5, Name = "Проверка автоматических выключателей на чёткую фиксацию в каждом из положений." },
                new Works() { ID =  6, Num =  6, Name = "Проверка возможности изменения выходных параметров. Переключение в режимы стабилизации выходного тока, напряжения защитного потенциала и поддержание установленных параметров на основной и резервной СКЗ." },
                new Works() { ID =  7, Num =  7, Name = "Проверка автоматического включения резервной СКЗ." },
                new Works() { ID =  8, Num =  8, Name = "Проверка автоматического восстановления режима работы после возобновления электропитания." },
                new Works() { ID =  9, Num =  9, Name = "Проверка электрической прочности изоляции главных и управляющих цепей." },
                new Works() { ID = 10, Num = 10, Name = "Проверка конфигурации НГК БУ  Евро, при необходимости переконфигурирование НГК БУ  Евро с помощью специализированного ПО, обновление прошивки (при необходимости)." },
                new Works() { ID = 11, Num = 11, Name = "Проверка точностных характеристик НГК БУ Евро при необходимости юстировка НГК БУ Евро." },
                new Works() { ID = 12, Num = 12, Name = "Оценка состояния индикатора НГК БУ Евро, при необходимости замена." },
                new Works() { ID = 13, Num = 13, Name = "Оценка состояния модулей силовых (выход на номинальную нагрузку, поддержание максимальной мощности, снятие тепловых значений при максимальной мощности)." },
                new Works() { ID = 14, Num = 14, Name = "Проверка интерфейса RS-485 с помощью портативного компьютера и осциллографа через линию связи КМО НГК-ИПКЗ-Евро с аппаратурой системы телемеханики." },
                new Works() { ID = 15, Num = 15, Name = "Проверка работоспособности АКБ (при наличии)." },
                new Works() { ID = 16, Num = 16, Name = "Оценка состояния АКБ (при наличии)." },
                new Works() { ID = 17, Num = 17, Name = "Оценка состояния контакторов и реле (при необходимости замена)." },
                new Works() { ID = 18, Num = 18, Name = "Проверка включения вентиляторов охлаждения шкафа (при наличии)." },
                new Works() { ID = 19, Num = 19, Name = "Внешний осмотр НГК-КИП на наличие повреждений, следов коррозии болтовых соединений, протяжка контактов." },
                new Works() { ID = 20, Num = 20, Name = "Проверка состояния УЗИП КИП С (ИКП)." },
                new Works() { ID = 21, Num = 21, Name = "Проверка передачи данных с датчика ИКП (при наличии)." },
                new Works() { ID = 22, Num = 22, Name = "Проверка конфигурации НГК-КССМ, переконфигурирование НГК-КССМ с помощью специализированного ПО, обновление прошивки (при необходимости)." },
                new Works() { ID = 23, Num = 23, Name = "Оценка состояния индикатора НГК-КССМ (при наличии в составе КМО НГК-ИПКЗ-Евро системы коррозионного мониторинга НГК-КССМ), при необходимости замена." },
                new Works() { ID = 24, Num = 24, Name = "Проверка работоспособности АКБ (при наличии)." },
                new Works() { ID = 25, Num = 25, Name = "Оценка состояния АКБ (при наличии)." },
                new Works() { ID = 26, Num = 26, Name = "Проверка интерфейса RS-485 с помощью портативного компьютера и осциллографа через линию связи НГК-КССМ с аппаратурой системы телемеханики." },
                new Works() { ID = 27, Num = 27, Name = "Внешний осмотр НГК-КССМ на наличие повреждений, следов коррозии болтовых соединений, протяжка контактов." },
                new Works() { ID = 28, Num = 28, Name = "Проверка блока измерений (НГК-КИП-СМ)." },
                new Works() { ID = 29, Num = 29, Name = "Проверка УЗИП блока измерений (НГК-КИП-СМ)." },
                new Works() { ID = 30, Num = 30, Name = "Проверка интерфейса CAN от НГК-КИП до НГК-СКМ." },
            };

            return listWorks;
        }



        //------------------------------------------------------------------------------------------------------------
        // получение списка выполненных работ для ТО 
        //------------------------------------------------------------------------------------------------------------
        public ObservableCollection<WorkForTO> GetListWorkForTO(EquipTO et)
        {
            ObservableCollection<WorkForTO> listWT = new ObservableCollection<WorkForTO>();

            Random rnd = new Random();

            foreach (Works w in et.listWorks)
            {
                WorkForTO wt = new WorkForTO(w);
                wt.CheckedTO = rnd.Next(0, 100) >= 10;
                listWT.Add(wt);
            }


            return listWT;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TOIR.Models
{
    // Наименование работы для списка в ТО
    internal class Works : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public int Num { get; set; }
        public string Name { get; set; }

        #region
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
        #endregion

    }
}

using System.ComponentModel;

namespace курсовой
{
    public class VM : INotifyPropertyChanged
    {
       
            public event PropertyChangedEventHandler PropertyChanged;

            public void OnProperty(string name)// Когда объект класса изменяет значение свойства, то он через событие PropertyChanged извещает систему об изменении свойства.А система обновляет все привязанные объекты.

            {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        }
    }


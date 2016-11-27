using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConfigManager.Helpers
{
    public interface ISavable<T> where T : new()
    {
        void Save(T objectToSave, [CallerMemberName] string propertyName = null);
    }
}

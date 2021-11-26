using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.MVVM.Interfaces
{
    public interface IEntity<TKey>
        where TKey : struct //Oblige que TKey soit de type valeur
    {
        TKey ID { get; }
    }
}

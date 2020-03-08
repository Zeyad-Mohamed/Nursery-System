using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public interface ISubject
    {
        public void AddObserver(IObserver o);
        public void RemoveObserver(IObserver o);
        public void NotifyObserver();
    }
}

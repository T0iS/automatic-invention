using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJII_projekt
{
    class AppSet : IEnumerable
    {
        private List<Appartment> apps;


        public AppSet(int size)
        {
            this.apps = new List<Appartment>(size);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)apps).GetEnumerator();
        }
        public void Add(Appartment a)
        {
            this.apps.Add(a);
        }
        public int FindIndex(Predicate<Appartment> match)
        {
            return this.apps.FindIndex(match);
        }
        public Appartment Find(Predicate<Appartment> match)
        {
            return this.apps.Find(match);
        }

        public Appartment this[int index]
        {
            get
            {
                return this.apps[index];
            }
            set
            {
                this.apps[index] = value;
            }
        }


        public void Remove(Appartment a)
        {
            this.apps.Remove(a);
        }
    }
}

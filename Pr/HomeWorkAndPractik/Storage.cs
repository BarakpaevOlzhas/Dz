using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkAndPractik
{
    public abstract class Storage
    {
        public string name { set; get; }

        public string model { set; get; }

        public abstract double GetAmountOfMemory();

        public abstract void DataCopying(Directory directoryOne, Directory directoryTwo, double memory);

        public abstract double GetFreeAmountOfMemory();

        public abstract string GetGeneralInformation();

    }
}

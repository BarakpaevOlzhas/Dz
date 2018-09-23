using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkAndPractik
{
    class DVD : Storage
    {
        private Directory directory;

        public double ReadAndWriteSpeed { get; set; }

        private double _amountOfMemory;

        public double AmountOfBusyMemory { set; get; }

        private bool _typeDisk;

        public DVD(bool typeDisk)
        {
            ReadAndWriteSpeed = 500;

            _typeDisk = typeDisk;

            directory = new Directory();

            SetAmountOfMemory();
        }

        public void SetAmountOfMemory()
        {
            _amountOfMemory = _typeDisk ? 9216 : 4812.8;
        }

        public Directory GetDirectory()
        {
            return directory;
        }

        public override void DataCopying(Directory directoryOne, Directory directoryTwo, double memory)
        {
            if (directoryOne != null)
            {
                directoryOne = directoryTwo;

                this.AmountOfBusyMemory = memory;
            }
        }

        public override double GetAmountOfMemory()
        {
            return _amountOfMemory;
        }

        public override double GetFreeAmountOfMemory()
        {
            return _amountOfMemory - AmountOfBusyMemory;
        }

        public override string GetGeneralInformation()
        {
            return $"Память: {_amountOfMemory} \n Модель: {model} \n Скорость чтения: {ReadAndWriteSpeed}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkAndPractik
{
    class Flash : Storage
    {
        private Directory directory;

        private double _spedeUSB3 = 640;

        private double _amountOfMemory;

        public double AmountOfBusyMemory { set; get; }

        public Flash(int amountOfMemory)
        {
            _amountOfMemory = amountOfMemory;

            directory = new Directory();
        }

        public Directory GetDirectory()
        {
            return directory;
        }

        public void SetAmountOfMemory(double amountOfMemory)
        {
            _amountOfMemory = amountOfMemory;
        }

        public double GetSpedeUSB3()
        {
            return _spedeUSB3;
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
            return $"Память: {_amountOfMemory} \n Модель: {model} \n USB: 3.0";
        }
    }
}

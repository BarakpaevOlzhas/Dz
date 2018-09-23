using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkAndPractik
{
    class HDD : Storage
    {
        private double _amountOfMemory;

        public double AmountOfBusyMemory { get; set; }

        private int _numberOfSections;

        private int _volumeOfSections;

        private double _spedeUSB2 = 60;

        private Directory directory;

        public Directory GetDirectory()
        {
            return directory;
        }

        public double GetUsb2()
        {
            return _spedeUSB2;
        }

        public HDD(int numberOfSections, int volumeOfSections)
        {
            _amountOfMemory = numberOfSections * volumeOfSections;

            directory = new Directory();
        }

        public Directory GetDirectoryByIndex(int index)
        {
            return directory.GetDirectoryByIndex(index);
        }

        public File GetFileByIndex(int index)
        {
            return directory.GetFileByIndex(index);
        }

        public void SetNumberAndVolumeSections(int numberOfSections, int volumeOfSections)
        {
            _numberOfSections = numberOfSections;
            _volumeOfSections = volumeOfSections;
            _amountOfMemory = _volumeOfSections * _numberOfSections;
        }

        public override void DataCopying(Directory directoryOne ,Directory directoryTwo, double memory)
        {
            if(directoryOne != null)
            {
                directoryOne = directoryTwo;

                this.AmountOfBusyMemory = memory;

                //for (int i = 0;i < this.directory.NumberOfDirectory;i++)
                //{
                //    DataCopying(directoryOne, directory.GetDirectoryByIndex(i));
                //}
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
            return $"Память: {_amountOfMemory} \n Модель: {model} \n USB: 2.0";
        }
    }
}

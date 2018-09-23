using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkAndPractik
{
    class Program
    {
        static public void DownloadTime(double size, double speed)
        {
            double second = size / speed;

            Console.WriteLine($"{second}Сек");
        }

        static public double Show(Directory directory)
        {
            int choise;
            string name;
            double size;
            double masSize = 0;

            Console.Clear();
            Console.SetCursorPosition(0,0);

            for (int i = 0; i < directory.NumberOfDirectory + directory.NumberOfFiles; i++)
            {
                if (i < directory.NumberOfDirectory)
                {
                    Console.WriteLine($"{directory.GetDirectoryByIndex(i).Name}<DIR>");
                }

                else
                {
                    Console.WriteLine($"{directory.GetFileByIndex(i - directory.NumberOfDirectory).Name}<File>");
                }
            }
            
            Console.WriteLine("1)Создать папку");
            Console.WriteLine("2)Создать файл");
            Console.WriteLine("3)Выбрать папку");
            Console.WriteLine("0)Выход");

            int.TryParse(Console.ReadLine(),out choise);

            if (choise == 1)
            {
                Console.WriteLine("Введите имя");

                name = Console.ReadLine();

                directory.AddDirectory(name);
            }

            else if (choise == 2)
            {
                Console.WriteLine("Введите имя");

                name = Console.ReadLine();

                Console.WriteLine("Введите размер");

               double.TryParse(Console.ReadLine(),out size);

                directory.AddFile(size,name);

                masSize += size;
            }

            else if (choise == 3)
            {
                if (directory.NumberOfDirectory + directory.NumberOfFiles > 0)
                {
                    Console.WriteLine("Выберите папку");

                    int.TryParse(Console.ReadLine(), out choise);

                    if (choise <= directory.NumberOfDirectory && choise > 0)
                    {
                        masSize += Show(directory.GetDirectoryByIndex(choise - 1));
                    }
                }
            }

            else if (choise == 0)
            {
                return masSize;    
            }
            return masSize;
        }


        static void Main(string[] args)
        {
            int choise;
            HDD hDD = new HDD(50,8000);
            Flash flash = new Flash(50000);
            DVD dVD = new DVD(true);
            double size;
            string name;

            Console.SetCursorPosition(0, 0);

            do
            {
                Console.Clear();

                Console.WriteLine("1)HDD");
                Console.WriteLine("2)Flash");
                Console.WriteLine("3)DVD");
                Console.WriteLine("0)exit");

                int.TryParse(Console.ReadLine(), out choise);

                if(choise == 1)
                {
                    Console.WriteLine("1)AddFile");
                    Console.WriteLine("2)AddDir");
                    Console.WriteLine("3)Show");
                    Console.WriteLine("4)Copy");

                    int.TryParse(Console.ReadLine(), out choise);

                    if (choise == 1)
                    {                       
                        do
                        {
                            Console.WriteLine("Введите размер");

                            double.TryParse(Console.ReadLine(), out size);
                        }
                        while (size == 0);

                        if (hDD.GetAmountOfMemory() > hDD.AmountOfBusyMemory + size)
                        {
                            Console.WriteLine("Введите имя");

                            name = Console.ReadLine();

                            hDD.GetDirectory().AddFile(size, name);

                            hDD.AmountOfBusyMemory += size;
                        }
                        else
                        {
                            Console.WriteLine("Мало памяти");

                            Console.ReadLine();
                        }
                    }

                    else if(choise == 2)
                    {
                        Console.WriteLine("Введите имя");

                        name = Console.ReadLine();

                        hDD.GetDirectory().AddDirectory(name);
                    }

                    else if (choise == 3)
                    {
                        hDD.AmountOfBusyMemory += Show(hDD.GetDirectory());   
                    }
                    
                    else if (choise == 4)
                    {
                        Console.WriteLine("1)Flash");
                        Console.WriteLine("2)DVD");

                        int.TryParse(Console.ReadLine(),out choise);

                        if (choise == 1)
                        {
                            if (flash.AmountOfBusyMemory < hDD.GetFreeAmountOfMemory())
                            {
                                hDD.DataCopying(hDD.GetDirectory(), flash.GetDirectory(), flash.AmountOfBusyMemory);
                                DownloadTime(flash.AmountOfBusyMemory, hDD.GetUsb2());
                                Console.ReadLine();
                                Console.ReadLine();
                            }
                        }

                        else if (choise == 2)
                        {
                            if (dVD.AmountOfBusyMemory < hDD.GetFreeAmountOfMemory())
                            {
                                hDD.DataCopying(hDD.GetDirectory(), dVD.GetDirectory(), dVD.AmountOfBusyMemory);
                                DownloadTime(dVD.AmountOfBusyMemory, hDD.GetUsb2());
                                Console.ReadLine();
                                Console.ReadLine();
                            }                            
                        }
                    }
                }

                else if (choise == 2)
                {
                    Console.WriteLine("1)AddFile");
                    Console.WriteLine("2)AddDir");
                    Console.WriteLine("3)Show");
                    Console.WriteLine("4)copy");

                    int.TryParse(Console.ReadLine(), out choise);

                    if (choise == 1)
                    {
                        do
                        {
                            Console.WriteLine("Введите размер");

                            double.TryParse(Console.ReadLine(), out size);
                        }
                        while (size == 0);

                        if (flash.GetAmountOfMemory() > flash.AmountOfBusyMemory + size)
                        {
                            Console.WriteLine("Введите имя");

                            name = Console.ReadLine();

                            flash.GetDirectory().AddFile(size, name);

                            flash.AmountOfBusyMemory += size;
                        }
                        else
                        {
                            Console.WriteLine("Мало памяти");
                        }
                    }

                    else if(choise == 2)
                    {
                        Console.WriteLine("Введите имя");

                        name = Console.ReadLine();

                        flash.GetDirectory().AddDirectory(name);
                    }

                    else if (choise == 3)
                    {
                        flash.AmountOfBusyMemory += Show(flash.GetDirectory());
                    }

                    else if (choise == 4)
                    {
                        Console.WriteLine("1)HDD");
                        Console.WriteLine("2)DVD");

                        int.TryParse(Console.ReadLine(), out choise);

                        if (choise == 1)
                        {
                            if (hDD.AmountOfBusyMemory < flash.GetFreeAmountOfMemory())
                            {
                                flash.DataCopying(flash.GetDirectory(), hDD.GetDirectory(), hDD.AmountOfBusyMemory);
                                DownloadTime(hDD.AmountOfBusyMemory, flash.GetSpedeUSB3());
                                Console.ReadLine();
                                Console.ReadLine();
                            }
                        }

                        else if (choise == 2)
                        {
                            if (dVD.AmountOfBusyMemory < flash.GetFreeAmountOfMemory())
                            {
                                flash.DataCopying(flash.GetDirectory(), dVD.GetDirectory(), dVD.AmountOfBusyMemory);
                                DownloadTime(dVD.AmountOfBusyMemory, flash.GetSpedeUSB3());
                                Console.ReadLine();
                                Console.ReadLine();
                            }
                        }
                    }

                }

                else if (choise == 3)
                {
                    Console.WriteLine("1)AddFile");
                    Console.WriteLine("2)AddDir");
                    Console.WriteLine("3)Show");
                    Console.WriteLine("4)Copy");

                    int.TryParse(Console.ReadLine(), out choise);

                    if (choise == 1)
                    {
                        do
                        {
                            Console.WriteLine("Введите размер");

                            double.TryParse(Console.ReadLine(), out size);
                        }
                        while (size == 0);

                        if (dVD.GetAmountOfMemory() > dVD.AmountOfBusyMemory + size)
                        {
                            Console.WriteLine("Введите имя");

                            name = Console.ReadLine();

                            dVD.GetDirectory().AddFile(size, name);

                            dVD.AmountOfBusyMemory += size;
                        }
                        else
                        {
                            Console.WriteLine("Мало памяти");
                        }
                    }

                    else if(choise == 2)
                    {
                        Console.WriteLine("Введите имя");

                        name = Console.ReadLine();

                        dVD.GetDirectory().AddDirectory(name);
                    }

                    else if (choise == 3)
                    {
                        dVD.AmountOfBusyMemory += Show(dVD.GetDirectory());
                    }
                }

                else if (choise == 4)
                {
                    Console.WriteLine("1)HDD");
                    Console.WriteLine("2)Flash");

                    int.TryParse(Console.ReadLine(), out choise);

                    if (choise == 1)
                    {
                        if (hDD.AmountOfBusyMemory < dVD.GetFreeAmountOfMemory())
                        {
                            dVD.DataCopying(dVD.GetDirectory(), hDD.GetDirectory(), hDD.AmountOfBusyMemory);
                            DownloadTime(hDD.AmountOfBusyMemory, dVD.ReadAndWriteSpeed);
                            Console.ReadLine();
                            Console.ReadLine();
                        }
                    }

                    else if (choise == 2)
                    {
                        if (dVD.AmountOfBusyMemory < dVD.GetFreeAmountOfMemory())
                        {
                            dVD.DataCopying(dVD.GetDirectory(), flash.GetDirectory(), flash.AmountOfBusyMemory);
                            DownloadTime(flash.AmountOfBusyMemory, dVD.ReadAndWriteSpeed);
                            Console.ReadLine();
                            Console.ReadLine();
                        }
                    }
                }

                else if (choise == 0)
                {
                    break;
                }

            } while (true);

        }
    }
}

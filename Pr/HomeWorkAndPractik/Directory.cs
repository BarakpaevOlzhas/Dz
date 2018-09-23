using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkAndPractik
{
    public class Directory
    {
        public string Name { get; set; }

        public int NumberOfFiles { get; set; }

        public int NumberOfDirectory { get; set; }

        private File[] file;

        private Directory[] directory;

        public Directory()
        {
            NumberOfFiles = 0;
        }

        public File GetFileByIndex(int index)
        {
            return file[index];
        }

        public Directory GetDirectoryByIndex(int index)
        {
            return directory[index];
        }

        public void AddFile(double size, string name)
        {
            int zero = 0;
            int one = 1;

            if (NumberOfFiles != zero)
            {
                File[] buf = new File[NumberOfFiles];

                for (int i = 0;i < NumberOfFiles;i++)
                {
                    buf[i] = new File();
                }

                for (int i = 0; i < NumberOfFiles; i++)
                {
                    buf[i] = file[i];
                }

                file = new File[NumberOfFiles + one];

                for (int i = 0; i < NumberOfFiles + one; i++)
                {
                    file[i] = new File();
                }

                for (int i = 0; i < NumberOfFiles; i++)
                {
                    file[i] = buf[i];
                }

                NumberOfFiles++;

                file[NumberOfFiles - one].Name = name;
                file[NumberOfFiles- one].Size = size;
            }

            else
            {
                NumberOfFiles++;

                file = new File[NumberOfFiles];

                file[zero] = new File();

                file[zero].Name = name;
                file[zero].Size = size;
            }
        }

        public void AddDirectory(string name)
        {
            int zero = 0;
            int one = 1;

            if (NumberOfDirectory != zero)
            {
                Directory[] buf = new Directory[NumberOfDirectory];

                for (int i = 0; i < NumberOfDirectory; i++)
                {
                    buf[i] = new Directory();
                }                

                for (int i = 0; i < NumberOfDirectory; i++)
                {
                    buf[i] = directory[i];
                }

                directory = new Directory[NumberOfDirectory + one];

                for (int i = 0; i < NumberOfDirectory + one; i++)
                {
                    directory[i] = new Directory();
                }

                for (int i = 0; i < NumberOfDirectory; i++)
                {
                    directory[i] = buf[i];
                }

                NumberOfDirectory++;


                directory[NumberOfDirectory - one].Name = name;
                directory[NumberOfDirectory - one].NumberOfDirectory = zero;
                directory[NumberOfDirectory - one].NumberOfFiles = zero;
            }

            else
            {
                NumberOfDirectory++;

                directory = new Directory[NumberOfDirectory];

                directory[zero] = new Directory();

                directory[zero].Name = name;                
                directory[zero].NumberOfDirectory = zero;
                directory[zero].NumberOfFiles = zero;
            }

        }
    }

}

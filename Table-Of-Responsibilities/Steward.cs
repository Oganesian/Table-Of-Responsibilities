using System.IO;

namespace Table_Of_Responsibilities
{
    class Steward
    {
        string name
        {
            get { return name; }
            set { name = value; }
        }

        string surname
        {
            get { return surname; }
            set { surname = value; }
        }

        bool canBeTheManager
        {
            get { return canBeTheManager; }
            set { canBeTheManager = value; }
        }

        bool canUseTheControlPanel
        {
            get { return canUseTheControlPanel; }
            set { canUseTheControlPanel = value; }
        }

        bool canServeWithAMicrophone
        {
            get { return canServeWithAMicrophone; }
            set { canServeWithAMicrophone = value; }
        }

        void saveToFile(string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(surname + " " + name);
                sw.WriteLine("Распорядитель = " + canBeTheManager);
                sw.WriteLine("Пульт = " + canUseTheControlPanel);
                sw.WriteLine("Микрофоны и трибуна = " + canServeWithAMicrophone);
            }
        }

        void setFromFile(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string surnameAndName = sr.ReadLine();
                string[] split = surnameAndName.Split(' ');
                surname = split[0];
                name = split[1];
                canBeTheManager = sr.ReadLine().Contains("true");
                canUseTheControlPanel = sr.ReadLine().Contains("true");
                canServeWithAMicrophone = sr.ReadLine().Contains("true");
            }
        }
    }
}

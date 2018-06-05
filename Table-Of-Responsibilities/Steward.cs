﻿using System.IO;

namespace Table_Of_Responsibilities
{
    class Steward
    {
        string surname;
        string name;
        bool canBeTheManager;
        bool canUseTheControlPanel;
        bool canServeWithAMicrophone;

        string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        string Name
        {
            get { return name; }
            set { name = value; }
        }

        bool CanBeTheManager
        {
            get { return canBeTheManager; }
            set { canBeTheManager = value; }
        }

        bool CanUseTheControlPanel
        {
            get { return canUseTheControlPanel; }
            set { canUseTheControlPanel = value; }
        }

        bool CanServeWithAMicrophone
        {
            get { return canServeWithAMicrophone; }
            set { canServeWithAMicrophone = value; }
        }

        public Steward(string s, string n, bool m, bool p, bool mic)
        {
            surname = s;
            name = n;
            canBeTheManager = m;
            canUseTheControlPanel = p;
            canServeWithAMicrophone = mic;
        }

        public void saveToFile()
        {
            using (StreamWriter sw = File.CreateText("Stewards/" + surname + " " + name + ".cstw"))
            {
                sw.WriteLine(surname + " " + name);
                sw.WriteLine("Распорядитель = " + canBeTheManager);
                sw.WriteLine("Пульт = " + canUseTheControlPanel);
                sw.WriteLine("Микрофоны и трибуна = " + canServeWithAMicrophone);
            }
        }

        public void setFromFile()
        {
            using (StreamReader sr = File.OpenText("Stewards/" + surname + " " + name + ".cstw"))
            {
                string surnameAndName = sr.ReadLine();
                string[] split = surnameAndName.Split(' ');
                surname = split[0];
                name = split[1];
                canBeTheManager = sr.ReadLine().Contains("True");
                canUseTheControlPanel = sr.ReadLine().Contains("True");
                canServeWithAMicrophone = sr.ReadLine().Contains("True");
            }
        }
    }
}

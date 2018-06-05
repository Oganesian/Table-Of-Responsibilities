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

        void saveToFile()
        {

        }

        string getFromFile()
        {
            return "";
        }
    }
}

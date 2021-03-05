using System;

namespace AbstractFactory
{
    class Program
    {
        const string OSType = "Windows"; // Configure your app's OS Type. ( You should autodetect this in your real application. ) 
        static GUIFactory _factory;

        // Check the operating system which the application is running on.
        static void Init()
        {
            if (OSType == "Windows")
            {
                _factory = new WinFactory();
            }
            else if (OSType == "Mac") // If it is not Windows then go for MacFactory. ( You should check for other OSes as well.)
            {
                _factory = new MacFactory();
            }
            else
                throw new Exception("Error! Unknown operating system.");
        }
        static void Main(string[] args)
        {
            // Initialize the factory.
            Init();

            // Create button and checkbox which depends on the factory class.
            Button button = _factory.CreateButton();
            button.Paint();
            CheckBox checkBox = _factory.CreateCheckBox();
            checkBox.Paint();

            Console.ReadLine();
        }
    }

    // Abstract Factory Interface
    interface GUIFactory 
    {
        Button CreateButton();
        CheckBox CreateCheckBox();
    }

    // Concrete Factory
    class WinFactory : GUIFactory
    {
        public Button CreateButton()
        {
            return new WinButton();
        }

        public CheckBox CreateCheckBox()
        {
            return new WinCheckBox();
        }
    }

    // Concrete Factory
    class MacFactory : GUIFactory
    {
        public Button CreateButton()
        {
            return new MacButton();    
        }

        public CheckBox CreateCheckBox()
        {
            return new MacCheckBox();
        }
    }

    interface Button
    {
        void Paint();
    }

    class WinButton : Button
    {
        public WinButton()
        {
            Console.WriteLine("Windows Button created.");
        }
        public void Paint()
        {
            // Render a button in Windows style.
            Console.WriteLine("Windows Button painted.");
        }
    }

    class MacButton : Button
    {
        public MacButton()
        {
            Console.WriteLine("Mac Button created.");
        }
        public void Paint()
        {
            // Render a button in macOS style.
            Console.WriteLine("Mac Button painted.");
        }
    }

    interface CheckBox
    {
        void Paint();
    }

    class WinCheckBox : CheckBox
    {
        public WinCheckBox()
        {
            Console.WriteLine("Windows CheckBox created.");
        }
        public void Paint()
        {
            // Render a checkbox in Windows style.
            Console.WriteLine("Windows CheckBox painted.");
        }
    }

    class MacCheckBox : CheckBox
    {
        public MacCheckBox()
        {
            Console.WriteLine("Mac CheckBox created.");
        }
        public void Paint()
        {
            // Render a checkbox in macOS style.
            Console.WriteLine("Mac CheckBox painted.");
        }
    }
}

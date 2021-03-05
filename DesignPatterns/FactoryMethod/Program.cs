using System;
using System.Runtime.InteropServices;

namespace FactoryMethod
{
    class Program
    {
        const string OSType = "Windows"; // Configure your app's OS Type. ( You should autodetect this in your real application. ) 
        static Dialog _dialog;

        // Check the operating system which the application is running on.
        static void Init()
        {

            if (OSType == "Windows")
            {
                _dialog = new WindowsDialog();
            }
            else if (OSType == "Web") // If it is not Windows then go for WebDialog. ( You should check for other OSes as well.)
            {
                _dialog = new WebDialog();
            }
            else
                throw new Exception("Error! Unknown operating system.");
        }
        static void Main(string[] args)
        {
            Init();
            _dialog.Render();

            Console.ReadLine();
        }
    }
    public abstract class Dialog
    {
        protected abstract IButton CreateButton();
        public void Render()
        {
            // Call the factory method to create a product object.
            IButton okButton = CreateButton();

            // Now use the product.
            okButton.OnClick("do the trick");
            okButton.Render();
        }
    }

    public class WindowsDialog : Dialog
    {
        protected override IButton CreateButton()
        {
            return new WindowsButton();
        }
    }

    public class WebDialog : Dialog
    {
        protected override IButton CreateButton()
        {
            return new HtmlButton();
        }
    }

    public interface IButton
    {
        void Render();
        void OnClick(string trick);
    }

    public class WindowsButton : IButton
    {
        public void OnClick(string trick)
        {
            // Bind a windows button click event.
            Console.WriteLine("Windows Button Click Event: {0}", trick);
        }

        public void Render()
        {
            // Render a button in Windows style.
        }
    }

    public class HtmlButton : IButton
    {
        public void OnClick(string trick)
        {
            // Bind a web browser click event.
            Console.WriteLine("HTML Button Click Event: {0}", trick);
        }

        public void Render()
        {
            // Return an Html style button.
        }
    }
}

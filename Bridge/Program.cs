using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Device.
            Device tv = new Tv();
            // Assign it to a RemoteControl.
            RemoteControl remoteControl = new RemoteControl(tv);

            remoteControl.TogglePower();
            remoteControl.ChannelUp();
            remoteControl.DisplayInfo();

            // Create a new Device.
            Device radio = new Radio();
            // Assign it to AdvancedRemoteControl if you want.
            AdvancedRemoteControl advancedRemoteControl = new AdvancedRemoteControl(radio);

            advancedRemoteControl.TogglePower();
            advancedRemoteControl.Mute();
            advancedRemoteControl.DisplayInfo();
        }
    }

    // The Main Abstraction Class
    class RemoteControl
    {
        protected Device _device; // Create a field between Abstraction Class and Implementation Interface as a bridge.
        public RemoteControl(Device device)
        {
            _device = device;
        }

        // Use that bridge to control the implementation.
        public void TogglePower()
        {
            if (_device.IsEnabled())
            {
                _device.Disable();
            }
            else
            {
                _device.Enable();
            }
        }

        public void VolumeUp()
        {
            _device.SetVolume(_device.GetVolume() + 10);
        }

        public void VolumeDown()
        {
            _device.SetVolume(_device.GetVolume() - 10);
        }

        public void ChannelUp()
        {
            _device.SetChannel(_device.GetChannel() + 1);
        }

        public void ChannelDown()
        {
            _device.SetChannel(_device.GetChannel() - 1);
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Device: {0}", _device.GetType());
            Console.WriteLine("Is enabled?: {0}", _device.IsEnabled());
            Console.WriteLine("Channel: {0}", _device.GetChannel());
            Console.WriteLine("Volume: {0}", _device.GetVolume());
            Console.WriteLine("---------------------------");
            
        }
    }
    
    // Optional Abstraction Class which inherits the main class.
    class AdvancedRemoteControl : RemoteControl 
    {
        public AdvancedRemoteControl(Device device) : base(device)
        {
        }

        public void Mute()
        {
            _device.SetVolume(0);
        }
    }

    // Main Implementation Interface
    interface Device
    {
        void Enable();
        void Disable();
        bool IsEnabled();
        void SetVolume(int volume);
        int GetVolume();
        void SetChannel(int channel);
        int GetChannel();
    }

    // Concrete Implementation
    class Tv : Device
    {
        private int Volume = 10;
        private bool Enabled = false;
        private int ChannelId = 0;
        public void Disable()
        {
            Enabled = false;
        }

        public void Enable()
        {
            Enabled = true;
        }

        public int GetChannel()
        {
            return ChannelId;
        }

        public int GetVolume()
        {
            return Volume;
        }

        public bool IsEnabled()
        {
            return Enabled;
        }

        public void SetChannel(int channel)
        {
            ChannelId = channel;
        }

        public void SetVolume(int volume)
        {
            Volume = volume;
        }
    }

    // Concrete Implementation
    class Radio : Device
    {
        private int Volume = 10;
        private bool Enabled = false;
        private int ChannelId = 0;
        public void Disable()
        {
            Enabled = false;
        }

        public void Enable()
        {
            Enabled = true;
        }

        public int GetChannel()
        {
            return ChannelId;
        }

        public int GetVolume()
        {
            return Volume;
        }

        public bool IsEnabled()
        {
            return Enabled;
        }

        public void SetChannel(int channel)
        {
            ChannelId = channel;
        }

        public void SetVolume(int volume)
        {
            Volume = volume;
        }
    }
}

using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a device object.
            PersonalComputer personalComputer = new PersonalComputer { Type = "Gaming", Model = "XYZ Gaming M123", Price = 2300};

            // Use special offer decorator.
            SpecialOffer specialOffer = new SpecialOffer(personalComputer)
            {
                DiscountPercentage = 10
            };

            Console.WriteLine("Original Price: {0}", personalComputer.Price);
            Console.WriteLine("Discounted Price: {0}", specialOffer.Price); // Now see the offered price without changing the original price.
        }
    }

    // Component base class.
    abstract class DeviceBase
    {
        public abstract string Type { get; set; }
        public abstract string Model { get; set; }
        public abstract int Price { get; set; }
    }

    // Products of that base class.
    class MobilePhone : DeviceBase
    {
        public override string Type { get; set; }
        public override string Model { get; set; }
        public override int Price { get; set; }
    }

    class PersonalComputer : DeviceBase
    {
        public override string Type { get; set; }
        public override string Model { get; set; }
        public override int Price { get; set; }
    }

    // This is the decorator base class which implements the device's base.
    // Decorators must have its own device object to decorate it.
    abstract class DeviceDecoratorBase : DeviceBase
    {
        protected readonly DeviceBase _deviceBase; // Device object of any kind that implements our device base.

        public DeviceDecoratorBase(DeviceBase deviceBase)
        {
            _deviceBase = deviceBase;
        }
    }

    // This is a kind of Decorator which discounts prices and makes special offers.
    class SpecialOffer : DeviceDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        public SpecialOffer(DeviceBase deviceBase) : base(deviceBase)
        {
        }

        public override string Type { get; set; }
        public override string Model { get; set; }
        public override int Price
        {
            get { return _deviceBase.Price - _deviceBase.Price * DiscountPercentage / 100; }
            set { }
        }
    }
}

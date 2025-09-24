namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DummySensor : SystemComponent
    {
        DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            this.virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            var world = World.Instance;
            var circle = world.WorldObjects.OfType<Circle>().FirstOrDefault();
            var car = world.WorldObjects.OfType<Car>().FirstOrDefault();
            this.dummyPacket.DistanceX = Math.Abs(circle.X - car.X);
            this.dummyPacket.DistanceY = Math.Abs(circle.Y - car.Y);
            
        }
    }
}

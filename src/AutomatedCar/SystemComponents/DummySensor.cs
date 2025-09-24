namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System.Linq;


    public class DummySensor : SystemComponent
    {
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus){
            this.dummyPacket = new DummyPacket();
            this.virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        private DummyPacket dummyPacket;

        public override void Process()
        {
            var world = World.Instance;
            var car = world.ControlledCar;
            var circle = world.WorldObjects.OfType<Circle>().FirstOrDefault();

            this.dummyPacket.DistanceX = circle.X - car.X;
            this.dummyPacket.DistanceY = circle.Y - car.Y;
        }


    }
}

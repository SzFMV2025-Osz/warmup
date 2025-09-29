namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Linq;

    
    public class DummySensor : SystemComponent
    {
        private readonly DummyPacket dummyPacket;
        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            this.virtualFunctionBus.DummyPacket = this.dummyPacket;
        }
        public override void Process()
        {
            var circle = World.Instance.WorldObjects
                .OfType<Circle>()
                .FirstOrDefault();

            var controlledCar = World.Instance.ControlledCar;

            if (circle != null && controlledCar != null)
            {
                this.dummyPacket.DistanceX =Math.Abs(circle.X - controlledCar.X);
                this.dummyPacket.DistanceY = Math.Abs(circle.Y - controlledCar.Y);
            }
            else
            {
                this.dummyPacket.DistanceX = 0;
                this.dummyPacket.DistanceY = 0;
            }
        }
    }
}

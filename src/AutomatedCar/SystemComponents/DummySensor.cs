namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using Avalonia.Controls.Documents;
    using System;
    using System.Linq;

    public class DummySensor : SystemComponent
    {
        private DummyPacket DummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.DummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.DummyPacket;
        }

        public override void Process()
        {
            var carCoordinates = World.Instance.ControlledCar;
            var target = World.Instance.WorldObjects.OfType<Circle>().FirstOrDefault();
            this.DummyPacket.DistanceX=Math.Abs(carCoordinates.X-target.X);
            this.DummyPacket.DistanceY=Math.Abs(carCoordinates.Y-target.Y);

        }

    }
}

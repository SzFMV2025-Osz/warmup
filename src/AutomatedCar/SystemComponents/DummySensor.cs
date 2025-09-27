namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Linq;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    internal class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus bus) : base(bus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.RegisterComponent(this);
        }

        public override void Process()
        {
            var car = World.Instance.ControlledCar;
            int carX = car.X;
            int carY = car.Y;

            var circle = World.Instance.WorldObjects.FirstOrDefault(obj => obj.WorldObjectType.Equals(WorldObjectType.Other) && obj is Circle);

            if (circle != null)
            {
                int dx = circle.X - carX;
                int dy = circle.Y - carY;

                dummyPacket.DistanceX = dx;
                dummyPacket.DistanceY = dy;

                //System.Diagnostics.Debug.WriteLine($"DummySensor: dx={dummyPacket.DistanceX}, dy={dummyPacket.DistanceY}");
            }
        }
    }
}
namespace AutomatedCar.SystemComponents
{
    using System;
    using AutomatedCar.SystemComponents.Packets;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using Avalonia.Controls.Documents;
    using System.Linq;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        /* Process needs to calculate the difference of the x and y coordinates of the controlled car and the circle like this: distanceX = circle.x - car.x
         * After that it needs to put the x and y distance in the dummypacket
         * Steps:
         * 1. get the car and circle object
         * 2. calculate the distances and set the dummypackets properties
         */
        public override void Process()
        {
            var car = World.Instance.ControlledCar;

            var circle = World.Instance.WorldObjects.OfType<Circle>().FirstOrDefault();

            this.dummyPacket.DistanceX = Math.Abs(circle.X - car.X);// Delete Math.Abs() in both lines if "direction" is needed
            this.dummyPacket.DistanceY = Math.Abs(circle.Y - car.Y);
        }
    }
}
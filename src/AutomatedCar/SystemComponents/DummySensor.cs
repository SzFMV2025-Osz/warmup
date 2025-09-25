namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DummySensor : SystemComponent
    {
        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        private DummyPacket dummyPacket;

        public override void Process()
        {
            this.dummyPacket.DistanceX = World.Instance.ControlledCar.X - World.Instance.WorldObjects.First(x => x.GetType() == typeof(Circle)).X;
            this.dummyPacket.DistanceY = World.Instance.ControlledCar.Y - World.Instance.WorldObjects.First(x => x.GetType() == typeof(Circle)).Y;
        }
    }
}

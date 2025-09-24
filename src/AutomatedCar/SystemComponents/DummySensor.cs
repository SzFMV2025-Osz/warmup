namespace AutomatedCar.SystemComponents;

using Models;
using Packets;
using System;
using System.Linq;

public class DummySensor : SystemComponent
{
    private DummyPacket dummyPacket;

    public DummySensor(VirtualFunctionBus virtualFunctionBus) 
        : base(virtualFunctionBus)
    {
        this.dummyPacket = new DummyPacket();
        virtualFunctionBus.DummyPacket = this.dummyPacket;
    }
    public override void Process()
    {
        var currentCar = World.Instance.ControlledCar;
        var targetCircle = World.Instance.WorldObjects.First(x => x.GetType() == typeof(Circle));

        this.dummyPacket.DistanceX = Math.Abs(currentCar.X - targetCircle.X);
        this.dummyPacket.DistanceY = Math.Abs(currentCar.Y - targetCircle.Y);
    }
}
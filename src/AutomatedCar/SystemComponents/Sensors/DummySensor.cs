using System;
using System.Linq;
using AutomatedCar.Models;
using AutomatedCar.SystemComponents.Packets;
using AutomatedCar.SystemComponents;

namespace AutomatedCar.SystemComponents.Sensors
{
    public class DummySensor : SystemComponent
    {
        private readonly AutomatedCar.Models.AutomatedCar car;

        public DummySensor(VirtualFunctionBus vfb, AutomatedCar.Models.AutomatedCar car)
            : base(vfb)
        {
            this.car = car ?? throw new ArgumentNullException(nameof(car));
        }

        public override void Process()
        {
            
            var packet = this.virtualFunctionBus.GetWritableDummyPacket();

           
            var world = World.Instance;

            if (world?.WorldObjects == null || world.WorldObjects.Count == 0)
            {
                packet.DistanceX = 0;
                packet.DistanceY = 0;
                return;
            }

            var circle = world.WorldObjects.FirstOrDefault(o => o is Circle) as Circle;
            if (circle == null)
            {
                packet.DistanceX = 0;
                packet.DistanceY = 0;
                return;
            }

            double carCX = car.X + car.RotationPoint.X;
            double carCY = car.Y + car.RotationPoint.Y;
            double circleCX = circle.X + circle.Radius;
            double circleCY = circle.Y + circle.Radius;

            double dx = circleCX - carCX;
            double dy = circleCY - carCY;

            
            const double eps = 2.0;
            if (Math.Abs(dx) < eps) dx = 0;
            if (Math.Abs(dy) < eps) dy = 0;

            packet.DistanceX = (int)Math.Round(dx);
            packet.DistanceY = (int)Math.Round(dy);
        }
    }
}

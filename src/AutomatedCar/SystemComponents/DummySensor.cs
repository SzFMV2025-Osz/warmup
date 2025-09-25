using AutomatedCar.Models;
using AutomatedCar.SystemComponents.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedCar.SystemComponents
{
    class DummySensor : SystemComponent
    {
        private readonly World world;
        private readonly AutomatedCar.Models.AutomatedCar car;
        private readonly DummyPacket outPacket;
        public DummySensor(VirtualFunctionBus virtualFunctionBus, World world, AutomatedCar.Models.AutomatedCar car) : base(virtualFunctionBus)
        {
            this.world = world;
            this.car = car;
            this.outPacket = virtualFunctionBus.WritableDummyPacket;
        }

        public override void Process()
        {
            // Első kör
            var circle = world.WorldObjects.OfType<Circle>().FirstOrDefault();
            if (circle is null)
            {
                outPacket.DistanceX = 0;
                outPacket.DistanceY = 0;
                return;
            }

            // Autó és kör pozíciója
            double carX = car.X;
            double carY = car.Y;
            double circX = circle.X;
            double circY = circle.Y;

            // Komponensenkénti (előjeles) különbség
            outPacket.DistanceX = (int)Math.Round(circX - carX);
            outPacket.DistanceY = (int)Math.Round(circY - carY);
        }
    }
}

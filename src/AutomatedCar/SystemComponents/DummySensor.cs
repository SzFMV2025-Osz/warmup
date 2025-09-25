namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System.Linq;

    
    public class DummySensor : SystemComponent
    {
        private readonly DummyPacket dummyPacket;

        /// <summary>
        /// Initializes a new instance of the DummySensor class
        /// </summary>
        /// <param name="virtualFunctionBus">The virtual function bus for communication</param>
        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            // Create the packet for storing distance data
            this.dummyPacket = new DummyPacket();

            // Register the packet to the VFB so other components can read it
            this.virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        /// <summary>
        /// Process method called by VFB in each cycle
        /// Calculates distance between ego car and circle object
        /// </summary>
        public override void Process()
        {
            // Get the circle object from the world
            var circle = World.Instance.WorldObjects
                .OfType<Circle>()
                .FirstOrDefault();

            // Get the controlled car from the world
            var controlledCar = World.Instance.ControlledCar;

            // Calculate distances if both objects exist
            if (circle != null && controlledCar != null)
            {
                // Calculate the X and Y distance between car and circle
                // Using their reference points (top-left corner)
                this.dummyPacket.DistanceX = (int)(circle.X - controlledCar.X);
                this.dummyPacket.DistanceY = (int)(circle.Y - controlledCar.Y);
            }
            else
            {
                // Reset distances if objects not found
                this.dummyPacket.DistanceX = 0;
                this.dummyPacket.DistanceY = 0;
            }
        }
    }
}

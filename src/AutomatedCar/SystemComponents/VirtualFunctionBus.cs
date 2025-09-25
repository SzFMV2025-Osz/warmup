namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.SystemComponents.Packets;
    using System.Collections.Generic;

    public class VirtualFunctionBus : GameBase
    {
        private readonly List<SystemComponent> components = new();

        // Irható bsuzos példány
        private readonly DummyPacket _dummy = new DummyPacket();

        // Kifelé csak olvasható
        public IReadOnlyDummyPacket DummyPacket => _dummy;

        // Szenzoroknak írható ref
        internal DummyPacket WritableDummyPacket => _dummy;

        public void RegisterComponent(SystemComponent component) => components.Add(component);

        protected override void Tick()
        {
            foreach (var component in components)
            {
                component.Process();
            }
        }
    }
}
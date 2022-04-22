namespace NullGB.Core
{
    // TODO: Implement
    internal interface IBus
    {
        public byte Read(ushort address);
        public void Write(ushort address, byte value);
    }
}

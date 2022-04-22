namespace NullGB.Core;

internal interface IBus
{
    public byte Read(ushort address);
    public void Write(ushort address, byte value);
}

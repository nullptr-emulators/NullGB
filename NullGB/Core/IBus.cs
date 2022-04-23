namespace NullGB.Core;

internal interface IBus
{
    public byte Read(ushort address);
    public byte Write(ushort address, byte value);
}

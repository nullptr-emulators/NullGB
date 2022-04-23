namespace NullGB.Core;

internal interface IBus
{
    public byte Read(ushort address);
    public byte Read(int address) => Read((ushort)address);

    public byte Write(ushort address, byte value);
    public byte Write(int address, byte value) => Write((ushort)address, value);
}

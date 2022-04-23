namespace NullGB.Core;

internal class MMU : IBus
{
    private byte[] Memory = new byte[0x10000];

    public MMU(byte[] rom)
    {
        // Account for ROMs with bank switching?
        if (rom.Length > 0x8000) throw new OutOfMemoryException($"ROM was larger than maximum ROM size. Expected '<0x8000' found '{rom.Length}'");

        Buffer.BlockCopy(rom, 0, Memory, 0, rom.Length);
    }

    public byte Read(ushort address) => Memory[address];

    public byte Write(ushort address, byte value) => Memory[address] = value;
}

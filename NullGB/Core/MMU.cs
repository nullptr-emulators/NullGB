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

    public byte Write(ushort address, byte value)
    {
        if (address == 0xFF02 && value == 0x81)
        {
            Console.Error.Write((char)Memory[0xFF01]);
        }

        if (address < 0x8000)
        {
            return value;
        }
        return Memory[address] = value;
    }
}

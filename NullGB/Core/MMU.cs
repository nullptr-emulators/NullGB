namespace NullGB.Core;

internal class MMU : IBus
{
    private byte[] Memory = new byte[0x10000];
    public Span<byte> Cart => Memory.AsSpan(0x0000..0x8000);
    public Span<byte> ROMBank0 => Memory.AsSpan(0x0000..0x4000);
    public Span<byte> ROMBankSwitch => Memory.AsSpan(0x4000..0x8000);
    public Span<byte> VRAM => Memory.AsSpan(0x8000..0xA000);
    public Span<byte> RAMBankSwitch => Memory.AsSpan(0xA000..0xC000);
    public Span<byte> RAMInternal => Memory.AsSpan(0xC000..0xE000);
    public Span<byte> RAMEchoInternal => Memory.AsSpan(0xE000..0xFE00);

    public MMU(byte[] rom)
    {
        // Account for ROMs with bank switching?
        if (rom.Length > 0x8000) throw new OutOfMemoryException($"ROM was larger than maximum ROM size. Expected '<0x8000' found '{rom.Length}'");

        Buffer.BlockCopy(rom, 0, Memory, 0, rom.Length);
    }

    public byte Read(ushort address) => Memory[address];

    public void Write(ushort address, byte value) => Memory[address] = value;
}

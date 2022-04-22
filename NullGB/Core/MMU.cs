using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullGB.Core
{
    internal class MMU
    {
        private byte[] Memory = new byte[0xFFFF];
        public Span<byte> Cart => Memory.AsSpan(0x0000..0x8000);
        public Span<byte> ROMBank0 => Memory.AsSpan(0x0000..0x4000);
        public Span<byte> ROMBankSwitch => Memory.AsSpan(0x4001..0x8000);
        public Span<byte> VRAM => Memory.AsSpan(0x8001..0xA000);
        public Span<byte> RAMBankSwitch => Memory.AsSpan(0xA001..0xC000);
        public Span<byte> RAMInternal => Memory.AsSpan(0xC001..0xE000);
        public Span<byte> RAMEchoInternal => Memory.AsSpan(0xE001..0xFE00);
    }
}

using NullGB.Extensions;

namespace NullGB.Core.CPU
{
    internal partial class CPU
    {
        public byte CurrentOp;

        /// <summary>
        /// This function is run once per Instruction
        /// </summary>
        public Status Step()
        {
            byte opcode = Fetch8();
#if DEBUG
            var instr = Instructions.Ops[opcode];
            var size = instr.Size;
            string bytes = $"{opcode:X2}";
            for (int i = 0; i < size - 1; i++)
            {
                bytes += $" {MemoryBus.Read(PC + i):X2}";
            }
            Console.WriteLine($"{PC - 1:X4}:  {bytes,-15}A:{A:x2} F:{F:x2} B:{B:x2} C:{C:x2} D:{D:x2} E:{E:x2} H:{H:x2} L:{L:x2} SP:{SP:x4}");
#endif
            return Execute(opcode);
        }

        public Status Execute(byte opcode) => opcode switch
        {
            0x00 => Status.Continue,
            0x10 => Status.Stop,
            0xCB => ExecuteCB(),

#region Invalid Addresses
            0xD3 => Status.InvalidInstr,
            0xDB => Status.InvalidInstr,
            0xDD => Status.InvalidInstr,
            0xE3 => Status.InvalidInstr,
            0xE4 => Status.InvalidInstr,
            0xEB => Status.InvalidInstr,
            0xEC => Status.InvalidInstr,
            0xED => Status.InvalidInstr,
            0xF4 => Status.InvalidInstr,
            0xFC => Status.InvalidInstr,
            0xFD => Status.InvalidInstr,
#endregion

#region Jumps
            0xC3 => Instructions.JumpAbsIf(this, true),
            0xC2 => Instructions.JumpAbsIf(this, !this.FlagZ),
            0xCA => Instructions.JumpAbsIf(this, this.FlagZ),
            0xD2 => Instructions.JumpAbsIf(this, !this.FlagC),
            0xDA => Instructions.JumpAbsIf(this, this.FlagC),

            0x18 => Instructions.JumpRelIf(this, true),
            0x20 => Instructions.JumpRelIf(this, !this.FlagZ),
            0x28 => Instructions.JumpRelIf(this, this.FlagZ),
            0x30 => Instructions.JumpRelIf(this, !this.FlagC),
            0x38 => Instructions.JumpRelIf(this, this.FlagC),

            0xE9 => Instructions.JumpHL(this, MemoryBus),

            0xC9 => Instructions.RetIf(this, true),
            0xD9 => Instructions.ReturnInterrupt(this, MemoryBus),
            0xC0 => Instructions.RetIf(this, !this.FlagZ),
            0xC8 => Instructions.RetIf(this, this.FlagZ),
            0xD0 => Instructions.RetIf(this, !this.FlagC),
            0xD8 => Instructions.RetIf(this, this.FlagC),

            0xCD => Instructions.CallIf(this, true),
            0xC4 => Instructions.CallIf(this, !this.FlagZ),
            0xCC => Instructions.CallIf(this, this.FlagZ),
            0xD4 => Instructions.CallIf(this, !this.FlagC),
            0xDC => Instructions.CallIf(this, this.FlagC),

            0xC7 => Instructions.Reset(this, 0 << 3),
            0xD7 => Instructions.Reset(this, 1 << 3),
            0xE7 => Instructions.Reset(this, 2 << 3),
            0xF7 => Instructions.Reset(this, 3 << 3),
            0xCF => Instructions.Reset(this, 4 << 3),
            0xDF => Instructions.Reset(this, 5 << 3),
            0xEF => Instructions.Reset(this, 6 << 3),
            0xFF => Instructions.Reset(this, 7 << 3),
#endregion

#region Stack Operations
            0xC1 => Instructions.PopRegister(this, REG16.BC),
            0xD1 => Instructions.PopRegister(this, REG16.DE),
            0xE1 => Instructions.PopRegister(this, REG16.HL),
            0xF1 => Instructions.PopRegister(this, REG16.AF),

            0xC5 => Instructions.PushRegister(this, REG16.BC),
            0xD5 => Instructions.PushRegister(this, REG16.DE),
            0xE5 => Instructions.PushRegister(this, REG16.HL),
            0xF5 => Instructions.PushRegister(this, REG16.AF),

            0x31 => Instructions.LoadRegisterImmediate16(REG16.SP, this),
            0x08 => Instructions.StoreSPIndirect(this, MemoryBus),

            0xE8 => Instructions.MoveRegisterSPOffset(REG16.SP, this),
            0xF8 => Instructions.MoveRegisterSPOffset(REG16.HL, this),
            0xF9 => Instructions.MoveSPHL(this),

            0x33 => Instructions.Inc16(REG16.SP, this),
            0x3B => Instructions.Dec16(REG16.SP, this),

            0x39 => Instructions.AddReg16(REG16.HL, REG16.SP, this),
#endregion

#region Interrupt
            0xF3 => Instructions.SetInterruptFlag(MemoryBus, false),
            0xFB => Instructions.SetInterruptFlag(MemoryBus, true),
            0x76 => Status.Halt,
#endregion

            // TODO: Simplify declaration to not include _all_ lines
#region Load Operations
            0x40 => Instructions.MovRegister(REG8.B, REG8.B, this),
            0x41 => Instructions.MovRegister(REG8.B, REG8.C, this),
            0x42 => Instructions.MovRegister(REG8.B, REG8.D, this),
            0x43 => Instructions.MovRegister(REG8.B, REG8.E, this),
            0x44 => Instructions.MovRegister(REG8.B, REG8.H, this),
            0x45 => Instructions.MovRegister(REG8.B, REG8.L, this),
            0x46 => Instructions.MovRegister(REG8.B, REG8.HL, this),
            0x47 => Instructions.MovRegister(REG8.B, REG8.A, this),
            0x48 => Instructions.MovRegister(REG8.C, REG8.B, this),
            0x49 => Instructions.MovRegister(REG8.C, REG8.C, this),
            0x4A => Instructions.MovRegister(REG8.C, REG8.D, this),
            0x4B => Instructions.MovRegister(REG8.C, REG8.E, this),
            0x4C => Instructions.MovRegister(REG8.C, REG8.H, this),
            0x4D => Instructions.MovRegister(REG8.C, REG8.L, this),
            0x4E => Instructions.MovRegister(REG8.C, REG8.HL, this),
            0x4F => Instructions.MovRegister(REG8.C, REG8.A, this),
            0x50 => Instructions.MovRegister(REG8.D, REG8.B, this),
            0x51 => Instructions.MovRegister(REG8.D, REG8.C, this),
            0x52 => Instructions.MovRegister(REG8.D, REG8.D, this),
            0x53 => Instructions.MovRegister(REG8.D, REG8.E, this),
            0x54 => Instructions.MovRegister(REG8.D, REG8.H, this),
            0x55 => Instructions.MovRegister(REG8.D, REG8.L, this),
            0x56 => Instructions.MovRegister(REG8.D, REG8.HL, this),
            0x57 => Instructions.MovRegister(REG8.D, REG8.A, this),
            0x58 => Instructions.MovRegister(REG8.E, REG8.B, this),
            0x59 => Instructions.MovRegister(REG8.E, REG8.C, this),
            0x5A => Instructions.MovRegister(REG8.E, REG8.D, this),
            0x5B => Instructions.MovRegister(REG8.E, REG8.E, this),
            0x5C => Instructions.MovRegister(REG8.E, REG8.H, this),
            0x5D => Instructions.MovRegister(REG8.E, REG8.L, this),
            0x5E => Instructions.MovRegister(REG8.E, REG8.HL, this),
            0x5F => Instructions.MovRegister(REG8.E, REG8.A, this),
            0x60 => Instructions.MovRegister(REG8.H, REG8.B, this),
            0x61 => Instructions.MovRegister(REG8.H, REG8.C, this),
            0x62 => Instructions.MovRegister(REG8.H, REG8.D, this),
            0x63 => Instructions.MovRegister(REG8.H, REG8.E, this),
            0x64 => Instructions.MovRegister(REG8.H, REG8.H, this),
            0x65 => Instructions.MovRegister(REG8.H, REG8.L, this),
            0x66 => Instructions.MovRegister(REG8.H, REG8.HL, this),
            0x67 => Instructions.MovRegister(REG8.H, REG8.A, this),
            0x68 => Instructions.MovRegister(REG8.L, REG8.B, this),
            0x69 => Instructions.MovRegister(REG8.L, REG8.C, this),
            0x6A => Instructions.MovRegister(REG8.L, REG8.D, this),
            0x6B => Instructions.MovRegister(REG8.L, REG8.E, this),
            0x6C => Instructions.MovRegister(REG8.L, REG8.H, this),
            0x6D => Instructions.MovRegister(REG8.L, REG8.L, this),
            0x6E => Instructions.MovRegister(REG8.L, REG8.HL, this),
            0x6F => Instructions.MovRegister(REG8.L, REG8.A, this),
            0x70 => Instructions.MovRegister(REG8.HL, REG8.B, this),
            0x71 => Instructions.MovRegister(REG8.HL, REG8.C, this),
            0x72 => Instructions.MovRegister(REG8.HL, REG8.D, this),
            0x73 => Instructions.MovRegister(REG8.HL, REG8.E, this),
            0x74 => Instructions.MovRegister(REG8.HL, REG8.H, this),
            0x75 => Instructions.MovRegister(REG8.HL, REG8.L, this),
            0x77 => Instructions.MovRegister(REG8.HL, REG8.A, this),
            0x78 => Instructions.MovRegister(REG8.A, REG8.B, this),
            0x79 => Instructions.MovRegister(REG8.A, REG8.C, this),
            0x7A => Instructions.MovRegister(REG8.A, REG8.D, this),
            0x7B => Instructions.MovRegister(REG8.A, REG8.E, this),
            0x7C => Instructions.MovRegister(REG8.A, REG8.H, this),
            0x7D => Instructions.MovRegister(REG8.A, REG8.L, this),
            0x7E => Instructions.MovRegister(REG8.A, REG8.HL, this),
            0x7F => Instructions.MovRegister(REG8.A, REG8.A, this),

            0x02 => Instructions.LoadRegisterA(REG16.BC, this, MemoryBus),
            0x12 => Instructions.LoadRegisterA(REG16.DE, this, MemoryBus),
            0x0A => Instructions.StoreRegisterA(REG16.BC, this, MemoryBus),
            0x1A => Instructions.StoreRegisterA(REG16.DE, this, MemoryBus),

            0x22 => Instructions.StoreAIncHL(this, MemoryBus),
            0x32 => Instructions.StoreADecHL(this, MemoryBus),
            0x2A => Instructions.LoadAIncHL(this, MemoryBus),
            0x3A => Instructions.LoadADecHL(this, MemoryBus),

            0x06 => Instructions.LoadImmediate(REG8.B, this),
            0x16 => Instructions.LoadImmediate(REG8.D, this),
            0x26 => Instructions.LoadImmediate(REG8.H, this),
            0x36 => Instructions.LoadImmediate(REG8.HL, this),

            0x0E => Instructions.LoadImmediate(REG8.C, this),
            0x1E => Instructions.LoadImmediate(REG8.E, this),
            0x2E => Instructions.LoadImmediate(REG8.L, this),
            0x3E => Instructions.LoadImmediate(REG8.A, this),

            0xEA => Instructions.StoreAIndirect(this, MemoryBus),
            0xFA => Instructions.LoadAIndirect(this, MemoryBus),

            0xE0 => Instructions.StoreFFPageImmediateA(this, MemoryBus),
            0xF0 => Instructions.LoadFFPageImmediateA(this, MemoryBus),
            0xE2 => Instructions.StoreFFPageIndirectC(this, MemoryBus),
            0xF2 => Instructions.LoadFFPageIndirectC(this, MemoryBus),

            0x01 => Instructions.LoadRegisterImmediate16(REG16.BC, this),
            0x11 => Instructions.LoadRegisterImmediate16(REG16.DE, this),
            0x21 => Instructions.LoadRegisterImmediate16(REG16.HL, this),
#endregion

#region Math
            0x03 => Instructions.Inc16(REG16.BC, this),
            0x13 => Instructions.Inc16(REG16.DE, this),
            0x23 => Instructions.Inc16(REG16.HL, this),

            0x0B => Instructions.Dec16(REG16.BC, this),
            0x1B => Instructions.Dec16(REG16.DE, this),
            0x2B => Instructions.Dec16(REG16.HL, this),

            0x04 => Instructions.Inc8(REG8.B, this),
            0x14 => Instructions.Inc8(REG8.D, this),
            0x24 => Instructions.Inc8(REG8.H, this),
            0x34 => Instructions.Inc8(REG8.HL, this),
            0x0C => Instructions.Inc8(REG8.C, this),
            0x1C => Instructions.Inc8(REG8.E, this),
            0x2C => Instructions.Inc8(REG8.L, this),
            0x3C => Instructions.Inc8(REG8.A, this),

            0x05 => Instructions.Dec8(REG8.B, this),
            0x15 => Instructions.Dec8(REG8.D, this),
            0x25 => Instructions.Dec8(REG8.H, this),
            0x35 => Instructions.Dec8(REG8.HL, this),
            0x0D => Instructions.Dec8(REG8.C, this),
            0x1D => Instructions.Dec8(REG8.E, this),
            0x2D => Instructions.Dec8(REG8.L, this),
            0x3D => Instructions.Dec8(REG8.A, this),

            0x09 => Instructions.AddReg16(REG16.HL, REG16.BC, this),
            0x19 => Instructions.AddReg16(REG16.HL, REG16.DE, this),
            0x29 => Instructions.AddReg16(REG16.HL, REG16.HL, this),

            0x80 => Instructions.AddReg8(REG8.B, this),
            0x81 => Instructions.AddReg8(REG8.C, this),
            0x82 => Instructions.AddReg8(REG8.D, this),
            0x83 => Instructions.AddReg8(REG8.E, this),
            0x84 => Instructions.AddReg8(REG8.H, this),
            0x85 => Instructions.AddReg8(REG8.L, this),
            0x86 => Instructions.AddReg8(REG8.HL, this),
            0x87 => Instructions.AddReg8(REG8.A, this),

            0x88 => Instructions.AddCarryReg8(REG8.B, this),
            0x89 => Instructions.AddCarryReg8(REG8.C, this),
            0x8A => Instructions.AddCarryReg8(REG8.D, this),
            0x8B => Instructions.AddCarryReg8(REG8.E, this),
            0x8C => Instructions.AddCarryReg8(REG8.H, this),
            0x8D => Instructions.AddCarryReg8(REG8.L, this),
            0x8E => Instructions.AddCarryReg8(REG8.HL, this),
            0x8F => Instructions.AddCarryReg8(REG8.A, this),

            0x90 => Instructions.SubReg8(REG8.B, this),
            0x91 => Instructions.SubReg8(REG8.C, this),
            0x92 => Instructions.SubReg8(REG8.D, this),
            0x93 => Instructions.SubReg8(REG8.E, this),
            0x94 => Instructions.SubReg8(REG8.H, this),
            0x95 => Instructions.SubReg8(REG8.L, this),
            0x96 => Instructions.SubReg8(REG8.HL, this),
            0x97 => Instructions.SubReg8(REG8.A, this),

            0x98 => Instructions.SubCarryReg8(REG8.B, this),
            0x99 => Instructions.SubCarryReg8(REG8.C, this),
            0x9A => Instructions.SubCarryReg8(REG8.D, this),
            0x9B => Instructions.SubCarryReg8(REG8.E, this),
            0x9C => Instructions.SubCarryReg8(REG8.H, this),
            0x9D => Instructions.SubCarryReg8(REG8.L, this),
            0x9E => Instructions.SubCarryReg8(REG8.HL, this),
            0x9F => Instructions.SubCarryReg8(REG8.A, this),

            0xA0 => Instructions.ANDReg8(REG8.B, this),
            0xA1 => Instructions.ANDReg8(REG8.C, this),
            0xA2 => Instructions.ANDReg8(REG8.D, this),
            0xA3 => Instructions.ANDReg8(REG8.E, this),
            0xA4 => Instructions.ANDReg8(REG8.H, this),
            0xA5 => Instructions.ANDReg8(REG8.L, this),
            0xA6 => Instructions.ANDReg8(REG8.HL, this),
            0xA7 => Instructions.ANDReg8(REG8.A, this),

            0xA8 => Instructions.XORReg8(REG8.B, this),
            0xA9 => Instructions.XORReg8(REG8.C, this),
            0xAA => Instructions.XORReg8(REG8.D, this),
            0xAB => Instructions.XORReg8(REG8.E, this),
            0xAC => Instructions.XORReg8(REG8.H, this),
            0xAD => Instructions.XORReg8(REG8.L, this),
            0xAE => Instructions.XORReg8(REG8.HL, this),
            0xAF => Instructions.XORReg8(REG8.A, this),

            0xB0 => Instructions.ORReg8(REG8.B, this),
            0xB1 => Instructions.ORReg8(REG8.C, this),
            0xB2 => Instructions.ORReg8(REG8.D, this),
            0xB3 => Instructions.ORReg8(REG8.E, this),
            0xB4 => Instructions.ORReg8(REG8.H, this),
            0xB5 => Instructions.ORReg8(REG8.L, this),
            0xB6 => Instructions.ORReg8(REG8.HL, this),
            0xB7 => Instructions.ORReg8(REG8.A, this),

            0xB8 => Instructions.CompareReg8(REG8.B, this),
            0xB9 => Instructions.CompareReg8(REG8.C, this),
            0xBA => Instructions.CompareReg8(REG8.D, this),
            0xBB => Instructions.CompareReg8(REG8.E, this),
            0xBC => Instructions.CompareReg8(REG8.H, this),
            0xBD => Instructions.CompareReg8(REG8.L, this),
            0xBE => Instructions.CompareReg8(REG8.HL, this),
            0xBF => Instructions.CompareReg8(REG8.A, this),

            0xC6 => Instructions.AddImmediate(this),
            0xD6 => Instructions.SubImmediate(this),
            0xE6 => Instructions.ANDImmediate(this),
            0xF6 => Instructions.ORImmediate(this),

            0xCE => Instructions.AddCarryImmediate(this),
            0xDE => Instructions.SubCarryImmediate(this),
            0xEE => Instructions.XORImmediate(this),
            0xFE => Instructions.CompareImmediate(this),
#endregion

#region Miscellaneous
            0x27 => Instructions.DecimalAdjustRegisterA(this),
            0x2F => Instructions.ComplimentRegisterA(this),

            0x37 => Instructions.SetCarryFlag(this),
            0x3F => Instructions.ComplimentCarryFlag(this),

            0x07 => Instructions.RotateLeftCarryA(this),
            0x17 => Instructions.RotateLeftA(this),

            0x0F => Instructions.RotateRightCarryA(this),
            0x1F => Instructions.RotateRightA(this),
#endregion
        };

        public Status ExecuteCB()
        {
            byte opcode = Fetch8();
            REG8 register = (REG8)(opcode & 0b111);
            return opcode switch
            {
                (>= 0x00) and (< 0x08) => Instructions.CBRotateLeftCarry(register, this),
                (>= 0x08) and (< 0x10) => Instructions.CBRotateRightCarry(register, this),
                (>= 0x10) and (< 0x18) => Instructions.CBRotateLeft(register, this),
                (>= 0x18) and (< 0x20) => Instructions.CBRotateRight(register, this),
                (>= 0x20) and (< 0x28) => Instructions.CBShiftLeftArithmetic(register, this),
                (>= 0x28) and (< 0x30) => Instructions.CBShiftRightArithmetic(register, this),
                (>= 0x30) and (< 0x38) => Instructions.CBSwap(register, this),
                (>= 0x38) and (< 0x40) => Instructions.CBShiftRightLogical(register, this),
                (>= 0x40) and (< 0x80) => Instructions.CBBit(register, (opcode >> 3) & 0b111, this),
                (>= 0x80) and (< 0xC0) => Instructions.CBReset(register, (opcode >> 3) & 0b111, this),
                (>= 0xC0) and (<= 0xFF) => Instructions.CBSet(register, (opcode >> 3) & 0b111, this),
            };
        }
    }
}

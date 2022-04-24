namespace NullGB.Core.CPU;

internal static class Instructions
{
    #region Instruction Metadata
    internal record Instruction(int Opcode, byte Size, byte BaseTime, byte BranchTime, string Info);

    public static Instruction[] Ops = new Instruction[]
    {
        new Instruction(Opcode: 0x0000, Size: 1, BaseTime: 1, BranchTime: 1, Info: "NOP"),
        new Instruction(Opcode: 0x0001, Size: 3, BaseTime: 3, BranchTime: 3, Info: "LD BC,d16"),
        new Instruction(Opcode: 0x0002, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD (BC),A"),
        new Instruction(Opcode: 0x0003, Size: 1, BaseTime: 2, BranchTime: 2, Info: "INC BC"),
        new Instruction(Opcode: 0x0004, Size: 1, BaseTime: 1, BranchTime: 1, Info: "INC B"),
        new Instruction(Opcode: 0x0005, Size: 1, BaseTime: 1, BranchTime: 1, Info: "DEC B"),
        new Instruction(Opcode: 0x0006, Size: 2, BaseTime: 2, BranchTime: 2, Info: "LD B,d8"),
        new Instruction(Opcode: 0x0007, Size: 1, BaseTime: 1, BranchTime: 1, Info: "RLCA"),
        new Instruction(Opcode: 0x0008, Size: 3, BaseTime: 5, BranchTime: 5, Info: "LD (a16),SP"),
        new Instruction(Opcode: 0x0009, Size: 1, BaseTime: 2, BranchTime: 2, Info: "ADD HL,BC"),
        new Instruction(Opcode: 0x000A, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD A,(BC)"),
        new Instruction(Opcode: 0x000B, Size: 1, BaseTime: 2, BranchTime: 2, Info: "DEC BC"),
        new Instruction(Opcode: 0x000C, Size: 1, BaseTime: 1, BranchTime: 1, Info: "INC C"),
        new Instruction(Opcode: 0x000D, Size: 1, BaseTime: 1, BranchTime: 1, Info: "DEC C"),
        new Instruction(Opcode: 0x000E, Size: 2, BaseTime: 2, BranchTime: 2, Info: "LD C,d8"),
        new Instruction(Opcode: 0x000F, Size: 1, BaseTime: 1, BranchTime: 1, Info: "RRCA"),
        new Instruction(Opcode: 0x0010, Size: 2, BaseTime: 1, BranchTime: 1, Info: "STOP 0"),
        new Instruction(Opcode: 0x0011, Size: 3, BaseTime: 3, BranchTime: 3, Info: "LD DE,d16"),
        new Instruction(Opcode: 0x0012, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD (DE),A"),
        new Instruction(Opcode: 0x0013, Size: 1, BaseTime: 2, BranchTime: 2, Info: "INC DE"),
        new Instruction(Opcode: 0x0014, Size: 1, BaseTime: 1, BranchTime: 1, Info: "INC D"),
        new Instruction(Opcode: 0x0015, Size: 1, BaseTime: 1, BranchTime: 1, Info: "DEC D"),
        new Instruction(Opcode: 0x0016, Size: 2, BaseTime: 2, BranchTime: 2, Info: "LD D,d8"),
        new Instruction(Opcode: 0x0017, Size: 1, BaseTime: 1, BranchTime: 1, Info: "RLA"),
        new Instruction(Opcode: 0x0018, Size: 2, BaseTime: 3, BranchTime: 3, Info: "JR r8"),
        new Instruction(Opcode: 0x0019, Size: 1, BaseTime: 2, BranchTime: 2, Info: "ADD HL,DE"),
        new Instruction(Opcode: 0x001A, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD A,(DE)"),
        new Instruction(Opcode: 0x001B, Size: 1, BaseTime: 2, BranchTime: 2, Info: "DEC DE"),
        new Instruction(Opcode: 0x001C, Size: 1, BaseTime: 1, BranchTime: 1, Info: "INC E"),
        new Instruction(Opcode: 0x001D, Size: 1, BaseTime: 1, BranchTime: 1, Info: "DEC E"),
        new Instruction(Opcode: 0x001E, Size: 2, BaseTime: 2, BranchTime: 2, Info: "LD E,d8"),
        new Instruction(Opcode: 0x001F, Size: 1, BaseTime: 1, BranchTime: 1, Info: "RRA"),
        new Instruction(Opcode: 0x0020, Size: 2, BaseTime: 2, BranchTime: 3, Info: "JR NZ,r8"),
        new Instruction(Opcode: 0x0021, Size: 3, BaseTime: 3, BranchTime: 3, Info: "LD HL,d16"),
        new Instruction(Opcode: 0x0022, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD (HL+),A"),
        new Instruction(Opcode: 0x0023, Size: 1, BaseTime: 2, BranchTime: 2, Info: "INC HL"),
        new Instruction(Opcode: 0x0024, Size: 1, BaseTime: 1, BranchTime: 1, Info: "INC H"),
        new Instruction(Opcode: 0x0025, Size: 1, BaseTime: 1, BranchTime: 1, Info: "DEC H"),
        new Instruction(Opcode: 0x0026, Size: 2, BaseTime: 2, BranchTime: 2, Info: "LD H,d8"),
        new Instruction(Opcode: 0x0027, Size: 1, BaseTime: 1, BranchTime: 1, Info: "DAA"),
        new Instruction(Opcode: 0x0028, Size: 2, BaseTime: 2, BranchTime: 3, Info: "JR Z,r8"),
        new Instruction(Opcode: 0x0029, Size: 1, BaseTime: 2, BranchTime: 2, Info: "ADD HL,HL"),
        new Instruction(Opcode: 0x002A, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD A,(HL+)"),
        new Instruction(Opcode: 0x002B, Size: 1, BaseTime: 2, BranchTime: 2, Info: "DEC HL"),
        new Instruction(Opcode: 0x002C, Size: 1, BaseTime: 1, BranchTime: 1, Info: "INC L"),
        new Instruction(Opcode: 0x002D, Size: 1, BaseTime: 1, BranchTime: 1, Info: "DEC L"),
        new Instruction(Opcode: 0x002E, Size: 2, BaseTime: 2, BranchTime: 2, Info: "LD L,d8"),
        new Instruction(Opcode: 0x002F, Size: 1, BaseTime: 1, BranchTime: 1, Info: "CPL"),
        new Instruction(Opcode: 0x0030, Size: 2, BaseTime: 2, BranchTime: 3, Info: "JR NC,r8"),
        new Instruction(Opcode: 0x0031, Size: 3, BaseTime: 3, BranchTime: 3, Info: "LD SP,d16"),
        new Instruction(Opcode: 0x0032, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD (HL-),A"),
        new Instruction(Opcode: 0x0033, Size: 1, BaseTime: 2, BranchTime: 2, Info: "INC SP"),
        new Instruction(Opcode: 0x0034, Size: 1, BaseTime: 3, BranchTime: 3, Info: "INC (HL)"),
        new Instruction(Opcode: 0x0035, Size: 1, BaseTime: 3, BranchTime: 3, Info: "DEC (HL)"),
        new Instruction(Opcode: 0x0036, Size: 2, BaseTime: 3, BranchTime: 3, Info: "LD (HL),d8"),
        new Instruction(Opcode: 0x0037, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SCF"),
        new Instruction(Opcode: 0x0038, Size: 2, BaseTime: 2, BranchTime: 3, Info: "JR C,r8"),
        new Instruction(Opcode: 0x0039, Size: 1, BaseTime: 2, BranchTime: 2, Info: "ADD HL,SP"),
        new Instruction(Opcode: 0x003A, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD A,(HL-)"),
        new Instruction(Opcode: 0x003B, Size: 1, BaseTime: 2, BranchTime: 2, Info: "DEC SP"),
        new Instruction(Opcode: 0x003C, Size: 1, BaseTime: 1, BranchTime: 1, Info: "INC A"),
        new Instruction(Opcode: 0x003D, Size: 1, BaseTime: 1, BranchTime: 1, Info: "DEC A"),
        new Instruction(Opcode: 0x003E, Size: 2, BaseTime: 2, BranchTime: 2, Info: "LD A,d8"),
        new Instruction(Opcode: 0x003F, Size: 1, BaseTime: 1, BranchTime: 1, Info: "CCF"),
        new Instruction(Opcode: 0x0040, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD B,B"),
        new Instruction(Opcode: 0x0041, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD B,C"),
        new Instruction(Opcode: 0x0042, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD B,D"),
        new Instruction(Opcode: 0x0043, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD B,E"),
        new Instruction(Opcode: 0x0044, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD B,H"),
        new Instruction(Opcode: 0x0045, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD B,L"),
        new Instruction(Opcode: 0x0046, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD B,(HL)"),
        new Instruction(Opcode: 0x0047, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD B,A"),
        new Instruction(Opcode: 0x0048, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD C,B"),
        new Instruction(Opcode: 0x0049, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD C,C"),
        new Instruction(Opcode: 0x004A, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD C,D"),
        new Instruction(Opcode: 0x004B, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD C,E"),
        new Instruction(Opcode: 0x004C, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD C,H"),
        new Instruction(Opcode: 0x004D, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD C,L"),
        new Instruction(Opcode: 0x004E, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD C,(HL)"),
        new Instruction(Opcode: 0x004F, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD C,A"),
        new Instruction(Opcode: 0x0050, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD D,B"),
        new Instruction(Opcode: 0x0051, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD D,C"),
        new Instruction(Opcode: 0x0052, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD D,D"),
        new Instruction(Opcode: 0x0053, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD D,E"),
        new Instruction(Opcode: 0x0054, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD D,H"),
        new Instruction(Opcode: 0x0055, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD D,L"),
        new Instruction(Opcode: 0x0056, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD D,(HL)"),
        new Instruction(Opcode: 0x0057, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD D,A"),
        new Instruction(Opcode: 0x0058, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD E,B"),
        new Instruction(Opcode: 0x0059, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD E,C"),
        new Instruction(Opcode: 0x005A, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD E,D"),
        new Instruction(Opcode: 0x005B, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD E,E"),
        new Instruction(Opcode: 0x005C, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD E,H"),
        new Instruction(Opcode: 0x005D, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD E,L"),
        new Instruction(Opcode: 0x005E, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD E,(HL)"),
        new Instruction(Opcode: 0x005F, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD E,A"),
        new Instruction(Opcode: 0x0060, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD H,B"),
        new Instruction(Opcode: 0x0061, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD H,C"),
        new Instruction(Opcode: 0x0062, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD H,D"),
        new Instruction(Opcode: 0x0063, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD H,E"),
        new Instruction(Opcode: 0x0064, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD H,H"),
        new Instruction(Opcode: 0x0065, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD H,L"),
        new Instruction(Opcode: 0x0066, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD H,(HL)"),
        new Instruction(Opcode: 0x0067, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD H,A"),
        new Instruction(Opcode: 0x0068, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD L,B"),
        new Instruction(Opcode: 0x0069, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD L,C"),
        new Instruction(Opcode: 0x006A, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD L,D"),
        new Instruction(Opcode: 0x006B, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD L,E"),
        new Instruction(Opcode: 0x006C, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD L,H"),
        new Instruction(Opcode: 0x006D, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD L,L"),
        new Instruction(Opcode: 0x006E, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD L,(HL)"),
        new Instruction(Opcode: 0x006F, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD L,A"),
        new Instruction(Opcode: 0x0070, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD (HL),B"),
        new Instruction(Opcode: 0x0071, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD (HL),C"),
        new Instruction(Opcode: 0x0072, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD (HL),D"),
        new Instruction(Opcode: 0x0073, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD (HL),E"),
        new Instruction(Opcode: 0x0074, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD (HL),H"),
        new Instruction(Opcode: 0x0075, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD (HL),L"),
        new Instruction(Opcode: 0x0076, Size: 1, BaseTime: 1, BranchTime: 1, Info: "HALT"),
        new Instruction(Opcode: 0x0077, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD (HL),A"),
        new Instruction(Opcode: 0x0078, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD A,B"),
        new Instruction(Opcode: 0x0079, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD A,C"),
        new Instruction(Opcode: 0x007A, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD A,D"),
        new Instruction(Opcode: 0x007B, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD A,E"),
        new Instruction(Opcode: 0x007C, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD A,H"),
        new Instruction(Opcode: 0x007D, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD A,L"),
        new Instruction(Opcode: 0x007E, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD A,(HL)"),
        new Instruction(Opcode: 0x007F, Size: 1, BaseTime: 1, BranchTime: 1, Info: "LD A,A"),
        new Instruction(Opcode: 0x0080, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADD A,B"),
        new Instruction(Opcode: 0x0081, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADD A,C"),
        new Instruction(Opcode: 0x0082, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADD A,D"),
        new Instruction(Opcode: 0x0083, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADD A,E"),
        new Instruction(Opcode: 0x0084, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADD A,H"),
        new Instruction(Opcode: 0x0085, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADD A,L"),
        new Instruction(Opcode: 0x0086, Size: 1, BaseTime: 2, BranchTime: 2, Info: "ADD A,(HL)"),
        new Instruction(Opcode: 0x0087, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADD A,A"),
        new Instruction(Opcode: 0x0088, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADC A,B"),
        new Instruction(Opcode: 0x0089, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADC A,C"),
        new Instruction(Opcode: 0x008A, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADC A,D"),
        new Instruction(Opcode: 0x008B, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADC A,E"),
        new Instruction(Opcode: 0x008C, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADC A,H"),
        new Instruction(Opcode: 0x008D, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADC A,L"),
        new Instruction(Opcode: 0x008E, Size: 1, BaseTime: 2, BranchTime: 2, Info: "ADC A,(HL)"),
        new Instruction(Opcode: 0x008F, Size: 1, BaseTime: 1, BranchTime: 1, Info: "ADC A,A"),
        new Instruction(Opcode: 0x0090, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SUB B"),
        new Instruction(Opcode: 0x0091, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SUB C"),
        new Instruction(Opcode: 0x0092, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SUB D"),
        new Instruction(Opcode: 0x0093, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SUB E"),
        new Instruction(Opcode: 0x0094, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SUB H"),
        new Instruction(Opcode: 0x0095, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SUB L"),
        new Instruction(Opcode: 0x0096, Size: 1, BaseTime: 2, BranchTime: 2, Info: "SUB (HL)"),
        new Instruction(Opcode: 0x0097, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SUB A"),
        new Instruction(Opcode: 0x0098, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SBC A,B"),
        new Instruction(Opcode: 0x0099, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SBC A,C"),
        new Instruction(Opcode: 0x009A, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SBC A,D"),
        new Instruction(Opcode: 0x009B, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SBC A,E"),
        new Instruction(Opcode: 0x009C, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SBC A,H"),
        new Instruction(Opcode: 0x009D, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SBC A,L"),
        new Instruction(Opcode: 0x009E, Size: 1, BaseTime: 2, BranchTime: 2, Info: "SBC A,(HL)"),
        new Instruction(Opcode: 0x009F, Size: 1, BaseTime: 1, BranchTime: 1, Info: "SBC A,A"),
        new Instruction(Opcode: 0x00A0, Size: 1, BaseTime: 1, BranchTime: 1, Info: "AND B"),
        new Instruction(Opcode: 0x00A1, Size: 1, BaseTime: 1, BranchTime: 1, Info: "AND C"),
        new Instruction(Opcode: 0x00A2, Size: 1, BaseTime: 1, BranchTime: 1, Info: "AND D"),
        new Instruction(Opcode: 0x00A3, Size: 1, BaseTime: 1, BranchTime: 1, Info: "AND E"),
        new Instruction(Opcode: 0x00A4, Size: 1, BaseTime: 1, BranchTime: 1, Info: "AND H"),
        new Instruction(Opcode: 0x00A5, Size: 1, BaseTime: 1, BranchTime: 1, Info: "AND L"),
        new Instruction(Opcode: 0x00A6, Size: 1, BaseTime: 2, BranchTime: 2, Info: "AND (HL)"),
        new Instruction(Opcode: 0x00A7, Size: 1, BaseTime: 1, BranchTime: 1, Info: "AND A"),
        new Instruction(Opcode: 0x00A8, Size: 1, BaseTime: 1, BranchTime: 1, Info: "XOR B"),
        new Instruction(Opcode: 0x00A9, Size: 1, BaseTime: 1, BranchTime: 1, Info: "XOR C"),
        new Instruction(Opcode: 0x00AA, Size: 1, BaseTime: 1, BranchTime: 1, Info: "XOR D"),
        new Instruction(Opcode: 0x00AB, Size: 1, BaseTime: 1, BranchTime: 1, Info: "XOR E"),
        new Instruction(Opcode: 0x00AC, Size: 1, BaseTime: 1, BranchTime: 1, Info: "XOR H"),
        new Instruction(Opcode: 0x00AD, Size: 1, BaseTime: 1, BranchTime: 1, Info: "XOR L"),
        new Instruction(Opcode: 0x00AE, Size: 1, BaseTime: 2, BranchTime: 2, Info: "XOR (HL)"),
        new Instruction(Opcode: 0x00AF, Size: 1, BaseTime: 1, BranchTime: 1, Info: "XOR A"),
        new Instruction(Opcode: 0x00B0, Size: 1, BaseTime: 1, BranchTime: 1, Info: "OR B"),
        new Instruction(Opcode: 0x00B1, Size: 1, BaseTime: 1, BranchTime: 1, Info: "OR C"),
        new Instruction(Opcode: 0x00B2, Size: 1, BaseTime: 1, BranchTime: 1, Info: "OR D"),
        new Instruction(Opcode: 0x00B3, Size: 1, BaseTime: 1, BranchTime: 1, Info: "OR E"),
        new Instruction(Opcode: 0x00B4, Size: 1, BaseTime: 1, BranchTime: 1, Info: "OR H"),
        new Instruction(Opcode: 0x00B5, Size: 1, BaseTime: 1, BranchTime: 1, Info: "OR L"),
        new Instruction(Opcode: 0x00B6, Size: 1, BaseTime: 2, BranchTime: 2, Info: "OR (HL)"),
        new Instruction(Opcode: 0x00B7, Size: 1, BaseTime: 1, BranchTime: 1, Info: "OR A"),
        new Instruction(Opcode: 0x00B8, Size: 1, BaseTime: 1, BranchTime: 1, Info: "CP B"),
        new Instruction(Opcode: 0x00B9, Size: 1, BaseTime: 1, BranchTime: 1, Info: "CP C"),
        new Instruction(Opcode: 0x00BA, Size: 1, BaseTime: 1, BranchTime: 1, Info: "CP D"),
        new Instruction(Opcode: 0x00BB, Size: 1, BaseTime: 1, BranchTime: 1, Info: "CP E"),
        new Instruction(Opcode: 0x00BC, Size: 1, BaseTime: 1, BranchTime: 1, Info: "CP H"),
        new Instruction(Opcode: 0x00BD, Size: 1, BaseTime: 1, BranchTime: 1, Info: "CP L"),
        new Instruction(Opcode: 0x00BE, Size: 1, BaseTime: 2, BranchTime: 2, Info: "CP (HL)"),
        new Instruction(Opcode: 0x00BF, Size: 1, BaseTime: 1, BranchTime: 1, Info: "CP A"),
        new Instruction(Opcode: 0x00C0, Size: 1, BaseTime: 2, BranchTime: 5, Info: "RET NZ"),
        new Instruction(Opcode: 0x00C1, Size: 1, BaseTime: 3, BranchTime: 3, Info: "POP BC"),
        new Instruction(Opcode: 0x00C2, Size: 3, BaseTime: 3, BranchTime: 4, Info: "JP NZ,a16"),
        new Instruction(Opcode: 0x00C3, Size: 3, BaseTime: 4, BranchTime: 4, Info: "JP a16"),
        new Instruction(Opcode: 0x00C4, Size: 3, BaseTime: 3, BranchTime: 6, Info: "CALL NZ,a16"),
        new Instruction(Opcode: 0x00C5, Size: 1, BaseTime: 4, BranchTime: 4, Info: "PUSH BC"),
        new Instruction(Opcode: 0x00C6, Size: 2, BaseTime: 2, BranchTime: 2, Info: "ADD A,d8"),
        new Instruction(Opcode: 0x00C7, Size: 1, BaseTime: 4, BranchTime: 4, Info: "RST 00H"),
        new Instruction(Opcode: 0x00C8, Size: 1, BaseTime: 2, BranchTime: 5, Info: "RET Z"),
        new Instruction(Opcode: 0x00C9, Size: 1, BaseTime: 4, BranchTime: 4, Info: "RET"),
        new Instruction(Opcode: 0x00CA, Size: 3, BaseTime: 3, BranchTime: 4, Info: "JP Z,a16"),
        new Instruction(Opcode: 0x00CB, Size: 2, BaseTime: 1, BranchTime: 1, Info: "PREFIX CB"),
        new Instruction(Opcode: 0x00CC, Size: 3, BaseTime: 3, BranchTime: 6, Info: "CALL Z,a16"),
        new Instruction(Opcode: 0x00CD, Size: 3, BaseTime: 6, BranchTime: 6, Info: "CALL a16"),
        new Instruction(Opcode: 0x00CE, Size: 2, BaseTime: 2, BranchTime: 2, Info: "ADC A,d8"),
        new Instruction(Opcode: 0x00CF, Size: 1, BaseTime: 4, BranchTime: 4, Info: "RST 08H"),
        new Instruction(Opcode: 0x00D0, Size: 1, BaseTime: 2, BranchTime: 5, Info: "RET NC"),
        new Instruction(Opcode: 0x00D1, Size: 1, BaseTime: 3, BranchTime: 3, Info: "POP DE"),
        new Instruction(Opcode: 0x00D2, Size: 3, BaseTime: 3, BranchTime: 4, Info: "JP NC,a16"),
        new Instruction(Opcode: 0x00D3, Size: 0, BaseTime: 0, BranchTime: 0, Info: "NOT USED"),
        new Instruction(Opcode: 0x00D4, Size: 3, BaseTime: 3, BranchTime: 6, Info: "CALL NC,a16"),
        new Instruction(Opcode: 0x00D5, Size: 1, BaseTime: 4, BranchTime: 4, Info: "PUSH DE"),
        new Instruction(Opcode: 0x00D6, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SUB d8"),
        new Instruction(Opcode: 0x00D7, Size: 1, BaseTime: 4, BranchTime: 4, Info: "RST 10H"),
        new Instruction(Opcode: 0x00D8, Size: 1, BaseTime: 2, BranchTime: 5, Info: "RET C"),
        new Instruction(Opcode: 0x00D9, Size: 1, BaseTime: 4, BranchTime: 4, Info: "RETI"),
        new Instruction(Opcode: 0x00DA, Size: 3, BaseTime: 3, BranchTime: 4, Info: "JP C,a16"),
        new Instruction(Opcode: 0x00DB, Size: 0, BaseTime: 0, BranchTime: 0, Info: "NOT USED"),
        new Instruction(Opcode: 0x00DC, Size: 3, BaseTime: 3, BranchTime: 6, Info: "CALL C,a16"),
        new Instruction(Opcode: 0x00DD, Size: 0, BaseTime: 0, BranchTime: 0, Info: "NOT USED"),
        new Instruction(Opcode: 0x00DE, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SBC A,d8"),
        new Instruction(Opcode: 0x00DF, Size: 1, BaseTime: 4, BranchTime: 4, Info: "RST 18H"),
        new Instruction(Opcode: 0x00E0, Size: 2, BaseTime: 3, BranchTime: 3, Info: "LDH (a8),A"),
        new Instruction(Opcode: 0x00E1, Size: 1, BaseTime: 3, BranchTime: 3, Info: "POP HL"),
        new Instruction(Opcode: 0x00E2, Size: 2, BaseTime: 2, BranchTime: 2, Info: "LD (C),A"),
        new Instruction(Opcode: 0x00E3, Size: 0, BaseTime: 0, BranchTime: 0, Info: "NOT USED"),
        new Instruction(Opcode: 0x00E4, Size: 0, BaseTime: 0, BranchTime: 0, Info: "NOT USED"),
        new Instruction(Opcode: 0x00E5, Size: 1, BaseTime: 4, BranchTime: 4, Info: "PUSH HL"),
        new Instruction(Opcode: 0x00E6, Size: 2, BaseTime: 2, BranchTime: 2, Info: "AND d8"),
        new Instruction(Opcode: 0x00E7, Size: 1, BaseTime: 4, BranchTime: 4, Info: "RST 20H"),
        new Instruction(Opcode: 0x00E8, Size: 2, BaseTime: 4, BranchTime: 4, Info: "ADD SP,r8"),
        new Instruction(Opcode: 0x00E9, Size: 1, BaseTime: 1, BranchTime: 1, Info: "JP (HL)"),
        new Instruction(Opcode: 0x00EA, Size: 3, BaseTime: 4, BranchTime: 4, Info: "LD (a16),A"),
        new Instruction(Opcode: 0x00EB, Size: 0, BaseTime: 0, BranchTime: 0, Info: "NOT USED"),
        new Instruction(Opcode: 0x00EC, Size: 0, BaseTime: 0, BranchTime: 0, Info: "NOT USED"),
        new Instruction(Opcode: 0x00ED, Size: 0, BaseTime: 0, BranchTime: 0, Info: "NOT USED"),
        new Instruction(Opcode: 0x00EE, Size: 2, BaseTime: 2, BranchTime: 2, Info: "XOR d8"),
        new Instruction(Opcode: 0x00EF, Size: 1, BaseTime: 4, BranchTime: 4, Info: "RST 28H"),
        new Instruction(Opcode: 0x00F0, Size: 2, BaseTime: 3, BranchTime: 3, Info: "LDH A,(a8)"),
        new Instruction(Opcode: 0x00F1, Size: 1, BaseTime: 3, BranchTime: 3, Info: "POP AF"),
        new Instruction(Opcode: 0x00F2, Size: 2, BaseTime: 2, BranchTime: 2, Info: "LD A,(C)"),
        new Instruction(Opcode: 0x00F3, Size: 1, BaseTime: 1, BranchTime: 1, Info: "DI"),
        new Instruction(Opcode: 0x00F4, Size: 0, BaseTime: 0, BranchTime: 0, Info: "NOT USED"),
        new Instruction(Opcode: 0x00F5, Size: 1, BaseTime: 4, BranchTime: 4, Info: "PUSH AF"),
        new Instruction(Opcode: 0x00F6, Size: 2, BaseTime: 2, BranchTime: 2, Info: "OR d8"),
        new Instruction(Opcode: 0x00F7, Size: 1, BaseTime: 4, BranchTime: 4, Info: "RST 30H"),
        new Instruction(Opcode: 0x00F8, Size: 2, BaseTime: 3, BranchTime: 3, Info: "LD HL,SP+r8"),
        new Instruction(Opcode: 0x00F9, Size: 1, BaseTime: 2, BranchTime: 2, Info: "LD SP,HL"),
        new Instruction(Opcode: 0x00FA, Size: 3, BaseTime: 4, BranchTime: 4, Info: "LD A,(a16)"),
        new Instruction(Opcode: 0x00FB, Size: 1, BaseTime: 1, BranchTime: 1, Info: "EI"),
        new Instruction(Opcode: 0x00FC, Size: 0, BaseTime: 0, BranchTime: 0, Info: "NOT USED"),
        new Instruction(Opcode: 0x00FD, Size: 0, BaseTime: 0, BranchTime: 0, Info: "NOT USED"),
        new Instruction(Opcode: 0x00FE, Size: 2, BaseTime: 2, BranchTime: 2, Info: "CP d8"),
        new Instruction(Opcode: 0x00FF, Size: 1, BaseTime: 4, BranchTime: 4, Info: "RST 38H"),
        new Instruction(Opcode: 0xCB00, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RLC B"),
        new Instruction(Opcode: 0xCB01, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RLC C"),
        new Instruction(Opcode: 0xCB02, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RLC D"),
        new Instruction(Opcode: 0xCB03, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RLC E"),
        new Instruction(Opcode: 0xCB04, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RLC H"),
        new Instruction(Opcode: 0xCB05, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RLC L"),
        new Instruction(Opcode: 0xCB06, Size: 2, BaseTime: 4, BranchTime: 4, Info: "RLC (HL)"),
        new Instruction(Opcode: 0xCB07, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RLC A"),
        new Instruction(Opcode: 0xCB08, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RRC B"),
        new Instruction(Opcode: 0xCB09, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RRC C"),
        new Instruction(Opcode: 0xCB0A, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RRC D"),
        new Instruction(Opcode: 0xCB0B, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RRC E"),
        new Instruction(Opcode: 0xCB0C, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RRC H"),
        new Instruction(Opcode: 0xCB0D, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RRC L"),
        new Instruction(Opcode: 0xCB0E, Size: 2, BaseTime: 4, BranchTime: 4, Info: "RRC (HL)"),
        new Instruction(Opcode: 0xCB0F, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RRC A"),
        new Instruction(Opcode: 0xCB10, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RL B"),
        new Instruction(Opcode: 0xCB11, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RL C"),
        new Instruction(Opcode: 0xCB12, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RL D"),
        new Instruction(Opcode: 0xCB13, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RL E"),
        new Instruction(Opcode: 0xCB14, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RL H"),
        new Instruction(Opcode: 0xCB15, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RL L"),
        new Instruction(Opcode: 0xCB16, Size: 2, BaseTime: 4, BranchTime: 4, Info: "RL (HL)"),
        new Instruction(Opcode: 0xCB17, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RL A"),
        new Instruction(Opcode: 0xCB18, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RR B"),
        new Instruction(Opcode: 0xCB19, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RR C"),
        new Instruction(Opcode: 0xCB1A, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RR D"),
        new Instruction(Opcode: 0xCB1B, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RR E"),
        new Instruction(Opcode: 0xCB1C, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RR H"),
        new Instruction(Opcode: 0xCB1D, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RR L"),
        new Instruction(Opcode: 0xCB1E, Size: 2, BaseTime: 4, BranchTime: 4, Info: "RR (HL)"),
        new Instruction(Opcode: 0xCB1F, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RR A"),
        new Instruction(Opcode: 0xCB20, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SLA B"),
        new Instruction(Opcode: 0xCB21, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SLA C"),
        new Instruction(Opcode: 0xCB22, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SLA D"),
        new Instruction(Opcode: 0xCB23, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SLA E"),
        new Instruction(Opcode: 0xCB24, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SLA H"),
        new Instruction(Opcode: 0xCB25, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SLA L"),
        new Instruction(Opcode: 0xCB26, Size: 2, BaseTime: 4, BranchTime: 4, Info: "SLA (HL)"),
        new Instruction(Opcode: 0xCB27, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SLA A"),
        new Instruction(Opcode: 0xCB28, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRA B"),
        new Instruction(Opcode: 0xCB29, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRA C"),
        new Instruction(Opcode: 0xCB2A, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRA D"),
        new Instruction(Opcode: 0xCB2B, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRA E"),
        new Instruction(Opcode: 0xCB2C, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRA H"),
        new Instruction(Opcode: 0xCB2D, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRA L"),
        new Instruction(Opcode: 0xCB2E, Size: 2, BaseTime: 4, BranchTime: 4, Info: "SRA (HL)"),
        new Instruction(Opcode: 0xCB2F, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRA A"),
        new Instruction(Opcode: 0xCB30, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SWAP B"),
        new Instruction(Opcode: 0xCB31, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SWAP C"),
        new Instruction(Opcode: 0xCB32, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SWAP D"),
        new Instruction(Opcode: 0xCB33, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SWAP E"),
        new Instruction(Opcode: 0xCB34, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SWAP H"),
        new Instruction(Opcode: 0xCB35, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SWAP L"),
        new Instruction(Opcode: 0xCB36, Size: 2, BaseTime: 4, BranchTime: 4, Info: "SWAP (HL)"),
        new Instruction(Opcode: 0xCB37, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SWAP A"),
        new Instruction(Opcode: 0xCB38, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRL B"),
        new Instruction(Opcode: 0xCB39, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRL C"),
        new Instruction(Opcode: 0xCB3A, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRL D"),
        new Instruction(Opcode: 0xCB3B, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRL E"),
        new Instruction(Opcode: 0xCB3C, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRL H"),
        new Instruction(Opcode: 0xCB3D, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRL L"),
        new Instruction(Opcode: 0xCB3E, Size: 2, BaseTime: 4, BranchTime: 4, Info: "SRL (HL)"),
        new Instruction(Opcode: 0xCB3F, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SRL A"),
        new Instruction(Opcode: 0xCB40, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 0,B"),
        new Instruction(Opcode: 0xCB41, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 0,C"),
        new Instruction(Opcode: 0xCB42, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 0,D"),
        new Instruction(Opcode: 0xCB43, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 0,E"),
        new Instruction(Opcode: 0xCB44, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 0,H"),
        new Instruction(Opcode: 0xCB45, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 0,L"),
        new Instruction(Opcode: 0xCB46, Size: 2, BaseTime: 4, BranchTime: 4, Info: "BIT 0,(HL)"),
        new Instruction(Opcode: 0xCB47, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 0,A"),
        new Instruction(Opcode: 0xCB48, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 1,B"),
        new Instruction(Opcode: 0xCB49, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 1,C"),
        new Instruction(Opcode: 0xCB4A, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 1,D"),
        new Instruction(Opcode: 0xCB4B, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 1,E"),
        new Instruction(Opcode: 0xCB4C, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 1,H"),
        new Instruction(Opcode: 0xCB4D, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 1,L"),
        new Instruction(Opcode: 0xCB4E, Size: 2, BaseTime: 4, BranchTime: 4, Info: "BIT 1,(HL)"),
        new Instruction(Opcode: 0xCB4F, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 1,A"),
        new Instruction(Opcode: 0xCB50, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 2,B"),
        new Instruction(Opcode: 0xCB51, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 2,C"),
        new Instruction(Opcode: 0xCB52, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 2,D"),
        new Instruction(Opcode: 0xCB53, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 2,E"),
        new Instruction(Opcode: 0xCB54, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 2,H"),
        new Instruction(Opcode: 0xCB55, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 2,L"),
        new Instruction(Opcode: 0xCB56, Size: 2, BaseTime: 4, BranchTime: 4, Info: "BIT 2,(HL)"),
        new Instruction(Opcode: 0xCB57, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 2,A"),
        new Instruction(Opcode: 0xCB58, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 3,B"),
        new Instruction(Opcode: 0xCB59, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 3,C"),
        new Instruction(Opcode: 0xCB5A, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 3,D"),
        new Instruction(Opcode: 0xCB5B, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 3,E"),
        new Instruction(Opcode: 0xCB5C, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 3,H"),
        new Instruction(Opcode: 0xCB5D, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 3,L"),
        new Instruction(Opcode: 0xCB5E, Size: 2, BaseTime: 4, BranchTime: 4, Info: "BIT 3,(HL)"),
        new Instruction(Opcode: 0xCB5F, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 3,A"),
        new Instruction(Opcode: 0xCB60, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 4,B"),
        new Instruction(Opcode: 0xCB61, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 4,C"),
        new Instruction(Opcode: 0xCB62, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 4,D"),
        new Instruction(Opcode: 0xCB63, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 4,E"),
        new Instruction(Opcode: 0xCB64, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 4,H"),
        new Instruction(Opcode: 0xCB65, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 4,L"),
        new Instruction(Opcode: 0xCB66, Size: 2, BaseTime: 4, BranchTime: 4, Info: "BIT 4,(HL)"),
        new Instruction(Opcode: 0xCB67, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 4,A"),
        new Instruction(Opcode: 0xCB68, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 5,B"),
        new Instruction(Opcode: 0xCB69, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 5,C"),
        new Instruction(Opcode: 0xCB6A, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 5,D"),
        new Instruction(Opcode: 0xCB6B, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 5,E"),
        new Instruction(Opcode: 0xCB6C, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 5,H"),
        new Instruction(Opcode: 0xCB6D, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 5,L"),
        new Instruction(Opcode: 0xCB6E, Size: 2, BaseTime: 4, BranchTime: 4, Info: "BIT 5,(HL)"),
        new Instruction(Opcode: 0xCB6F, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 5,A"),
        new Instruction(Opcode: 0xCB70, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 6,B"),
        new Instruction(Opcode: 0xCB71, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 6,C"),
        new Instruction(Opcode: 0xCB72, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 6,D"),
        new Instruction(Opcode: 0xCB73, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 6,E"),
        new Instruction(Opcode: 0xCB74, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 6,H"),
        new Instruction(Opcode: 0xCB75, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 6,L"),
        new Instruction(Opcode: 0xCB76, Size: 2, BaseTime: 4, BranchTime: 4, Info: "BIT 6,(HL)"),
        new Instruction(Opcode: 0xCB77, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 6,A"),
        new Instruction(Opcode: 0xCB78, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 7,B"),
        new Instruction(Opcode: 0xCB79, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 7,C"),
        new Instruction(Opcode: 0xCB7A, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 7,D"),
        new Instruction(Opcode: 0xCB7B, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 7,E"),
        new Instruction(Opcode: 0xCB7C, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 7,H"),
        new Instruction(Opcode: 0xCB7D, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 7,L"),
        new Instruction(Opcode: 0xCB7E, Size: 2, BaseTime: 4, BranchTime: 4, Info: "BIT 7,(HL)"),
        new Instruction(Opcode: 0xCB7F, Size: 2, BaseTime: 2, BranchTime: 2, Info: "BIT 7,A"),
        new Instruction(Opcode: 0xCB80, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 0,B"),
        new Instruction(Opcode: 0xCB81, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 0,C"),
        new Instruction(Opcode: 0xCB82, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 0,D"),
        new Instruction(Opcode: 0xCB83, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 0,E"),
        new Instruction(Opcode: 0xCB84, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 0,H"),
        new Instruction(Opcode: 0xCB85, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 0,L"),
        new Instruction(Opcode: 0xCB86, Size: 2, BaseTime: 4, BranchTime: 4, Info: "RES 0,(HL)"),
        new Instruction(Opcode: 0xCB87, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 0,A"),
        new Instruction(Opcode: 0xCB88, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 1,B"),
        new Instruction(Opcode: 0xCB89, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 1,C"),
        new Instruction(Opcode: 0xCB8A, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 1,D"),
        new Instruction(Opcode: 0xCB8B, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 1,E"),
        new Instruction(Opcode: 0xCB8C, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 1,H"),
        new Instruction(Opcode: 0xCB8D, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 1,L"),
        new Instruction(Opcode: 0xCB8E, Size: 2, BaseTime: 4, BranchTime: 4, Info: "RES 1,(HL)"),
        new Instruction(Opcode: 0xCB8F, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 1,A"),
        new Instruction(Opcode: 0xCB90, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 2,B"),
        new Instruction(Opcode: 0xCB91, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 2,C"),
        new Instruction(Opcode: 0xCB92, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 2,D"),
        new Instruction(Opcode: 0xCB93, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 2,E"),
        new Instruction(Opcode: 0xCB94, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 2,H"),
        new Instruction(Opcode: 0xCB95, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 2,L"),
        new Instruction(Opcode: 0xCB96, Size: 2, BaseTime: 4, BranchTime: 4, Info: "RES 2,(HL)"),
        new Instruction(Opcode: 0xCB97, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 2,A"),
        new Instruction(Opcode: 0xCB98, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 3,B"),
        new Instruction(Opcode: 0xCB99, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 3,C"),
        new Instruction(Opcode: 0xCB9A, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 3,D"),
        new Instruction(Opcode: 0xCB9B, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 3,E"),
        new Instruction(Opcode: 0xCB9C, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 3,H"),
        new Instruction(Opcode: 0xCB9D, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 3,L"),
        new Instruction(Opcode: 0xCB9E, Size: 2, BaseTime: 4, BranchTime: 4, Info: "RES 3,(HL)"),
        new Instruction(Opcode: 0xCB9F, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 3,A"),
        new Instruction(Opcode: 0xCBA0, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 4,B"),
        new Instruction(Opcode: 0xCBA1, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 4,C"),
        new Instruction(Opcode: 0xCBA2, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 4,D"),
        new Instruction(Opcode: 0xCBA3, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 4,E"),
        new Instruction(Opcode: 0xCBA4, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 4,H"),
        new Instruction(Opcode: 0xCBA5, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 4,L"),
        new Instruction(Opcode: 0xCBA6, Size: 2, BaseTime: 4, BranchTime: 4, Info: "RES 4,(HL)"),
        new Instruction(Opcode: 0xCBA7, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 4,A"),
        new Instruction(Opcode: 0xCBA8, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 5,B"),
        new Instruction(Opcode: 0xCBA9, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 5,C"),
        new Instruction(Opcode: 0xCBAA, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 5,D"),
        new Instruction(Opcode: 0xCBAB, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 5,E"),
        new Instruction(Opcode: 0xCBAC, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 5,H"),
        new Instruction(Opcode: 0xCBAD, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 5,L"),
        new Instruction(Opcode: 0xCBAE, Size: 2, BaseTime: 4, BranchTime: 4, Info: "RES 5,(HL)"),
        new Instruction(Opcode: 0xCBAF, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 5,A"),
        new Instruction(Opcode: 0xCBB0, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 6,B"),
        new Instruction(Opcode: 0xCBB1, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 6,C"),
        new Instruction(Opcode: 0xCBB2, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 6,D"),
        new Instruction(Opcode: 0xCBB3, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 6,E"),
        new Instruction(Opcode: 0xCBB4, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 6,H"),
        new Instruction(Opcode: 0xCBB5, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 6,L"),
        new Instruction(Opcode: 0xCBB6, Size: 2, BaseTime: 4, BranchTime: 4, Info: "RES 6,(HL)"),
        new Instruction(Opcode: 0xCBB7, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 6,A"),
        new Instruction(Opcode: 0xCBB8, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 7,B"),
        new Instruction(Opcode: 0xCBB9, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 7,C"),
        new Instruction(Opcode: 0xCBBA, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 7,D"),
        new Instruction(Opcode: 0xCBBB, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 7,E"),
        new Instruction(Opcode: 0xCBBC, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 7,H"),
        new Instruction(Opcode: 0xCBBD, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 7,L"),
        new Instruction(Opcode: 0xCBBE, Size: 2, BaseTime: 4, BranchTime: 4, Info: "RES 7,(HL)"),
        new Instruction(Opcode: 0xCBBF, Size: 2, BaseTime: 2, BranchTime: 2, Info: "RES 7,A"),
        new Instruction(Opcode: 0xCBC0, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 0,B"),
        new Instruction(Opcode: 0xCBC1, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 0,C"),
        new Instruction(Opcode: 0xCBC2, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 0,D"),
        new Instruction(Opcode: 0xCBC3, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 0,E"),
        new Instruction(Opcode: 0xCBC4, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 0,H"),
        new Instruction(Opcode: 0xCBC5, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 0,L"),
        new Instruction(Opcode: 0xCBC6, Size: 2, BaseTime: 4, BranchTime: 4, Info: "SET 0,(HL)"),
        new Instruction(Opcode: 0xCBC7, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 0,A"),
        new Instruction(Opcode: 0xCBC8, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 1,B"),
        new Instruction(Opcode: 0xCBC9, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 1,C"),
        new Instruction(Opcode: 0xCBCA, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 1,D"),
        new Instruction(Opcode: 0xCBCB, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 1,E"),
        new Instruction(Opcode: 0xCBCC, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 1,H"),
        new Instruction(Opcode: 0xCBCD, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 1,L"),
        new Instruction(Opcode: 0xCBCE, Size: 2, BaseTime: 4, BranchTime: 4, Info: "SET 1,(HL)"),
        new Instruction(Opcode: 0xCBCF, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 1,A"),
        new Instruction(Opcode: 0xCBD0, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 2,B"),
        new Instruction(Opcode: 0xCBD1, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 2,C"),
        new Instruction(Opcode: 0xCBD2, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 2,D"),
        new Instruction(Opcode: 0xCBD3, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 2,E"),
        new Instruction(Opcode: 0xCBD4, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 2,H"),
        new Instruction(Opcode: 0xCBD5, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 2,L"),
        new Instruction(Opcode: 0xCBD6, Size: 2, BaseTime: 4, BranchTime: 4, Info: "SET 2,(HL)"),
        new Instruction(Opcode: 0xCBD7, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 2,A"),
        new Instruction(Opcode: 0xCBD8, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 3,B"),
        new Instruction(Opcode: 0xCBD9, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 3,C"),
        new Instruction(Opcode: 0xCBDA, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 3,D"),
        new Instruction(Opcode: 0xCBDB, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 3,E"),
        new Instruction(Opcode: 0xCBDC, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 3,H"),
        new Instruction(Opcode: 0xCBDD, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 3,L"),
        new Instruction(Opcode: 0xCBDE, Size: 2, BaseTime: 4, BranchTime: 4, Info: "SET 3,(HL)"),
        new Instruction(Opcode: 0xCBDF, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 3,A"),
        new Instruction(Opcode: 0xCBE0, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 4,B"),
        new Instruction(Opcode: 0xCBE1, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 4,C"),
        new Instruction(Opcode: 0xCBE2, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 4,D"),
        new Instruction(Opcode: 0xCBE3, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 4,E"),
        new Instruction(Opcode: 0xCBE4, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 4,H"),
        new Instruction(Opcode: 0xCBE5, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 4,L"),
        new Instruction(Opcode: 0xCBE6, Size: 2, BaseTime: 4, BranchTime: 4, Info: "SET 4,(HL)"),
        new Instruction(Opcode: 0xCBE7, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 4,A"),
        new Instruction(Opcode: 0xCBE8, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 5,B"),
        new Instruction(Opcode: 0xCBE9, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 5,C"),
        new Instruction(Opcode: 0xCBEA, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 5,D"),
        new Instruction(Opcode: 0xCBEB, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 5,E"),
        new Instruction(Opcode: 0xCBEC, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 5,H"),
        new Instruction(Opcode: 0xCBED, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 5,L"),
        new Instruction(Opcode: 0xCBEE, Size: 2, BaseTime: 4, BranchTime: 4, Info: "SET 5,(HL)"),
        new Instruction(Opcode: 0xCBEF, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 5,A"),
        new Instruction(Opcode: 0xCBF0, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 6,B"),
        new Instruction(Opcode: 0xCBF1, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 6,C"),
        new Instruction(Opcode: 0xCBF2, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 6,D"),
        new Instruction(Opcode: 0xCBF3, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 6,E"),
        new Instruction(Opcode: 0xCBF4, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 6,H"),
        new Instruction(Opcode: 0xCBF5, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 6,L"),
        new Instruction(Opcode: 0xCBF6, Size: 2, BaseTime: 4, BranchTime: 4, Info: "SET 6,(HL)"),
        new Instruction(Opcode: 0xCBF7, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 6,A"),
        new Instruction(Opcode: 0xCBF8, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 7,B"),
        new Instruction(Opcode: 0xCBF9, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 7,C"),
        new Instruction(Opcode: 0xCBFA, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 7,D"),
        new Instruction(Opcode: 0xCBFB, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 7,E"),
        new Instruction(Opcode: 0xCBFC, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 7,H"),
        new Instruction(Opcode: 0xCBFD, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 7,L"),
        new Instruction(Opcode: 0xCBFE, Size: 2, BaseTime: 4, BranchTime: 4, Info: "SET 7,(HL)"),
        new Instruction(Opcode: 0xCBFF, Size: 2, BaseTime: 2, BranchTime: 2, Info: "SET 7,A"),
    };
    #endregion

    #region JumpFuncs

    public static Status JumpHL(CPU cpu, IBus _)
    {
        cpu.PC = cpu.HL;
        return Status.Jump;
    }

    public static Status JumpAbsIf(CPU cpu, bool doJump)
    {
        ushort dist = cpu.Fetch16();

        if (doJump)
        {
            cpu.PC = dist;
            return Status.Jump;
        }

        return Status.Continue;
    }

    public static Status JumpRelIf(CPU cpu, bool doJump)
    {
        sbyte dist = (sbyte)cpu.Fetch8();

        if (doJump)
        {
            cpu.PC += (ushort)dist;
            return Status.Jump;
        }

        return Status.Continue;
    }

    public static Status ReturnInterrupt(CPU cpu, IBus bus)
    {
        cpu.PC = cpu.Pop();
        bus.Write(0xFFFF, 0);
        return Status.Jump;
    }

    public static Status RetIf(CPU cpu, bool doJump)
    {
        if (doJump)
        {
            cpu.PC = cpu.Pop();
            return Status.Jump;
        }

        return Status.Continue;
    }

    public static Status CallIf(CPU cpu, bool doJump)
    {
        ushort address = cpu.Fetch16();
        if (doJump)
        {
            cpu.Push(cpu.PC);
            cpu.PC = address;
            return Status.Jump;
        }

        return Status.Continue;
    }

    public static Status Reset(CPU cpu, ushort resetVal)
    {
        cpu.Push(cpu.PC);
        cpu.PC = resetVal;
        return Status.Jump;
    }
    #endregion

    #region StackFuncs
    public static Status PushRegister(CPU cpu, REG16 register)
    {
        cpu.Push(cpu.ReadRegister16(register));
        return Status.Continue;
    }

    public static Status PopRegister(CPU cpu, REG16 register)
    {
        cpu.WriteRegister16(register, cpu.Pop());
        return Status.Continue;
    }

    public static Status StoreSPIndirect(CPU cpu, IBus bus)
    {
        ushort address = cpu.Fetch16();
        bus.Write(address, (byte)(cpu.SP & 0xFF));
        bus.Write((ushort)(address + 1), (byte)(cpu.SP >> 8));
        return Status.Continue;
    }

    public static Status MoveSPHL(CPU cpu)
    {
        cpu.SP = cpu.HL;
        return Status.Continue;
    }

    public static Status MoveRegisterSPOffset(REG16 dest, CPU cpu)
    {
        ushort prevDest = cpu.SP;
        sbyte offset = (sbyte)cpu.Fetch8();
        ushort result = (ushort)(prevDest + offset);

        cpu.FlagZ = false;
        cpu.FlagN = false;
        cpu.FlagH = (((result ^ prevDest ^ offset) >> 4) & 1) is 1;
        cpu.FlagC = (((result ^ prevDest ^ offset) >> 8) & 1) is 1;

        cpu.WriteRegister16(dest, result);
        return Status.Continue;
    }
    #endregion

    #region Interrupt
    public static Status SetInterruptFlag(IBus bus, bool isEnabled)
    {
        bus.Write(0xFFFF, (byte)(isEnabled ? 0 : 1));
        return Status.Continue;
    }
    #endregion

    #region Load
    public static Status MovRegister(REG8 dest, REG8 src, CPU cpu)
    {
        cpu.WriteRegister8(dest, cpu.ReadRegister8(src));
        return Status.Continue;
    }

    public static Status MovRegister16(REG16 dest, REG16 src, CPU cpu)
    {
        cpu.WriteRegister16(dest, cpu.ReadRegister16(src));
        return Status.Continue;
    }

    public static Status LoadRegisterImmediate16(REG16 dest, CPU cpu)
    {
        cpu.WriteRegister16(dest, cpu.Fetch16());
        return Status.Continue;
    }
    
    public static Status LoadRegisterA(REG16 dest, CPU cpu, IBus bus)
    {
        bus.Write(cpu.ReadRegister16(dest), cpu.A);
        return Status.Continue;
    }

    public static Status StoreRegisterA(REG16 src, CPU cpu, IBus bus)
    {
        cpu.A =  bus.Read(cpu.ReadRegister16(src));
        return Status.Continue;
    }

    public static Status LoadAIncHL(CPU cpu, IBus bus)
    {
        cpu.A = bus.Read(cpu.HL);
        cpu.HL += 1;
        return Status.Continue;
    }

    public static Status LoadADecHL(CPU cpu, IBus bus)
    {
        cpu.A = bus.Read(cpu.HL);
        cpu.HL -= 1;
        return Status.Continue;
    }

    public static Status StoreAIncHL(CPU cpu, IBus bus)
    {
        bus.Write(cpu.HL, cpu.A);
        cpu.HL += 1;
        return Status.Continue;
    }

    public static Status StoreADecHL(CPU cpu, IBus bus)
    {
        bus.Write(cpu.HL, cpu.A);
        cpu.HL -= 1;
        return Status.Continue;
    }

    public static Status LoadImmediate(REG8 dest, CPU cpu)
    {
        cpu.WriteRegister8(dest, cpu.Fetch8());
        return Status.Continue;
    }

    public static Status LoadAIndirect(CPU cpu, IBus bus)
    {
        cpu.A = bus.Read(cpu.Fetch16());
        return Status.Continue;
    }

    public static Status StoreAIndirect(CPU cpu, IBus bus)
    {
        bus.Write(cpu.Fetch16(), cpu.A);
        return Status.Continue;
    }

    public static Status LoadFFPageImmediateA(CPU cpu, IBus bus)
    {
        cpu.A = bus.Read((ushort)(0xFF00 | cpu.Fetch8()));
        return Status.Continue;
    }

    public static Status StoreFFPageImmediateA(CPU cpu, IBus bus)
    {
        bus.Write((ushort)(0xFF00 | cpu.Fetch8()), cpu.A);
        return Status.Continue;
    }

    public static Status LoadFFPageIndirectC(CPU cpu, IBus bus)
    {
        cpu.A = bus.Read((ushort)(0xFF00 | cpu.C));
        return Status.Continue;
    }

    public static Status StoreFFPageIndirectC(CPU cpu, IBus bus)
    {
        bus.Write((ushort)(0xFF00 | cpu.C), cpu.A);
        return Status.Continue;
    }
    #endregion

    #region Math
    public static Status Inc8(REG8 dest, CPU cpu)
    {
        byte previous = cpu.ReadRegister8(dest);
        int result = previous + 1;

        cpu.FlagZ = (result & 0xFF) is 0;
        cpu.FlagN = false;
        cpu.FlagH = (result & 0x0F) is 0;

        cpu.WriteRegister8(dest, (byte)result);

        return Status.Continue;
    }

    public static Status Inc16(REG16 dest, CPU cpu)
    {
        ushort previous = cpu.ReadRegister16(dest);
        int result = previous + 1;
        cpu.WriteRegister16(dest, (ushort)result);
        return Status.Continue;
    }

    public static Status Dec8(REG8 dest, CPU cpu)
    {
        byte previous = cpu.ReadRegister8(dest);
        int result = previous - 1;

        cpu.FlagZ = (result & 0xFF) is 0;
        cpu.FlagN = true;
        cpu.FlagH = (previous & 0x0F) is 0;

        cpu.WriteRegister8(dest, (byte)result);

        return Status.Continue;
    }

    public static Status Dec16(REG16 dest, CPU cpu)
    {
        ushort previous = cpu.ReadRegister16(dest);
        int result = previous - 1;
        cpu.WriteRegister16(dest, (ushort)result);
        return Status.Continue;
    }

    public static Status AddReg8(REG8 src, CPU cpu)
    {
        ushort prevDest = cpu.A;
        ushort prevSrc = cpu.ReadRegister8(src);

        int result = prevDest + prevSrc;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = false;
        cpu.FlagH = (((result ^ prevDest ^ prevSrc) >> 4) & 1) is 1;
        cpu.FlagC = (result >> 8) is not 0;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status AddImmediate(CPU cpu)
    {
        ushort prevDest = cpu.A;
        ushort prevSrc = cpu.Fetch8();

        int result = prevDest + prevSrc;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = false;
        cpu.FlagH = (((result ^ prevDest ^ prevSrc) >> 4) & 1) is 1;
        cpu.FlagC = (result >> 8) is not 0;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status AddCarryReg8(REG8 src, CPU cpu)
    {
        ushort prevDest = cpu.A;
        ushort prevSrc = cpu.ReadRegister8(src);

        int carry = (cpu.FlagC ? 1 : 0);
        int result = prevDest + prevSrc + carry;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = false;
        cpu.FlagH = (((result ^ prevDest ^ prevSrc) >> 4) & 1) is 1;
        cpu.FlagC = (result >> 8) is not 0;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status AddCarryImmediate(CPU cpu)
    {
        ushort prevDest = cpu.A;
        ushort prevSrc = cpu.Fetch8();

        int carry = (cpu.FlagC ? 1 : 0);
        int result = prevDest + prevSrc + carry;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = false;
        cpu.FlagH = (((result ^ prevDest ^ prevSrc) >> 4) & 1) is 1;
        cpu.FlagC = (result >> 8) is not 0;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status AddReg16(REG16 dest, REG16 src, CPU cpu)
    {
        ushort prevDest = cpu.ReadRegister16(dest);
        ushort prevSrc = cpu.ReadRegister16(src);

        int result = prevDest + prevSrc;

        cpu.FlagN = false;
        cpu.FlagH = (((result ^ prevDest ^ prevSrc) >> 12) & 1) is 1;
        cpu.FlagC = (result >> 16) is not 0;

        cpu.WriteRegister16(dest, (ushort)result);
        return Status.Continue;
    }

    public static Status SubReg8(REG8 src, CPU cpu)
    {
        byte prevDest = cpu.A;
        byte prevSrc = cpu.ReadRegister8(src);

        int result = prevDest - prevSrc;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = true;
        cpu.FlagH = (((result ^ prevDest ^ prevSrc) >> 4) & 1) is 1;
        cpu.FlagC = (result >> 8) is not 0;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status SubImmediate(CPU cpu)
    {
        byte prevDest = cpu.A;
        byte prevSrc = cpu.Fetch8();

        int result = prevDest - prevSrc;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = true;
        cpu.FlagH = (((result ^ prevDest ^ prevSrc) >> 4) & 1) is 1;
        cpu.FlagC = (result >> 8) is not 0;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status SubCarryReg8(REG8 src, CPU cpu)
    {
        byte prevDest = cpu.A;
        byte prevSrc = cpu.ReadRegister8(src);

        int carry = (cpu.FlagC ? 1 : 0);
        int result = prevDest - prevSrc - carry;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = true;
        cpu.FlagH = (((result ^ prevDest ^ prevSrc) >> 4) & 1) is 1;
        cpu.FlagC = (result >> 8) is not 0;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status SubCarryImmediate(CPU cpu)
    {
        byte prevDest = cpu.A;
        byte prevSrc = cpu.Fetch8();

        int carry = (cpu.FlagC ? 1 : 0);
        int result = prevDest - prevSrc - carry;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = false;
        cpu.FlagH = (((result ^ prevDest ^ prevSrc) >> 4) & 1) is 1;
        cpu.FlagC = (result >> 8) is not 0;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status ANDReg8(REG8 src, CPU cpu)
    {
        byte prevDest = cpu.A;
        byte prevSrc = cpu.ReadRegister8(src);

        int result = prevDest & prevSrc;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = false;
        cpu.FlagH = true;
        cpu.FlagC = false;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status ANDImmediate(CPU cpu)
    {
        byte prevDest = cpu.A;
        byte prevSrc = cpu.Fetch8();

        int result = prevDest & prevSrc;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = false;
        cpu.FlagH = true;
        cpu.FlagC = false;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status ORReg8(REG8 src, CPU cpu)
    {
        byte prevDest = cpu.A;
        byte prevSrc = cpu.ReadRegister8(src);

        int result = prevDest | prevSrc;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = false;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status ORImmediate(CPU cpu)
    {
        byte prevDest = cpu.A;
        byte prevSrc = cpu.Fetch8();

        int result = prevDest | prevSrc;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = false;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status XORReg8(REG8 src, CPU cpu)
    {
        byte prevDest = cpu.A;
        byte prevSrc = cpu.ReadRegister8(src);

        int result = prevDest ^ prevSrc;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = false;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status XORImmediate(CPU cpu)
    {
        byte prevDest = cpu.A;
        byte prevSrc = cpu.Fetch8();

        int result = prevDest ^ prevSrc;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = false;

        cpu.A = (byte)result;
        return Status.Continue;
    }

    public static Status CompareReg8(REG8 src, CPU cpu)
    {
        byte prevDest = cpu.A;
        byte prevSrc = cpu.ReadRegister8(src);

        int result = prevDest - prevSrc;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = true;
        cpu.FlagH = (((result ^ prevDest ^ prevSrc) >> 4) & 1) is 1;
        cpu.FlagC = (result >> 8) is not 0;

        return Status.Continue;
    }

    public static Status CompareImmediate(CPU cpu)
    {
        byte prevDest = cpu.A;
        byte prevSrc = cpu.Fetch8();

        int result = prevDest - prevSrc;

        cpu.FlagZ = (byte)result is 0;
        cpu.FlagN = true;
        cpu.FlagH = (((result ^ prevDest ^ prevSrc) >> 4) & 1) is 1;
        cpu.FlagC = (result >> 8) is not 0;

        return Status.Continue;
    }
    #endregion

    #region Miscellaneous
    public static Status ComplimentCarryFlag(CPU cpu)
    {
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = !cpu.FlagC;
        return Status.Continue;
    }

    public static Status SetCarryFlag(CPU cpu)
    {
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = true;
        return Status.Continue;
    }

    public static Status ComplimentRegisterA(CPU cpu)
    {
        cpu.FlagN = true;
        cpu.FlagH = true;
        cpu.A ^= 0xFF;
        return Status.Continue;
    }

    // TODO: Implement
    public static Status DecimalAdjustRegisterA(CPU cpu)
    {
        cpu.FlagH = false;
        return Status.Continue;
    }
    
    public static Status RotateLeftA(CPU cpu)
    {
        CBRotateLeft(REG8.A, cpu);
        cpu.FlagZ = false;
        return Status.Continue;
    }

    public static Status RotateLeftCarryA(CPU cpu)
    {
        CBRotateLeftCarry(REG8.A, cpu);
        cpu.FlagZ = false;
        return Status.Continue;
    }

    public static Status RotateRightA(CPU cpu)
    {
        CBRotateRight(REG8.A, cpu);
        cpu.FlagZ = false;
        return Status.Continue;
    }

    public static Status RotateRightCarryA(CPU cpu)
    {
        CBRotateRightCarry(REG8.A, cpu);
        cpu.FlagZ = false;
        return Status.Continue;
    }
    #endregion

    #region CB
    public static Status CBRotateLeft(REG8 register, CPU cpu)
    {
        byte prev = cpu.ReadRegister8(register);

        byte result = cpu.WriteRegister8(register, (byte)((prev << 1) | (cpu.FlagC ? 1 : 0)));

        cpu.FlagZ = result is 0;
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = (prev >> 7) is 1;

        return Status.Continue;
    }

    public static Status CBRotateLeftCarry(REG8 register, CPU cpu)
    {
        byte prev = cpu.ReadRegister8(register);

        byte result = cpu.WriteRegister8(register, (byte)((prev << 1) | (prev >> 7)));

        cpu.FlagZ = result is 0;
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = (prev >> 7) is 1;
    
        return Status.Continue;
    }

    public static Status CBRotateRight(REG8 register, CPU cpu)
    {
        byte prev = cpu.ReadRegister8(register);

        byte result = cpu.WriteRegister8(register, (byte)((prev >> 1) | (cpu.FlagC ? 0x80 : 0)));

        cpu.FlagZ = result is 0;
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = (prev & 0x1) is 1;

        return Status.Continue;
    }

    public static Status CBRotateRightCarry(REG8 register, CPU cpu)
    {
        byte prev = cpu.ReadRegister8(register);

        byte result = cpu.WriteRegister8(register, (byte)((prev >> 1) | (prev << 7)));

        cpu.FlagZ = result is 0;
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = (prev & 0x1) is 1;
        return Status.Continue;
    }

    public static Status CBShiftLeftArithmetic(REG8 register, CPU cpu)
    {
        byte prev = cpu.ReadRegister8(register);
        byte result = (byte)(prev << 1);

        cpu.FlagZ = result is 0;
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = (prev >> 7) is 1;

        cpu.WriteRegister8(register, result);

        return Status.Continue;
    }

    public static Status CBShiftRightArithmetic(REG8 register, CPU cpu)
    {
        sbyte prev = (sbyte)cpu.ReadRegister8(register);
        byte result = (byte)(prev >> 1);

        cpu.FlagZ = result is 0;
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = (prev & 0x1) is 1;

        cpu.WriteRegister8(register, result);

        return Status.Continue;
    }

    public static Status CBShiftRightLogical(REG8 register, CPU cpu)
    {
        byte prev = cpu.ReadRegister8(register);
        byte result = (byte)(prev >> 1);

        cpu.FlagZ = result is 0;
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = (prev & 0x1) is 1;

        cpu.WriteRegister8(register, result);

        return Status.Continue;
    }

    public static Status CBSwap(REG8 register, CPU cpu)
    {
        byte value = cpu.ReadRegister8(register);
        byte lower = (byte)(value >> 4);
        byte upper = (byte)((value & 0x0F) << 4);
        byte result = cpu.WriteRegister8(register, (byte)(upper | lower));

        cpu.FlagZ = result is 0;
        cpu.FlagN = false;
        cpu.FlagH = false;
        cpu.FlagC = false;

        return Status.Continue;
    }

    public static Status CBBit(REG8 register, int offset, CPU cpu)
    {
        byte value = cpu.ReadRegister8(register);
        byte tBit = (byte)(value & (1 << offset));

        cpu.FlagZ = tBit is 0;
        cpu.FlagN = false;
        cpu.FlagH = true;

        return Status.Continue;
    }

    public static Status CBReset(REG8 register, int offset, CPU cpu)
    {
        byte value = cpu.ReadRegister8(register);
        value &= (byte)~(1 << offset);
        cpu.WriteRegister8(register, value);
        return Status.Continue;
    }

    public static Status CBSet(REG8 register, int offset, CPU cpu)
    {
        byte value = cpu.ReadRegister8(register);
        value |= (byte)(1 << offset);
        cpu.WriteRegister8(register, value);
        return Status.Continue;
    }
    #endregion
}

using NullGB.Extensions;

namespace NullGB.Core.CPU;

public enum REG8 : byte { B, C, D, E, H, L, HL, A };
public enum REG16 : byte { BC, DE, HL, SP, AF };

public enum Status { Continue, Halt, Stop, InvalidInstr, Jump };

internal partial class CPU
{
    public readonly IBus MemoryBus;

    #region CPU Registers
    public byte A;
    public byte B;
    public byte C;
    public byte D;
    public byte E;
    public byte H;
    public byte L;

    public byte F
    {
        get => (byte)((FlagZ.AsByte() << 7) | (FlagN.AsByte() << 6) | (FlagH.AsByte() << 5) | (FlagC.AsByte() << 4));
        set
        {
            FlagZ = (value & 0b1000_0000).AsBool();
            FlagN = (value & 0b0100_0000).AsBool();
            FlagH = (value & 0b0010_0000).AsBool();
            FlagC = (value & 0b0001_0000).AsBool();
        }
    }

    // Stack Pointer
    public ushort SP = 0xFFFE;

    // Program Counter
    public ushort PC = 0x100;

    public ushort AF
    {
        get => (ushort)((A << 8) + F);
        set
        {
            F = (byte)(value & 0xFF);
            A = (byte)((value >> 8) & 0xFF);
        }
    }

    public ushort BC
    {
        get => (ushort)((B << 8) + C);
        set
        {
            C = (byte)(value & 0xFF);
            B = (byte)((value >> 8) & 0xFF);
        }
    }

    public ushort DE
    {
        get => (ushort)((D << 8) + E);
        set
        {
            E = (byte)(value & 0xFF);
            D = (byte)((value >> 8) & 0xFF);
        }
    }

    public ushort HL
    {
        get => (ushort)((H << 8) + L);
        set
        {
            L = (byte)(value & 0xFF);
            H = (byte)((value >> 8) & 0xFF);
        }
    }
    #endregion

    #region Flag Registers
    // Lower 4 flags of flag register are all set to 0

    /// <summary>
    /// This bit is set when the result of a math operation is zero or two values match when using the CP instruction.
    /// </summary>
    public bool FlagZ;

    /// <summary>
    /// This bit is set if a subtraction was performed in the last math instruction.
    /// </summary>
    public bool FlagN;

    /// <summary>
    /// This bit is set if a carry occurred from the lower nibble in the last math operation.
    /// </summary>
    public bool FlagH;

    /// <summary>
    /// This bit is set if a carry occurred from the last math operation or if register A is the smaller value when executing the CP instruction.
    /// </summary>
    public bool FlagC;
    #endregion

    #region Register Index Getters/Setters
    public byte ReadRegister8(REG8 index) => index switch
    {
        REG8.B => B,
        REG8.C => C,
        REG8.D => D,
        REG8.E => E,
        REG8.H => H,
        REG8.L => L,
        REG8.HL => MemoryBus.Read(HL),
        REG8.A => A,
        _ => throw new InvalidDataException($"Register '{index}' unknown")
    };

    public byte WriteRegister8(REG8 index, byte value) => index switch
    {
        REG8.B => B = value,
        REG8.C => C = value,
        REG8.D => D = value,
        REG8.E => E = value,
        REG8.H => H = value,
        REG8.L => L = value,
        REG8.HL => MemoryBus.Write(HL, value),
        REG8.A => A = value,
        _ => throw new InvalidDataException($"Register '{index}' unknown")
    };

    public ushort ReadRegister16(REG16 index) => index switch
    {
        REG16.BC => BC,
        REG16.DE => DE,
        REG16.HL => HL,
        REG16.SP => SP,
        REG16.AF => AF,
        _ => throw new InvalidDataException($"Register '{index}' unknown")
    };

    public ushort WriteRegister16(REG16 index, ushort value) => index switch
    {
        REG16.BC => BC = value,
        REG16.DE => DE = value,
        REG16.HL => HL = value,
        REG16.SP => SP = value,
        REG16.AF => AF = value,
        _ => throw new InvalidDataException($"Register '{index}' unknown")
    };
    #endregion

    public CPU(IBus bus)
    {
        MemoryBus = bus;
    }

    public void Start()
    {
        Restart();
        // TODO: Move main loop out of CPU
        while (true)
        {
            Step();
        }
    }

    /// <summary>
    /// Restarts the CPU State
    /// </summary>
    public void Restart()
    {
        A = 0;
        B = 0;
        C = 0;
        D = 0;
        E = 0;
        H = 0;
        L = 0;

        FlagZ = false;
        FlagN = false;
        FlagH = false;
        FlagC = false;

        SP = 0xFFFE;
        PC = 0x100;
    }

    public void Push(ushort val)
    {
        MemoryBus.Write(SP, (byte)(val >> 8));
        SP -= 1;
        MemoryBus.Write(SP, (byte)(val & 0xFF));
        SP -= 1;
    }

    public ushort Pop()
    {
        byte lower = MemoryBus.Read(SP);
        SP += 1;
        byte higher = MemoryBus.Read(SP);
        SP += 1;

        return (ushort)((higher << 8) | lower);
    }

    public byte Fetch8()
    {
        byte val = MemoryBus.Read(PC);
        PC += 1;
        return val;
    }

    public ushort Fetch16()
    {
        byte lower = Fetch8();
        byte higher = Fetch8();
        return (ushort)((higher << 8) | lower);
    }
}

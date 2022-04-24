﻿using NullGB.Core;
using NullGB.Core.CPU;

namespace NullGB;

public class Program
{
    public static void Main(params string[] args)
    {
        RunSpecialTest();
    }

    public static void RunSpecialTest()
    {
        byte[] SpecialTestROM = File.ReadAllBytes(@"..\..\..\..\TestRoms\cpu_instrs\individual\04-op r,imm.gb");
        MMU mmu = new(SpecialTestROM);
        CPU cpu = new(mmu);
        cpu.Start();
    }
}

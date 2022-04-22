using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullGB.Core
{
    public enum REG8 : byte { B, C, D, E, H, L, HL, A };
    public enum REG16 : byte { BC, DE, HL };

    internal class CPU
    {
        #region CPU Registers
        public byte A;
        public byte B;
        public byte C;
        public byte D;
        public byte E;
        public byte H;
        public byte L;
        #endregion

        #region Flag Registers
        // Upper 4 flags of flag register are 0

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

        // Stack Pointer
        public ushort SP = 0xFFFE;

        // Program Counter
        public ushort PC = 0x100;

        //public short AF
        //{
        //    get => (short)((A << 8) + F);
        //    set
        //    {
        //        F = (byte)(value & 0xFF);
        //        A = (byte)((value >> 8) & 0xFF);
        //    }
        //}

        public short BC
        {
            get => (short)((B << 8) + C);
            set
            {
                C = (byte)(value & 0xFF);
                B = (byte)((value >> 8) & 0xFF);
            }
        }

        public short DE
        {
            get => (short)((D << 8) + E);
            set
            {
                E = (byte)(value & 0xFF);
                D = (byte)((value >> 8) & 0xFF);
            }
        }

        public short HL
        {
            get => (short)((H << 8) + L);
            set
            {
                L = (byte)(value & 0xFF);
                H = (byte)((value >> 8) & 0xFF);
            }
        }

        /// <summary>
        /// Resets the CPU State
        /// </summary> 
        public void Reset()
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
    }
}

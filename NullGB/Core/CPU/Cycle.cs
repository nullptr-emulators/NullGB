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
            return Status.Continue;
        }
    }
}

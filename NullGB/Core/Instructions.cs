namespace NullGB.Core
{
    internal partial class CPU
    {
        public string JumpImmediate()
        {
            PC = (ushort)((_memoryBus.Read(PC++) << 8) | _memoryBus.Read(PC++));
            return "Yump";
        }
    }
}

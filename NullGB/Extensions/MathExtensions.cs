namespace NullGB.Extensions;

internal static class MathExtensions
{
    public static byte AsByte(this bool a) => a ? (byte)1 : (byte)0;

    public static bool AsBool(this byte a) => a != 0;
    public static bool AsBool(this short a) => a != 0;
    public static bool AsBool(this int a) => a != 0;
    public static bool AsBool(this long a) => a != 0;
}

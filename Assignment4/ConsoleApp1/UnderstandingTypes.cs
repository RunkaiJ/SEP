

string[] types = { "sbyte", "byte", "short", "ushort", "int", "uint", "long", "ulong", "float", "double", "decimal" };
byte[] bytes = { 
    sizeof(sbyte), sizeof(byte), sizeof(short), sizeof(ushort), sizeof(int), sizeof(uint), sizeof(long), sizeof(ulong), sizeof(float),
    sizeof(double), sizeof(decimal)
};
string[] ranges = {
    $"{sbyte.MinValue} to {sbyte.MaxValue}", $"{byte.MinValue} to {byte.MaxValue}", $"{short.MinValue} to {short.MaxValue}",
    $"{ushort.MinValue} to {ushort.MaxValue}", $"{int.MinValue} to {int.MaxValue}", $"{uint.MinValue} to {uint.MaxValue}",
    $"{long.MinValue} to {long.MaxValue}", $"{ulong.MinValue} to {ulong.MaxValue}", $"{float.MinValue} to {float.MaxValue}",
    $"{double.MinValue} to {double.MaxValue}", $"{decimal.MinValue} to {decimal.MaxValue}"
};
Console.WriteLine("{0,-20} {1,-5} {2,-30}", "Type", "Byte", "Range");

for (int i = 0; i < types.Length; i++)
{
    Console.WriteLine("{0,-20} {1,-5} {2,-30}", types[i], bytes[i], ranges[i]);
}
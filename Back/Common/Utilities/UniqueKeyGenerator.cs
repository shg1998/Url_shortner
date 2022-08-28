using System;
using System.Linq;

namespace Common.Utilities
{
    public static class UniqueKeyGenerator
    {
        private const int Length = 9;

        public static string GenerateAddress()
        {
            var random = string.Empty;

            Enumerable.Range(48, 75).Where(n => n is < 50 or > 64 and < 91 or > 96)
                .OrderBy(o => new Random().Next())
                .ToList()
                .ForEach(i => random += Convert.ToChar(i));

            return random.Substring(new Random().Next(0, random.Length - Length), Length);
        }
    }
}

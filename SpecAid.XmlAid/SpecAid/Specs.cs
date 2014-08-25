// ReSharper disable CheckNamespace

using System.Diagnostics.CodeAnalysis;

namespace SpecAid
// ReSharper restore CheckNamespace
{
    [ExcludeFromCodeCoverage]
    public static class Specs
    {
        public static SpecAidHelper Helpers
        {
            get
            {
                return new SpecAidHelper();
            }
        }
    }
}

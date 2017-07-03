using System.Linq;

namespace Elements3D
{
    public static class FNV_1a
    {//FNV hash principle: http://www.isthe.com/chongo/tech/comp/fnv/
        public static readonly int OffsetBasis = unchecked((int)2166136261);
        public static readonly int Prime = 16777619;

        public static int CreateHash(params object[] objs)//creates heap memory for gethashcode?
        {
            return unchecked(objs.Aggregate(OffsetBasis, (r, obj) => (r ^ obj.GetHashCode()) * Prime));
        }
    }
}
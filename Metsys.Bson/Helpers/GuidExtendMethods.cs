using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metsys.Bson
{
    public static class GuidExtendMethods
    {
        /// <summary>
        /// Reverse sequence between java style to .net style.
        /// </summary>
        /// <param name="rawGuid">The guid to be reversed.</param>
        /// <returns>Reversed guid.</returns>
        public static Guid ReveseSequence(this Guid rawGuid)
        {
            var bytes = rawGuid.ToByteArray();
            var bytesInt = bytes.Take(4).Reverse().ToArray();
            var bytesShort1 = bytes.Skip(4).Take(2).Reverse().ToArray();
            var bytesShort2 = bytes.Skip(6).Take(2).Reverse().ToArray();
            var bytesRemain = bytes.Skip(8).ToArray();
            return new Guid(BitConverter.ToInt32(bytesInt, 0), BitConverter.ToInt16(bytesShort1, 0),
                 BitConverter.ToInt16(bytesShort2, 0), bytesRemain);
        }
    }
}

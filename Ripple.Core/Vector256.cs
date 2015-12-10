using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Ripple.Core
{
    public class Vector256 : List<Hash256>, ISerializedType
    {
        private Vector256(IEnumerable<Hash256> enumerable) : base (enumerable) {}
        public void ToBytes(IBytesSink sink)
        {
            foreach (var hash in this)
            {
                hash.ToBytes(sink);
            }
        }
        public static ISerializedType FromJson(JToken token)
        {
            return new Vector256(token.Select(Hash256.FromJson));
        }
    }
}
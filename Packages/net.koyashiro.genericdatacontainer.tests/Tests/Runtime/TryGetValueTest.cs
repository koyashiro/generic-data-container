using UnityEngine;
using UdonSharp;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class TryGetValueTest : UdonSharpBehaviour
    {
        public void Start()
        {
            var list = DataList<int>.New(new int[] { 100, 200, 300, 400 });

            int output;
            Assert.True(list.TryGetValue(0, out output));
            Assert.Equal(100, output);

            Assert.True(list.TryGetValue(1, out output));
            Assert.Equal(200, output);

            Assert.True(list.TryGetValue(2, out output));
            Assert.Equal(300, output);

            Assert.True(list.TryGetValue(3, out output));
            Assert.Equal(400, output);

            Assert.False(list.TryGetValue(4, out output));
            Assert.Equal(default(int), output);
        }
    }
}

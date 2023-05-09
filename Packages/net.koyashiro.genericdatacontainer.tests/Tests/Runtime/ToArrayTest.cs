using UnityEngine;
using UdonSharp;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class ToArrayTest : UdonSharpBehaviour
    {
        public void Start()
        {
            var list = DataList<int>.New(new int[] { 0, 1, 2, 3 });
            Assert.Equal(new int[] { 0, 1, 2, 3 }, list.ToArray(), this);
        }
    }
}

using UnityEngine;
using UdonSharp;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class DataListToArrayTest : UdonSharpBehaviour
    {
        public TestUserDefinedClass testUserDefinedClass;

        public void Start()
        {
            var list = DataList<int>.New(new int[] { 0, 1, 2, 3 });
            Assert.Equal(new int[] { 0, 1, 2, 3 }, list.ToArray(), this);

            var list2 = DataList<TestUserDefinedClass>.New();
            Assert.Equal(new TestUserDefinedClass[] { }, list2.ToArray(), this);

            var list3 = DataList<TestUserDefinedClass>.New(new TestUserDefinedClass[] { testUserDefinedClass });
            Assert.Equal(new TestUserDefinedClass[] { testUserDefinedClass }, list3.ToArray(), this);
        }
    }
}

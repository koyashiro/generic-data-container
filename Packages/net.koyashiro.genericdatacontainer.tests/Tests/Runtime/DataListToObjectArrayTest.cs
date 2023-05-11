using UnityEngine;
using UdonSharp;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class DataListToObjectArrayTest : UdonSharpBehaviour
    {
        public TestUserDefinedClass testUserDefinedClass;

        public void Start()
        {
            var list = DataList<int>.New(new int[] { 0, 1, 2, 3 });
            Assert.Equal(new object[] { 0, 1, 2, 3 }, list.ToObjectArray(), this);

            var list2 = DataList<TestUserDefinedClass>.New();
            Assert.Equal(new object[] { }, list2.ToObjectArray(), this);

            var list3 = DataList<TestUserDefinedClass>.New(new TestUserDefinedClass[] { testUserDefinedClass });
            Assert.Equal(new object[] { testUserDefinedClass }, list3.ToObjectArray(), this);
        }
    }
}

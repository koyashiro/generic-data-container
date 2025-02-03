using UnityEngine;
using UdonSharp;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class DataListToObjectArrayTest : UdonSharpBehaviour
    {
        public UserDefinedClass userDefinedClassInstance;

        public void Start()
        {
            var list = DataList<int>.New(new int[] { 0, 1, 2, 3 });
            Assert.Equal(new object[] { 0, 1, 2, 3 }, list.ToObjectArray(), this);

            var list2 = DataList<UserDefinedClass>.New();
            Assert.Equal(new object[] { }, list2.ToObjectArray(), this);

            var list3 = DataList<UserDefinedClass>.New(new UserDefinedClass[] { userDefinedClassInstance });
            Assert.Equal(new object[] { userDefinedClassInstance }, list3.ToObjectArray(), this);
        }
    }
}

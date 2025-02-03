using UnityEngine;
using UdonSharp;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class DataListToArrayTest : UdonSharpBehaviour
    {
        public UserDefinedClass userDefinedClassInstance;

        public void Start()
        {
            var list = DataList<int>.New(new int[] { 0, 1, 2, 3 });
            Assert.Equal(new int[] { 0, 1, 2, 3 }, list.ToArray(), this);

            var list2 = DataList<UserDefinedClass>.New();
            Assert.Equal(new UserDefinedClass[] { }, list2.ToArray(), this);

            var list3 = DataList<UserDefinedClass>.New(new UserDefinedClass[] { userDefinedClassInstance });
            Assert.Equal(new UserDefinedClass[] { userDefinedClassInstance }, list3.ToArray(), this);
        }
    }
}

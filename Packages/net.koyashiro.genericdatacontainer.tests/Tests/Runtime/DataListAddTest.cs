using UnityEngine;
using VRC.SDK3.Data;
using UdonSharp;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class DataListAddTest : UdonSharpBehaviour
    {
        public void Start()
        {
            var list = DataList<int>.New();
            Assert.Equal(new DataList(), list, this);

            list.Add(100);
            Assert.Equal(new DataList(new DataToken[] { new DataToken(100) }), list, this);

            list.Add(200);
            Assert.Equal(new DataList(new DataToken[] { new DataToken(100), new DataToken(200) }), list, this);

            list.Add(300);
            Assert.Equal(new DataList(new DataToken[] { new DataToken(100), new DataToken(200), new DataToken(300) }), list, this);
        }
    }
}

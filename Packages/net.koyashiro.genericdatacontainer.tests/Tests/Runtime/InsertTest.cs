using UnityEngine;
using VRC.SDK3.Data;
using UdonSharp;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class InsertTest : UdonSharpBehaviour
    {
        public void Start()
        {
            var list = DataList<int>.New();
            Assert.Equal(new DataList(), list, this);

            list.Insert(0, 100);
            Assert.Equal(new DataList(new DataToken[] { new DataToken(100), }), list, this);

            list.Insert(1, 200);
            Assert.Equal(new DataList(new DataToken[] { new DataToken(100), new DataToken(200), }), list, this);

            list.Insert(0, 300);
            Assert.Equal(new DataList(new DataToken[] { new DataToken(300), new DataToken(100), new DataToken(200), }), list, this);
        }
    }
}

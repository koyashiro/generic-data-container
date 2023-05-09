using UnityEngine;
using VRC.SDK3.Data;
using UdonSharp;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class InsertRangeTest : UdonSharpBehaviour
    {
        public void Start()
        {
            var list = DataList<int>.New();
            Assert.Equal(new DataList(), list, this);

            list.InsertRange(0, new int[] { 100, 200, 300, 400 });
            Assert.Equal(
                new DataList(
                    new DataToken[]
                    {
                        new DataToken(100),
                        new DataToken(200),
                        new DataToken(300),
                        new DataToken(400)
                    }
                ),
                list,
                this
            );

            list.InsertRange(2, DataList<int>.New(new int[] { 500, 600, 700, 800 }));
            Assert.Equal(
                new DataList(
                    new DataToken[]
                    {
                        new DataToken(100),
                        new DataToken(200),
                        new DataToken(500),
                        new DataToken(600),
                        new DataToken(700),
                        new DataToken(800),
                        new DataToken(300),
                        new DataToken(400)
                    }
                ),
                list,
                this
            );
        }
    }
}

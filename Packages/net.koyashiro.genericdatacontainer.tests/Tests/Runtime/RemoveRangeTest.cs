using UnityEngine;
using VRC.SDK3.Data;
using UdonSharp;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class RemoveRangeTest : UdonSharpBehaviour
    {
        public void Start()
        {
            var list = DataList<int>.New(new int[] { 100, 200, 300, 400 });
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

            list.RemoveAt(0);
            Assert.Equal(
                new DataList(
                    new DataToken[]
                    {
                        new DataToken(200),
                        new DataToken(300),
                        new DataToken(400)
                    }
                ),
                list,
                this
            );

            list.RemoveAt(2);
            Assert.Equal(
                new DataList(
                    new DataToken[]
                    {
                        new DataToken(200),
                        new DataToken(300)
                    }
                ),
                list,
                this
            );

            list.RemoveAt(1);
            Assert.Equal(new DataList(new DataToken[] { new DataToken(200) }), list, this);

            list.RemoveAt(0);
            Assert.Equal(new DataList(), list, this);
        }
    }
}

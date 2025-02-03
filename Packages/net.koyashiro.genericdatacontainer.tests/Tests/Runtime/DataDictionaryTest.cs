using UnityEngine;
using VRC.SDK3.Data;
using UdonSharp;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class DataDictionaryTest : UdonSharpBehaviour
    {
        public void Start()
        {
            var dic = DataDictionary<UserDefinedEnum, int>.New();
            dic.SetValue(UserDefinedEnum.A, 100);
            dic.SetValue(UserDefinedEnum.B, 200);
            dic.SetValue(UserDefinedEnum.C, 300);

            Assert.Equal(100, dic.GetValue(UserDefinedEnum.A), this);
            Assert.Equal(200, dic.GetValue(UserDefinedEnum.B), this);
            Assert.Equal(300, dic.GetValue(UserDefinedEnum.C), this);

            var keys = dic.GetKeys();
            Assert.Equal(UserDefinedEnum.A, keys.GetValue(0), this);
            Assert.Equal(UserDefinedEnum.B, keys.GetValue(1), this);
            Assert.Equal(UserDefinedEnum.C, keys.GetValue(2), this);

            Assert.Equal(new UserDefinedEnum[] { UserDefinedEnum.A, UserDefinedEnum.B, UserDefinedEnum.C }, keys.ToArray());
            Assert.Equal(new object[] { UserDefinedEnum.A, UserDefinedEnum.B, UserDefinedEnum.C }, keys.ToObjectArray());

            var values = dic.GetValues();
            Assert.Equal(100, values.GetValue(0), this);
            Assert.Equal(200, values.GetValue(1), this);
            Assert.Equal(300, values.GetValue(2), this);

            Assert.Equal(new int[] { 100, 200, 300 }, values.ToArray());
            Assert.Equal(new object[] { 100, 200, 300 }, values.ToObjectArray());

            int output;
            Assert.True(dic.Remove(UserDefinedEnum.A, out output), this);
            Assert.Equal(100, output, this);
            Assert.True(dic.Remove(UserDefinedEnum.B, out output), this);
            Assert.Equal(200, output, this);
            Assert.True(dic.Remove(UserDefinedEnum.C, out output), this);
            Assert.Equal(300, output, this);
        }
    }
}

using UnityEngine;
using UdonSharp;
using VRC.SDK3.Data;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class DataListTryGetValueTest : UdonSharpBehaviour
    {
        public UserDefinedClass userDefinedClassInstance;

        public void Start()
        {
            // int
            {
                var intList = DataList<int>.New(new int[] { 100, 200, 300, 400 });

                int output;
                Assert.True(intList.TryGetValue(0, out output));
                Assert.Equal(100, output);

                Assert.True(intList.TryGetValue(1, out output));
                Assert.Equal(200, output);

                Assert.True(intList.TryGetValue(2, out output));
                Assert.Equal(300, output);

                Assert.True(intList.TryGetValue(3, out output));
                Assert.Equal(400, output);

                Assert.False(intList.TryGetValue(4, out output));
                Assert.Equal(default(int), output);
            }

            // User defined class
            {
                var userDefinedClassList = DataList<UserDefinedClass>.New();
                userDefinedClassList.Add(userDefinedClassInstance);
                Assert.True(userDefinedClassList.TryGetValue(0, out var output));
                Assert.Equal(userDefinedClassInstance, output, this);
                Assert.Equal(userDefinedClassInstance.field, output.field, this);
            }

            // User defined enum
            {
                var userDefinedEnumList = DataList<UserDefinedEnum>.New();
                userDefinedEnumList.Add(UserDefinedEnum.A);
                Assert.True(userDefinedEnumList.TryGetValue(0, out var output));
                Assert.Equal(UserDefinedEnum.A, output, this);
            }

            // DataList
            {
                var dataListList = DataList<DataList>.New();
                var dataList = new DataList();
                dataListList.Add(dataList);
                Assert.True(dataListList.TryGetValue(0, out var output));
                Assert.Equal(dataList, output, this);
            }

            // DataList<T>
            {
                var genericDataListList = DataList<DataList<int>>.New();
                var genericDataList = DataList<int>.New();
                genericDataListList.Add(genericDataList);
                Assert.True(genericDataListList.TryGetValue(0, out var output));
                Assert.Equal(genericDataList, output, this);
            }

            // DataDictionary
            {
                var dataDictionaryList = DataList<DataDictionary>.New();
                var dataDictionary = new DataDictionary();
                dataDictionaryList.Add(dataDictionary);
                Assert.True(dataDictionaryList.TryGetValue(0, out var output));
                Assert.Equal(dataDictionary, output, this);
            }

            // DataDictionary<TKey, TValue>
            {
                var genericDataDictionaryList = DataList<DataDictionary<int, int>>.New();
                var genericDataDictionary = DataDictionary<int, int>.New();
                genericDataDictionaryList.Add(genericDataDictionary);
                Assert.True(genericDataDictionaryList.TryGetValue(0, out var output));
                Assert.Equal(genericDataDictionary, output, this);
            }
        }
    }
}

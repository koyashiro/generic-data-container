using UnityEngine;
using UdonSharp;
using VRC.SDK3.Data;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class DataListGetValueTest : UdonSharpBehaviour
    {
        public UserDefinedClass userDefinedClassInstance;

        public void Start()
        {
            // int
            {
                var intList = DataList<int>.New(new int[] { 100, 200, 300, 400 });

                Assert.Equal(100, intList.GetValue(0), this);
                Assert.Equal(200, intList.GetValue(1), this);
                Assert.Equal(300, intList.GetValue(2), this);
                Assert.Equal(400, intList.GetValue(3), this);
            }

            // User defined class
            {
                var userDefinedClassList = DataList<UserDefinedClass>.New();
                userDefinedClassList.Add(userDefinedClassInstance);
                Assert.Equal(userDefinedClassInstance, userDefinedClassList.GetValue(0), this);
                Assert.Equal(userDefinedClassInstance.field, userDefinedClassList.GetValue(0).field, this);
            }

            // User defined enum
            {
                var userDefinedEnumList = DataList<UserDefinedEnum>.New();
                userDefinedEnumList.Add(UserDefinedEnum.A);
                Assert.Equal(UserDefinedEnum.A, userDefinedEnumList.GetValue(0), this);
            }

            // DataList
            {
                var dataListList = DataList<DataList>.New();
                var dataList = new DataList();
                dataListList.Add(dataList);
                Assert.Equal(dataList, dataListList.GetValue(0), this);
            }

            // DataList<T>
            {
                var genericDataListList = DataList<DataList<int>>.New();
                var genericDataList = DataList<int>.New();
                genericDataListList.Add(genericDataList);
                Assert.Equal(genericDataList, genericDataListList.GetValue(0), this);
            }

            // DataDictionary
            {
                var dataDictionaryList = DataList<DataDictionary>.New();
                var dataDictionary = new DataDictionary();
                dataDictionaryList.Add(dataDictionary);
                Assert.Equal(dataDictionary, dataDictionaryList.GetValue(0), this);
            }

            // DataDictionary<TKey, TValue>
            {
                var genericDataDictionaryList = DataList<DataDictionary<int, int>>.New();
                var genericDataDictionary = DataDictionary<int, int>.New();
                genericDataDictionaryList.Add(genericDataDictionary);
                Assert.Equal(genericDataDictionary, genericDataDictionaryList.GetValue(0), this);
            }
        }
    }
}

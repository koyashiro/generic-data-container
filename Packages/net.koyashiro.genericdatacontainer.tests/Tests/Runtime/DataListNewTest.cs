using System;
using UnityEngine;
using VRC.SDK3.Data;
using UdonSharp;
using Koyashiro.UdonTest;

namespace Koyashiro.GenericDataContainer.Tests
{
    [AddComponentMenu("")]
    public class DataListNewTest : UdonSharpBehaviour
    {
        public void Start()
        {
            Assert.Equal(new DataList(), DataList<int>.New(), this);
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken(false), new DataToken(true) }),
                DataList<bool>.New(new bool[] { false, true }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken((sbyte)0), new DataToken((sbyte)1) }),
                DataList<sbyte>.New(new sbyte[] { (sbyte)0, (sbyte)1 }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken((byte)0), new DataToken((byte)1) }),
                DataList<byte>.New(new byte[] { (byte)0, (byte)1 }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken((short)0), new DataToken((short)1) }),
                DataList<short>.New(new short[] { (short)0, (short)1 }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken((ushort)0), new DataToken((ushort)1) }),
                DataList<ushort>.New(new ushort[] { (ushort)0, (ushort)1 }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken(0), new DataToken(1) }),
                DataList<int>.New(new int[] { 0, 1 }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken(0U), new DataToken(1U) }),
                DataList<uint>.New(new uint[] { 0, 1 }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken(0L), new DataToken(1L) }),
                DataList<long>.New(new long[] { 0L, 1L }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken(0UL), new DataToken(1UL) }),
                DataList<ulong>.New(new ulong[] { 0UL, 1UL }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken(0F), new DataToken(1F) }),
                DataList<float>.New(new float[] { 0F, 1F }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken(0D), new DataToken(1D) }),
                DataList<double>.New(new double[] { 0D, 1D }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken("aaa"), new DataToken("bbb") }),
                DataList<string>.New(new string[] { "aaa", "bbb" }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken(new DataList()) }),
                DataList<DataList>.New(new DataList[] { new DataList() }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken(new DataDictionary()) }),
                DataList<DataDictionary>.New(new DataDictionary[] { new DataDictionary() }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken(new DateTime(2023, 01, 01, 0, 0, 0)), new DataToken(new DateTime(2023, 01, 02, 0, 0, 0)) }),
                DataList<DateTime>.New(new DateTime[] { new DateTime(2023, 01, 01, 0, 0, 0), new DateTime(2023, 01, 02, 0, 0, 0) }),
                this
            );
            Assert.Equal(
                new DataList(new DataToken[] { new DataToken(DataError.None), new DataToken(DataError.KeyDoesNotExist) }),
                DataList<DataError>.New(new DataError[] { DataError.None, DataError.KeyDoesNotExist }),
                this
            );
        }
    }
}

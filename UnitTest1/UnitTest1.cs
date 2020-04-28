using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_AddingOneValueToEmptyCustomList_AddedValueGoesToIndexZero()
        {
            // arrange
            CustomList<int> testList = new CustomList<int>();
            int itemToAdd = 10;
            int expected = 10;
            int actual;

            // act
            testList.Add(itemToAdd);
            actual = testList[0];

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_AddingOneValueToEmptyCustomList_CountOfCustomListIncrements()
        {
            // arrange
            CustomList<int> testList = new CustomList<int>();
            int itemToAdd = 10;
            int expected = 1;
            int actual;

            // act
            testList.Add(itemToAdd);
            actual = testList.Count;

            // assert
            Assert.AreEqual(expected, actual);
        }

        // what happens if you add multiple things (or add to a CustomList that already has some values)?
        [TestMethod]
        public void DontKnowWhatImDoing()
        {
            // arrange
            CustomList<int> testList = new CustomList<int>();
            int expected = testList.Count + 3;
            int actual;

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            actual = testList.Count;

            // assert
            Assert.AreEqual(expected, actual);
        }
        // what happens to the last-added item?
        [TestMethod]
        public void DontKnowWhatImDoing()
        {
            // arrange
            CustomList<int> testList = new CustomList<int>();
            int expected = 77;
            int actual;

            testList.Add(1);
            testList.Add(2);
            testList.Add(77);
            actual = testList[testList.Count - 1];
            // assert
            Assert.AreEqual(expected, actual);
        }
        // what happens to the Count?
        [TestMethod]
        public void DontKnowWhatImDoing()
        {
            // arrange
            CustomList<int> testList = new CustomList<int>();
            int expected = testList.Count + 1;
            int actual;

            testList.Add(0);
            actual = testList.Count;

            // assert
            Assert.AreEqual(expected, actual);
        }

        // what happens if you add more items than the initial Capacity of the CustomList?

    }
}


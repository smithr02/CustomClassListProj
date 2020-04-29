using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
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
        public void AddingMultipleThingsToAList()
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
        public void CheckingForLastItemOnTheList()
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
        public void CheckingTheCountOfTheList()
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
        [TestMethod]
        public void AddingMoreThanIntialCapacity()
        {
            // arrange
            CustomList<int> testList = new CustomList<int>();
            int expected = 5;
            int actual;

            testList.Add(0);
            testList.Add(0);
            testList.Add(0);
            testList.Add(0);
            testList.Add(0);
            actual = testList.Count;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemovingOneItem()
        {
            // arrange
            CustomList<int> testList = new CustomList<int>();
            int expected = 0;
            int actual;

            testList.Add(1);

            testList.Remove(1);
            
            actual = testList.Count;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemovingOneItemAndNotTheOthers()
        {
            // arrange
            CustomList<int> testList = new CustomList<int>();
            int expected = 2;
            int actual;

            testList.Add(1);
            testList.Add(3);
            testList.Add(5);
            testList.Remove(1);

            actual = testList.Count;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemovingMultipleItems()
        {
            // arrange
            CustomList<int> testList = new CustomList<int>();
            int expected = 0; //only hard code the expected
            int actual;  //never hard code the actual, something that you're testing

            testList.Add(1);
            testList.Add(3);
            testList.Add(5);
            testList.Remove(1);
            testList.Remove(3);
            testList.Remove(5);

            actual = testList.Count;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public bool BoolTestTrueRemove()
        {
            // arrange
            CustomList<int> testList = new CustomList<int>();
            bool expected = true;
            bool actual;

            testList.Add(1);

            actual = testList.Remove(1);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public bool BoolTestFalseRemove()
        {
            // arrange
            CustomList<int> testList = new CustomList<int>();
            bool expected = false;
            bool actual;

            actual = testList.Remove(1);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}


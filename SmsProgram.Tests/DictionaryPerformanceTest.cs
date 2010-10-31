using System;
using System.Text;
using System.Collections.Generic;
using System.Resources;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmsProgram.Properties;
using SmsProgram;

namespace SmsProgram.Tests
{
    public class MyDictionary : SortedDictionary<string, string> { }

    [TestClass]
    public class DictionaryPerformanceTest
    {
        public const int Count = 1000;
        public const int CreateTime = 20;
        public const int ViewTime = 1;
        public const int ModifyTime = 1;
        public const int SearchTime = 1;

        private MyDictionary Init(int count)
        {
            MyDictionary dict = new MyDictionary();
            for (int index = 0; index < count; index++)
                dict.Add(index.ToString(), index.ToString());
            return dict;

        }

        [TestMethod]
        public void CreateTest()
        {
            long time = Environment.TickCount;
            MyDictionary dict = Init(Count);
            time = Environment.TickCount - time;
            Assert.IsTrue(time < CreateTime, time.ToString() + " time");
        }

        [TestMethod]
        public void ViewTest()
        {
            MyDictionary dict = Init(Count);
            long time = Environment.TickCount;
            foreach (var sms in dict)
                Assert.IsTrue(sms.Key != "");
            time = Environment.TickCount - time;
            Assert.IsTrue(time < ViewTime, time.ToString() + " time");
        }

        [TestMethod]
        public void ModifyTest()
        {
            MyDictionary dict = Init(Count);
            long time = Environment.TickCount;
            for(int index = 0; index < dict.Count; index++)
                dict[index.ToString()] = "alibaba";
            time = Environment.TickCount - time;
            Assert.IsTrue(time < ModifyTime, time.ToString() + " time");
        }

        [TestMethod]
        public void SearchTest()
        {
            MyDictionary dict = Init(Count);
            long time = Environment.TickCount;
            Assert.IsNotNull(dict[(Count / 2).ToString()]);
            time = Environment.TickCount - time;
            Assert.IsTrue(time < SearchTime, time.ToString() + " time");
        }
    }
}

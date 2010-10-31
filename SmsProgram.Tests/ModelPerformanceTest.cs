using System;
using System.Text;
using System.Collections.Generic;
using System.Resources;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmsProgram.Properties;
using SmsProgram;
using SmsProgram.Model;

namespace SmsProgram.Tests
{
    [TestClass]
    public class ModelPerformanceTest
    {
        public const int Count = 1000;
        public const int CreateTime = 80; // 4 razy wolniej
        public const int ViewTime = 20;
        public const int ModifyTime = 40; // 5 razy wolniej
        public const int SearchTime = 1;
        public const int CalcTime = 1;

        private SmsProject Init(int count)
        {
            SmsProject project = new SmsProject();
            for (int index = 0; index < count; index++)
                project.Groups.AddGroupsRow(index.ToString(), "", DateTime.Now, DateTime.Now);
            return project;

        }

        [TestMethod]
        public void CreateTest()
        {
            long time = Environment.TickCount;
            SmsProject project = Init(Count);
            time = Environment.TickCount - time;
            Assert.IsTrue(time < CreateTime, time.ToString() + " time");
        }

        [TestMethod]
        public void ViewTest()
        {
            SmsProject project = Init(Count);
            long time = Environment.TickCount;
            for (int index = 0; index < project.Groups.Count; index++)
                Assert.IsTrue(project.Groups[index].Group != null);
            time = Environment.TickCount - time;
            Assert.IsTrue(time < ViewTime, time.ToString() + " time");
        }

        [TestMethod]
        public void ModifyTest()
        {
            SmsProject project = Init(Count);
            long time = Environment.TickCount;
            for (int index = 0; index < project.Groups.Count; index++)
                project.Groups[index].Description = "alibaba";
            time = Environment.TickCount - time;
            Assert.IsTrue(time < ModifyTime, time.ToString() + " time");
        }

        [TestMethod]
        public void SearchTest()
        {
            SmsProject project = Init(Count);
            long time = Environment.TickCount;
            Assert.IsNotNull(project.Groups.FindByGroup((project.Groups.Count / 2).ToString()));
            time = Environment.TickCount - time;
            Assert.IsTrue(time < SearchTime, time.ToString() + " time");
        }
    }
}

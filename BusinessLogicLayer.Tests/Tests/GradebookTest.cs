using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.BusinessLogicLayer.Models;
using System;

namespace Gradebook.BusinessLogicLayer.Tests
{
    public static class GradebookTest
    {
        private static readonly IGradebookManager _gradebookManager = new GradebookManager();

        public static void Populate()
        {
            DateTime dt = DateTime.Now;
            var CurrentTimeStamp = BitConverter.GetBytes(dt.Ticks);

            Gbook gbook1 = new Gbook(1, new DateTime(2013, 1, 1), new DateTime(2017, 1, 1), true, 95, DateTime.Now, CurrentTimeStamp);
            Gbook gbook2 = new Gbook(1, new DateTime(2014, 1, 1), new DateTime(2018, 1, 1), true, 95, DateTime.Now, CurrentTimeStamp);
            Gbook gbook3 = new Gbook(2, new DateTime(2014, 1, 1), new DateTime(2018, 1, 1), true, 95, DateTime.Now, CurrentTimeStamp);
            Gbook gbook4 = new Gbook(2, new DateTime(2014, 1, 1), new DateTime(2018, 1, 1), true, 95, DateTime.Now, CurrentTimeStamp);

            _gradebookManager.Add(gbook1);
            _gradebookManager.Add(gbook2);
            _gradebookManager.Add(gbook3);
            _gradebookManager.Add(gbook4);
        }
    }
}

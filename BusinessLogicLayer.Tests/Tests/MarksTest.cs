using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.BusinessLogicLayer.Models;
using System;

namespace Gradebook.BusinessLogicLayer.Tests
{
    public static class MarksTest
    {
        private static readonly IMarksManager _marksManager = new MarksManager();

        public static void Populate()
        {
            DateTime dt = DateTime.Now;
            var CurrentTimeStamp = BitConverter.GetBytes(dt.Ticks);

            Marks mark1 = new Marks(1, 1, 95, DateTime.Now, CurrentTimeStamp, 5);
            Marks mark2 = new Marks(1, 2, 95, DateTime.Now, CurrentTimeStamp, 2);
            Marks mark3 = new Marks(1, 3, 95, DateTime.Now, CurrentTimeStamp, 4);
            Marks mark4 = new Marks(1, 4, 95, DateTime.Now, CurrentTimeStamp, 5);
            Marks mark5 = new Marks(2, 1, 95, DateTime.Now, CurrentTimeStamp);
            Marks mark6 = new Marks(2, 1, 95, DateTime.Now, CurrentTimeStamp);
            Marks mark7 = new Marks(2, 1, 95, DateTime.Now, CurrentTimeStamp);
            Marks mark8 = new Marks(3, 1, 95, DateTime.Now, CurrentTimeStamp);
            Marks mark9 = new Marks(3, 1, 95, DateTime.Now, CurrentTimeStamp);
            Marks mark10 = new Marks(2, 3, 95, DateTime.Now, CurrentTimeStamp, 5);

            _marksManager.Add(mark10);
        }
    }
}

using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.BusinessLogicLayer.Models;
using System;

namespace Gradebook.BusinessLogicLayer.Tests
{
    public static class MarkTest
    {
        private static readonly IMarkManager _markManager = new MarkManager();

        public static void Populate()
        {
            DateTime dt = DateTime.Now;
            var CurrentTimeStamp = BitConverter.GetBytes(dt.Ticks);

            Mark mark1 = new Mark(1, 4, "Predavanja", 95, DateTime.Now, CurrentTimeStamp,false,true);

            _markManager.Add(mark1);
        }
    }
}

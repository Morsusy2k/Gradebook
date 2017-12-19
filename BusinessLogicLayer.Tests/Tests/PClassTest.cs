using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.BusinessLogicLayer.Models;
using System;

namespace Gradebook.BusinessLogicLayer.Tests
{
    public static class PClassTest
    {
        private static readonly IPClassManager _pclassManager = new PClassManager();

        public static void Populate()
        {
            DateTime dt = DateTime.Now;
            var CurrentTimeStamp = BitConverter.GetBytes(dt.Ticks);

            PClass pclass1 = new PClass(95, 1, "2015", "III", 5212, 95, DateTime.Now, CurrentTimeStamp);
            PClass pclass2 = new PClass(95, 1, "2014", "IV", 5213, 95, DateTime.Now, CurrentTimeStamp);

            _pclassManager.Add(pclass1);
            _pclassManager.Add(pclass2);
        }
    }
}

using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.BusinessLogicLayer.Models;
using System;

namespace Gradebook.BusinessLogicLayer.Tests
{
    public static class FieldTest
    {
        private static readonly IFieldManager _fieldManager = new FieldManager();

        public static void Populate()
        {
            DateTime dt = DateTime.Now;
            var CurrentTimeStamp = BitConverter.GetBytes(dt.Ticks);

            FieldOfStudy field1 = new FieldOfStudy("Information Technology", 95, DateTime.Now, CurrentTimeStamp);
            FieldOfStudy field2 = new FieldOfStudy("Computer Science", 95, DateTime.Now, CurrentTimeStamp);
            FieldOfStudy field3 = new FieldOfStudy("Software Development", 95, DateTime.Now, CurrentTimeStamp);

            _fieldManager.Add(field1);
            _fieldManager.Add(field2);
            _fieldManager.Add(field3);

        }
    }
}

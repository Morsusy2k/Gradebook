using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.BusinessLogicLayer.Models;
using System;

namespace Gradebook.BusinessLogicLayer.Tests
{
    public static class SubjectTest
    {
        private static readonly ISubjectManager _subjectManager = new SubjectManager();

        public static void Populate()
        {
            DateTime dt = DateTime.Now;
            var CurrentTimeStamp = BitConverter.GetBytes(dt.Ticks);

            Subject sub1 = new Subject(95,"Osnove Programiranja",95, DateTime.Now,CurrentTimeStamp);
            Subject sub2 = new Subject(95, "Osnove Elektronike", 95, DateTime.Now, CurrentTimeStamp);
            Subject sub3 = new Subject(95, "Tenicko Crtanje", 95, DateTime.Now, CurrentTimeStamp);
            Subject sub4 = new Subject(95, "Elektronika 2", 95, DateTime.Now, CurrentTimeStamp);

            _subjectManager.Add(sub1);
            _subjectManager.Add(sub2);
            _subjectManager.Add(sub3);
            _subjectManager.Add(sub4);
        }
    }
}

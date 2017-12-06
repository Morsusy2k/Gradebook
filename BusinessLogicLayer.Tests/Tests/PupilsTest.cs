using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.BusinessLogicLayer.Models;
using System;

namespace Gradebook.BusinessLogicLayer.Tests
{
    public static class PupilsTest
    {
        private static readonly IPupilManager _pupilManager = new PupilManager();

        public static void Populate()
        {
            DateTime dt = DateTime.Now;
            var CurrentTimeStamp = BitConverter.GetBytes(dt.Ticks);

            Pupil pupil1 = new Pupil(1, "Darko Matic", 95, DateTime.Now, CurrentTimeStamp);
            Pupil pupil2 = new Pupil(1, "Vanja Grubic", 95, DateTime.Now, CurrentTimeStamp);
            Pupil pupil3 = new Pupil(1, "Una Miric", 95, DateTime.Now, CurrentTimeStamp);
            Pupil pupil4 = new Pupil(1, "Djordje Savin", 95, DateTime.Now, CurrentTimeStamp);
            Pupil pupil5 = new Pupil(1, "Milan Ivanov", 95, DateTime.Now, CurrentTimeStamp);

            _pupilManager.Add(pupil1);
            _pupilManager.Add(pupil2);
            _pupilManager.Add(pupil3);
            _pupilManager.Add(pupil4);
            _pupilManager.Add(pupil5);
        }
    }
}

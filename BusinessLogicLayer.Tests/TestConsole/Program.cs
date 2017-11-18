using Gradebook.BusinessLogicLayer.Tests;

namespace Gradebook.BusinessLogicLayer.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //UsersTest.Populate();
            //UsersTest.UpdateAndDelete();
            //UsersTest.ShowAll();

            //RolesTest.ShowAll();
            //RolesTest.Populate();
            //RolesTest.UpdateAndDelete();
            //RolesTest.ShowAll();
            UserRolesTest.Populate();
            UserRolesTest.ShowAll();
        }
    }
}

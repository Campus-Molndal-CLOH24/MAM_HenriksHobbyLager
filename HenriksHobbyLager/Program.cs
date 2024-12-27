using HenriksHobbyLager.Models;
using HenriksHobbyLager.ProgramManager;
using static HenriksHobbyLager.ProgramManager.LagerProgramManager;
using HenriksHobbyLager.Database;


namespace HenriksHobbyLager
{
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine("Initializing the application...");
            //SqliteDatabaseInitializer.Initialize();
            Console.WriteLine("Application setup complete.");
            var programManager = new HenriksHobbyLagerProgramManager();//Hanterar programmet, Logiken har fått en egen klass 
            programManager.Run();
        }
    }
}
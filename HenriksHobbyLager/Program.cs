using HenriksHobbyLager.Models;
using HenriksHobbyLager.ProgramManager;
using static HenriksHobbyLager.ProgramManager.LagerProgramManager;


namespace HenriksHobbyLager
{
    public class Program
    {
        private static void Main()
        {
            var programManager = new HenriksHobbyLagerProgramManager();//Hanterar programmet, Logiken har fått en egen klass 
            programManager.Run();
        }
    }
}
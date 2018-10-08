namespace Cardstone.CLI.Contracts
{
    public interface IEngine
    {
        void Run();

        ICommand GetCommand(string name);
    }
}

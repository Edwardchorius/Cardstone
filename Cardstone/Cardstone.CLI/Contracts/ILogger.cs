using System.Text;

namespace Cardstone.CLI.Contracts
{
    public interface ILogger
    {
        void PrintLogs();

        void AddLog(string message);

        void AddLog(string message, bool print);
    }
}

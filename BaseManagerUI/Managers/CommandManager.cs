using BaseManagerUI.Commands;
using BaseManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseManagerUI.Managers
{
    internal class CommandManager
    {
        private static List<Command> FullCommandList = new List<Command>();

        internal static void Initialize()
        {
            FullCommandList = new List<Command>()
            {
                new Construct(),
                new Commands.View()
            };
        }

        internal static Task<string> ProcessUserInput(string v)
        {
            string[] arguments = v.Split(' ');
            Command? userCommand = GetCommandFromUserInput(arguments[0]);
            GeneralResponse commandResult;

            if (userCommand == null)
                return Task.FromResult("Invalid Command");

            commandResult = userCommand.Validate(arguments);
            if (!commandResult.IsSuccessful)
                return Task.FromResult(commandResult.Message);

            commandResult = userCommand.Execute(arguments);

            return Task.FromResult(commandResult.Message);
        }

        private static Command? GetCommandFromUserInput(string input) => FullCommandList.Where(x => x.Action.ToUpper() == input.ToUpper() || x.AltNames.Contains(input.ToUpper())).FirstOrDefault() ?? null;
    }
}

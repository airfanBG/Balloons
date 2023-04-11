using Balloons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Services
{
    public class CommandParserService:ICommandParserService
    {
        private readonly ICommandFactory commandFactory;

        public CommandParserService(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }
        public IList<string> ParseParameters(string command)
        {
            var commandParts = command.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return null;
            }

            return commandParts;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var commandTypeInfo = this.FindCommand(commandName);
            var command = this.commandFactory.GetCommand(commandTypeInfo);

            return command;
        }

        private TypeInfo FindCommand(string commandName)
        {
            var currentAssemblyName = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssemblyName.DefinedTypes
               .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
               .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
               .SingleOrDefault();

            if (commandTypeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }

            return commandTypeInfo;
        }
    }
}

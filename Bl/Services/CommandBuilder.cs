using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bl.Models;
using System.Collections.Generic;

namespace Bl.Services
{
    public static class CommandBuilder
    {
        public static List<Command> Build(Operation op)
        {
            var commands = new List<Command>();

            var tool = ToolRules.Resolve(op);

            switch (op.Type)
            {
                case "HOLE":

                    commands.Add(new Command
                    {
                        Code = "G01",
                        Arguments = $"X{op.X} Y{op.Y} TOOL{tool.Replace("T", "")}"
                    });

                    commands.Add(new Command
                    {
                        Code = "M25",
                        Arguments = ""
                    });

                    break;

                case "SQUARE":

                    commands.Add(new Command
                    {
                        Code = "G01",
                        Arguments = $"X{op.X} Y{op.Y} TOOL{tool.Replace("T", "")}"
                    });

                    commands.Add(new Command
                    {
                        Code = "SPN=2",
                        Arguments = ""
                    });

                    break;

                case "CUT":

                    commands.Add(new Command
                    {
                        Code = "G01",
                        Arguments = $"X{op.X} Y{op.Y} TOOL{tool.Replace("T", "")}"
                    });

                    commands.Add(new Command
                    {
                        Code = "G4",
                        Arguments = "F0.2"
                    });

                    break;
            }

            return commands;
        }
    }
}
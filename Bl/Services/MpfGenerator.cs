using Bl.Api;
using Bl.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
{
    public class MpfGenerator : IBlMpfGenerator
    {
        //public string Generate(DoorJob job)
        //{
        //    var sb = new StringBuilder();

        //    AppendHeader(sb, job);
        //    AppendSetup(sb, job);
        //    AppendToolDefinitions(sb, job);
        //    AppendToolOperations(sb, job);
        //    AppendFooter(sb, job);

        //    return sb.ToString();
        //}
        public string Generate(BlDoor door)
        {
            var sb = new StringBuilder();
            var _doorProcessingService = new DoorProcessingService();
            var operations = _doorProcessingService.BuildOperations(door);

            AppendHeader(sb, door);
            AppendSetup(sb, door);

            AppendToolDefinitions(sb, operations);
            AppendToolOperations(sb, operations);

            AppendFooter(sb, door);

            return sb.ToString();
        }
        private void AppendHeader(StringBuilder sb, BlDoor job)
        {
            sb.AppendLine($";%_N_JOB_{job.Id}_MPF");
            sb.AppendLine(";PATH=/_N_MPF_DIR/");
            sb.AppendLine($";PART SIZE: {job.Width} X {job.Height}");
            sb.AppendLine($";DATE {DateTime.Now:MMM dd yyyy}");
            sb.AppendLine(";VERSION V1.0.0");
            sb.AppendLine();
        }
        private void AppendSetup(StringBuilder sb, BlDoor job)
        {
            sb.AppendLine("BB:");
            sb.AppendLine($"N10 R101={job.Height}");
            sb.AppendLine($"N15 R102={job.Width}");
            sb.AppendLine("N20 R108=1.2");

            sb.AppendLine("N25 CLAMP(343 ,621 ,1517 )");
            sb.AppendLine("N30 LOAD");
            sb.AppendLine("N35 LOAD_OFFSET");
            sb.AppendLine("N40 F60000");

            sb.AppendLine("N45 RAM(0 ,1.2 )");

            sb.AppendLine("N50 STOPRE");
            sb.AppendLine();
        }
        private void AppendToolDefinitions(StringBuilder sb, List<Operation> operations)
        {
            var usedTools = new HashSet<string>();

            foreach (var op in operations)
            {
                var tool = ToolRules.Resolve(op);

                if (usedTools.Contains(tool))
                    continue;

                usedTools.Add(tool);

                var parameters = ToolParameterResolver.Resolve(op);

                sb.AppendLine($";*{tool} {parameters}");
            }

            sb.AppendLine();
        }
        private void AppendToolOperations(StringBuilder sb, List<Operation> operations)
        {
            var sequence = new NumberSequence(60);

            foreach (var op in operations)
            {
                var tool = ToolRules.Resolve(op);

                sb.AppendLine($";({tool})");

                var commands = CommandBuilder.Build(op);

                foreach (var cmd in commands)
                {
                    var lineNumber = sequence.Next();
                    sb.AppendLine($"N{lineNumber} {cmd.Code} {cmd.Arguments}".Trim());
                }

                sb.AppendLine($"N{sequence.Next()} STOPRE");
                sb.AppendLine();
            }
        }
        private void AppendFooter(StringBuilder sb, BlDoor job)
        {
            sb.AppendLine("UNLOAD");
            sb.AppendLine("M31");
            sb.AppendLine("ENDIF");
            sb.AppendLine("M02");
        }
    }
}

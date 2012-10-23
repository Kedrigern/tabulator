using System;
using System.Collections.Generic;
using CommandLine;			//http://commandline.codeplex.com/, MIT License
using CommandLine.Text;

namespace Tabulator
{
	/// <summary>
	/// Comandline Options, use  http://commandline.codeplex.com/
	/// </summary>
	public class Options : CommandLineOptionsBase {
		[Option("o", "out", Required = false, HelpText = "Name of output file. If not defined, it is used stdout")]
		public string OutputFile {get; set;}
		[Option("s", "standalone", DefaultValue = false, HelpText = "Standalone document (ready to compile)")]
		public bool Standalone {get; set;}
		[Option("d", "delimiter", DefaultValue = ';', HelpText = "Input delimiter (default is \";\"), of course only for formats with more that one delimiter - for example csv.")]
		public char Delimiter {get; set;}
		[Option(null, "out-delimiter", DefaultValue = ';', HelpText = "Output delimiter (default is \";\"), of course only for formats with more that one delimiter - for example csv.")]
		public char OutDelimiter {get; set;}
		[Option(null, "text-limitation", DefaultValue = '"', HelpText = "Limitation of text - type of quotes.")]
		public char TextLimitation {get; set;}
		[Option("l", "line-width", DefaultValue = 180, HelpText = "Maximum width of line.")]
		public int MaxLineWidth {get; set;}
		[Option("c", "column-width", DefaultValue = 35, HelpText = "Maximum width of one column.")]
		public int MaxColWidth {get; set;}
		[Option("t", "tab-size", DefaultValue = 4, HelpText = "Size of tabulator (necessary for pretty print with tabs).")]
		public int TabulatorSize {get; set;}
		[Option("f", "format", DefaultValue = Format.latex, HelpText = "Output format, default is Latex")]
		public Format OutputFormat {get; set;}
		[Option("i", "input-format", DefaultValue = Format.csv, HelpText = "Input format, default is csv")]
		public Format InputFormat {get; set;}
		[Option("p", "padding", DefaultValue = Pad.space, HelpText = "Type of padding - spaces or tabs")]
		public Pad Padding {get; set;}
		[Option("v", "version", DefaultValue = false, HelpText = "Show version.")]
		public bool Version {get; set;}
		[Option(null, "tests", DefaultValue = false, HelpText = "Run unit tests.")]
		public bool Tests {get; set;}
		
		[ValueList(typeof(List<string>))]
		public IList<string> Files { get; set; }

		public Options() : base() {}

		[HelpOption(HelpText = "Dispaly this help screen.")]
    	public string GetUsage()
	    {
		    HelpText help = new HelpText();
            help.Copyright = new CopyrightInfo("Ondřej Profant", 2012);
            help.AddPreOptionsLine("This is free software. You may redistribute copies of it under the terms of");
			help.AddPreOptionsLine("the GPL License <http://www.gnu.org/copyleft/gpl.html>.");
			help.AddPreOptionsLine("Arguments:");
            help.AddOptions(this);
			help.AddPostOptionsLine("Input format:");
			help.AddPostOptionsLine("\t\tcsv (default)");
			help.AddPostOptionsLine("\t\thtml");
			help.AddPostOptionsLine("Output format:");
			help.AddPostOptionsLine("\t\tcsv");
			help.AddPostOptionsLine("\t\tLaTeX (default)");
			help.AddPostOptionsLine("\t\thtml");
			help.AddPostOptionsLine("Usage:\t\t" +  System.AppDomain.CurrentDomain.FriendlyName + " [args] [files]");
			help.AddPostOptionsLine("Examples:\t" +  System.AppDomain.CurrentDomain.FriendlyName + " -o table.tex table.csv");
			help.AddPostOptionsLine("\t\t" +  System.AppDomain.CurrentDomain.FriendlyName + " table.csv");
			help.AddPostOptionsLine("\t\t" +  System.AppDomain.CurrentDomain.FriendlyName + " -s -d ',' table.csv\n");

            return help;
	    }
	}
	
	/// <summary>
	/// Define type of padding: tabulator or space
	/// </summary>
	public enum Pad {
		tab,
		space
	}
		
	/// <summary>
	/// Format enum.
	/// </summary>
	public enum Format {
		latex,
		html,
		csv,
		markdown
	}
}
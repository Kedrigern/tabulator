using System;
using System.IO;
using CommandLine;	//http://commandline.codeplex.com/, MIT License
using NUnit.Framework;

namespace Tabulator
{
	class MainClass
	{
		private static Options options = new Options();
		public static Options Options {
			get { return options; }
		}
		private static TextWriter output;
		
		public static void Main (string[] args)
		{
			// Handle options
            var parser = new CommandLineParser(new CommandLineParserSettings(Console.Error));
            if (!parser.ParseArguments(args, MainClass.options)) {
				Console.Error.WriteLine("Bad format of arguments.");
				Environment.Exit(1);
			}

			HandleSpecialOptions();

			output = Output();
			
			foreach( string file in options.Files ) {
				if( File.Exists( file ) ) {
					var sr = new StreamReader(file);
					try {
						Run(sr);
					} catch (Exception e ) {
						Console.Error.WriteLine("Input file {0} has bad format. Skip {0}.\nException messeage: {1}", file, e.Message);	
					} finally {
						sr.Close();
					}
				} else {
					Console.Error.WriteLine("Input file {0} does not exist. Skip {0}.", file);
				}
			}
			if( options.Files.Count == 0 ) {
				var sr = Console.In;
				Run ( sr );
			}
			output.Close();

			// if output file is empty delete it!
			if( options.OutputFile != null) {
				var fi = new FileInfo( options.OutputFile );
				if( fi.Length < 4 ) {
					// not proper output
					File.Delete( options.OutputFile );
				}
			}
		}

		/// <summary>
		/// Run app for one file - parse input, convert to output format.
		/// </summary>
		/// <param name='sr'>
		/// input
		/// </param>
		private static void Run( TextReader sr)
		{	
			// Parser for input format
			Parsers.Parser par;
#if DEBUG
			Console.WriteLine( "[INFO] Input format: " + options.InputFormat );
#endif
			switch( options.InputFormat ) {
			case Format.csv:
				par = new Parsers.csvParser();
				break;
			case Format.html:
				par = new Parsers.xmlParser();
				break;
			default:
				throw new NotImplementedException();
			}

			var tab = par.Parse( sr );

			// Convertor for output format
			Convertor.Convertor con;
#if DEBUG
			Console.WriteLine( "[INFO] Output format: " + options.OutputFormat );
#endif
			switch( options.OutputFormat ) {
			case Format.latex:
				con = new Convertor.LaTeXConvertor();
				break;
			case Format.csv:
				con = new Convertor.csvConvertor();
				break;
			case Format.html:
				con = new Convertor.xhtmlConvertor();
				break;
			default:
				throw new NotImplementedException();
			}

			output.Write( con.Convert( tab ) );
		}

		/// <summary>
		/// Handles the special options like version or unit testing.
		/// </summary>
		private static void HandleSpecialOptions() 
		{
			// Unit testing
			if( options.Tests )	{
				throw new NotImplementedException();
			}
			
			// Version
			if( options.Version ) {
				Console.WriteLine( "0.1" ); 
				Environment.Exit(0);
			}
		}

		/// <summary>
		/// Set output for this instance of program.
		/// If output is define then output is file
		/// in other case is stdout
		/// </summary>
		private static TextWriter Output()
		{
			TextWriter sw = null;
			if( options.OutputFile != null) {
				try {
					sw = new StreamWriter( options.OutputFile );			
				} catch {
					sw = null;
					Console.Error.WriteLine("Output file {0} can not be open for writing.", options.OutputFile);
					Environment.Exit(1);
				}
			} 
			if ( sw == null ) {
				sw = Console.Out;
			}
			return sw;
		}
	}
}
using System;
using Tabulator.Core;
using Tabulator.Parsers;
using NUnit.Framework;
using CommandLine;

namespace Tabulator.Convertor
{
	[TestFixture]
	public class LaTeXConvertorTests
	{
		private Options opt;
		private csvParser parser;
		private LaTeXConvertor convertor;

		public LaTeXConvertorTests() : base()
		{
			opt = new Options();
			opt.Delimiter = ';';
			opt.MaxColWidth = 35;
			opt.MaxLineWidth = 180;
			opt.TextLimitation = '"';
			convertor = new LaTeXConvertor( opt );
			parser = new csvParser( opt );
		}

		[Test]
		public void test0()
		{
			var table = parser.Parse(
				"c 11; c 12\n"+
				"c 21; c 22"			);
			
			Assert.AreEqual( 2, table.Count, "Line number is incorect");
			Assert.AreEqual( 2, table[0].Count, "First line number of columns is incorect");
			Assert.AreEqual( 2, table[1].Count, "Second line number of columns is incorect");
			
			var output = convertor.Convert( table );

			var result = "\\begin{tabular}{| c | c |}\n" +
				"c 11&c 12\\\\ \n" +
				"c 21&c 22\\\\ \n" +
				"\\end{tabular}\n";
		
			Assert.AreEqual( result, output , "Basic table (csv) is not correctly converted to LaTeX" );
		}
		
		[Test]
		public void test1()
		{
			var table = parser.Parse(
				"c 11; c 12; c 13\n" +
				"c 21; c 22; c 23\n" +
				"c 31; long cell 32; c 33\n" +
				"long cell 41; long cell 42; c 43"
				);
			
			Assert.AreEqual( 4, table.Count, "Number od rows doesnt match." );		
			Assert.AreEqual( 3, table[0].Count, "Number of columns in 1. row is wrong. Row: " + table[0].ToString() );	
			Assert.AreEqual( 3, table[1].Count, "Number of columns in 2. row is wrong. Row: " + table[1].ToString() );
			Assert.AreEqual( 3, table[2].Count, "Number of columns in 3. row is wrong. Row: " + table[2].ToString() );
			Assert.AreEqual( 3, table[3].Count, "Number of columns in 4. row is wrong. Row: " + table[3].ToString() );

			var output = convertor.Convert( table );
		
			var expected = "\\begin{tabular}{| c | c | c |}\n" +
				"c 11        &c 12        &c 13\\\\ \n" +
				"c 21        &c 22        &c 23\\\\ \n" +
				"c 31        &long cell 32&c 33\\\\ \n" +
				"long cell 41&long cell 42&c 43\\\\ \n" +
				"\\end{tabular}\n" ;
			
			Assert.AreEqual( expected, output, "Table produced by convertor doesnt match pattern table for this test. Expected:\n "+expected + "\n--\nProduce:\n" + output );
			
		}
	}
}


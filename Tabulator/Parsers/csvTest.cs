using System;
using System.IO;
using NUnit.Framework;
	
namespace Tabulator.Parsers
{
	[TestFixture]
	public class csvParserTests
	{
		private csvParser p1;
		private Options opt;
		private Core.Table table;
		private const char delimiter = ';';
		private string basicT = "c11" + delimiter + "c12\nc21" + delimiter + "c22";
		private string quoteT = "c11" + delimiter + "c12\nc21" + delimiter + "\"cell" + delimiter + "\"";
		private string multiLineT = "c11" + delimiter + "c12\nc21" + delimiter + "\" na konci řádku \n další řádek \"";
		
		public csvParserTests() : base() 
		{
			opt = new Options();
			opt.Delimiter = ';';
			opt.MaxColWidth = 35;
			opt.MaxLineWidth = 180;
			opt.TextLimitation = '"';
			p1 = new csvParser( opt ); 
		}
		
		[Test]
		public void BasicTable()
		{
			table = p1.Parse( basicT );
			
			Assert.AreEqual(2, table.Count , "Wrong number of rows.");
			Assert.AreEqual(2, table[0].Count , "Wrong number of cells at 1. row.");
			Assert.AreEqual(2, table[1].Count );
			
			Assert.AreEqual("c11", table[0][0] );
			Assert.AreEqual("c12", table[0][1] );
			Assert.AreEqual("c21", table[1][0] );
			Assert.AreEqual("c22", table[1][1] );
		}
		
		[Test]
		public void ZeroCell() 
		{
			table = p1.Parse(" ;;cell 1,3");
			
			Assert.AreEqual(1, table.Count);
			Assert.AreEqual(3, table[0].Count);
			
			Assert.AreEqual("", table[0][0]);
			Assert.AreEqual("", table[0][1]);
			Assert.AreEqual("cell 1,3", table[0][2]);
		}
		
		[Test]
		public void CellWithQuotes()
		{
			table = p1.Parse( quoteT );
			
			Assert.AreEqual(2, table.Count );
			Assert.AreEqual(2, table[0].Count );
			Assert.AreEqual(2, table[1].Count );
			
			Assert.AreEqual("c11", table[0][0] );
			Assert.AreEqual("c12", table[0][1] );
			Assert.AreEqual("c21", table[1][0] );
			Assert.AreEqual("\"cell;\"", table[1][1]);
		}
		
		[Test]
		public void CellWithQuotesAndMultiline()
		{
			table = p1.Parse( multiLineT );
			
			Assert.AreEqual(2, table.Count );
			Assert.AreEqual(2, table[0].Count );
			Assert.AreEqual(2, table[1].Count );
			
			Assert.AreEqual("c11", table[0][0] );
			Assert.AreEqual("c12", table[0][1] );
			Assert.AreEqual("c21", table[1][0] );
			Assert.AreEqual("\" na konci řádku  další řádek \"", table[1][1]);
		}
	}
}


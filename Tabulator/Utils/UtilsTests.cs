using System;
using System.Text;
using NUnit.Framework;
using Tabulator.Utils;

namespace Tabulator.Utils
{
	[TestFixture]
	public class UtilsTests
	{
		[Test]
		public void Trim0() {
			string[] strings = {
				"",
				" ",
				"  ",
				"    ",
			};
			
			foreach( string s in strings )
				Assert.AreEqual( s.Trim(), strings[0] );
		}
		
		[Test]
		public void Trim1() {
			string[] strings = {
				"ahoj", 
				" ahoj  ", 
				"     ahoj", 
				"ahoj ",
				" ahoj " };
			
			foreach( string s in strings )
				Assert.AreEqual( s.Trim(), strings[0] );
		}
		
		[Test]
		public void TextWithSpaceInMiddle()
		{
			string[] strings = {
				"Hello world", 
				" Hello world  ", 
				"     Hello world", 
				"Hello world ", 
				" Hello world ",	};
			
			foreach( string s in strings )
				Assert.AreEqual( s.Trim(), strings[0] );
		}

		[Test]
		public void LineTrim()
		{
			StringBuilder sb = new StringBuilder();
			string[] strings = {"abcd",
								"abcd ",
								"abcd  ",
								"abcd    ",
								"abcd\t",
								"abcd\n",
								"abcd \n",
								"abcd \n ",
								"abcd \t \t \n "};
			foreach( string s in strings) {
				sb.Clear();
				sb.Append( s );
				Assert.AreEqual( strings[0], sb.TrimLineEnd().ToString(), "" );
			}
		}
	}
}


using System;
using NUnit.Framework;

namespace Tabulator.Parsers
{
	[TestFixture]
	public class xmlParserTests
	{
		[Test]
		public void basicTable()
		{
			var p1 = new xmlParser();
			var t = p1.Parse( "<table>" +
				"<tr>" +
				"<td>c 11</td><td>c 12</td>" +
				"</tr>" +
			    "<tr>" +
				"<td>c 21</td><td>c 22</td>" +
				"</tr>" +
				"</table>" );
			
			Assert.AreEqual( 2, t.Count );
			Assert.AreEqual( 2, t[0].Count );
			Assert.AreEqual( 2, t[1].Count );
			
			Assert.AreEqual( false, t[0].Head );
			Assert.AreEqual( false, t[1].Head );
			
			Assert.AreEqual( false, t[0].Foot );
			Assert.AreEqual( false, t[1].Foot );
			
			Assert.AreEqual( "c 11", t[0][0] );
			Assert.AreEqual( "c 12", t[0][1] );
			Assert.AreEqual( "c 21", t[1][0] );
			Assert.AreEqual( "c 22", t[1][1] );
		}
	
		[Test]
		public void TableWithHeader()
		{
			var p1 = new xmlParser();
			var t = p1.Parse( "<table>" +
			    "<thead>" +
				"<tr>" +
				"<td>c 11</td><td>c 12</td>" +
				"</tr>" +
			    "</thead>" +
			    "<tbody>" +
			    "<tr>" +
				"<td>c 21</td><td>c 22</td>" +
				"</tr>" +
				"</tbody>" +
				"</table>" );
			
			Assert.AreEqual( 2, t.Count );
			Assert.AreEqual( 2, t[0].Count );
			Assert.AreEqual( 2, t[1].Count );
			
			Assert.AreEqual( true, t[0].Head );
			Assert.AreEqual( false, t[1].Head );
			
			Assert.AreEqual( false, t[0].Foot );
			Assert.AreEqual( false, t[1].Foot );
			
			Assert.AreEqual( "c 11", t[0][0] );
			Assert.AreEqual( "c 12", t[0][1] );
			Assert.AreEqual( "c 21", t[1][0] );
			Assert.AreEqual( "c 22", t[1][1] );
		}
	}
}


using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tabulator.Core
{
	[TestFixture]
	public class TableTests
	{
		[Test]
		public void ConstructorTest()
		{
			List<Line> matrix = new List<Line>();
			string[] strings = {
				"cell 11",	
				"cell 12",
				"cell 21",
				"cell 22",
			};
			
			matrix.Add( new Line() );
			matrix[0].Add( strings[0] );
			matrix[0].Add( strings[1] );
			matrix.Add( new Line() );
			matrix[1].Add( strings[2] );
			matrix[1].Add( strings[3] );
			
			Assert.AreEqual( strings[0], matrix[0][0] );
			Assert.AreEqual( strings[1], matrix[0][1] );
			Assert.AreEqual( strings[2], matrix[1][0] );
			Assert.AreEqual( strings[3], matrix[1][1] );
			
			Table table = new Table( matrix );
			
			Assert.AreEqual( strings[0], table[0][0] );
			Assert.AreEqual( strings[1], table[0][1] );
			Assert.AreEqual( strings[2], table[1][0] );
			Assert.AreEqual( strings[3], table[1][1] );

		}
	}
}


using System;
using NUnit.Framework;

namespace Tabulator.Core
{
	[TestFixture]
	public class LineTests
	{
		[Test]
		public void ConstructoTest()
		{
			const string c1 = "cell 1";
			const string c2 = "cell 2";
			
			Line line = new Line();
			line.Add(c1);
			line.Add(c2);
		
			Assert.AreEqual(line.Count, 2 );
			
			Assert.AreEqual(line[0], c1);
			Assert.AreEqual(line[1], c2);
		}
	}
}


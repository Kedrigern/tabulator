using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Tabulator.Core;

namespace Tabulator.Parsers
{
	public abstract class Parser
	{		
		// basic options
		protected Options opt;

		// table core
		protected List< Line > newTable = new List< Line >(30);
	
		// counters
		protected int line;
		protected int cell;
		protected int index;
		protected int cellStart;
		protected string text;

		public abstract Table Parse( string tr);

		public Table Parse( TextReader tr) 
		{
			string text = tr.ReadToEnd();
			return Parse( text);	
		}
		
		protected void addCell(bool last = false)
		{
			cell++;
			int len = this.index - this.cellStart;
			StringBuilder sb;
			if( last ) {
				sb = new StringBuilder( text, cellStart, len+1 , len + 10);
			} else {
				sb = new StringBuilder( text, cellStart, len , len + 10);
			}
			cellStart = this.index + 1;
			
			sb = sb.Replace('\n', ' ').Replace("  ", " ");
			newTable[ line ].Add( sb.ToString().Trim() );
		}

		/// <summary>
		/// Adds cell to the counters logic and put data to internal structure
		/// </summary>
		/// <param name='content'>
		/// Content of cell
		/// </param>
		protected void addCell(string content)
		{
			this.cell++;
			this.newTable[ line ].Add( content.Trim() );
		}

		/// <summary>
		/// Adds line to the counters logic and prepare internal structure
		/// </summary>
		/// <param name='head'>
		/// is head (headings) line?.
		/// </param>
		protected void addLine(bool head = false)
		{
			this.line++;
			this.newTable.Add( new Line( head ) );
		}
	}
}
using System;
using System.Collections.Generic;
using Tabulator.Core;

namespace Tabulator.Parsers
{
	public class csvParser : Parser
	{
		public csvParser( Options opt = null ) 
		{
			if( opt == null )
				this.opt = MainClass.Options;
			else
				this.opt = opt;
		}
			
		public override Table Parse(string text)
		{
			this.text = text;
			this.index = -1;
			this.cell = -1;
			this.line = 0;
			this.cellStart = this.index +1;
			bool inText = false;
			bool backslash = false;
			
			this.newTable = new List<Line>();
			this.newTable.Add( new Line() );
			
			while( index < text.Length-1 ) {
				index++;

				if( text[ index ] == opt.TextLimitation ) {
					inText = ! inText;
					continue;
				}
				if( backslash ) {
					backslash = false;	
					continue;
				}
				if( text[ index ] == '\\' ) {
					backslash = true;
					continue;
				}
				if( inText ) continue;
				if( text[ index ] == '\n' ) {
					addCell();
					this.cellStart = index+1;
					addLine();
					continue;
				}
				if( text[ index ] == opt.Delimiter ) {
					addCell();					
					continue;
				}
			}
			addCell(true); // last cell close by end of stream
			
			return new Table( newTable );   
		}
	}
}
using System;
using System.Collections.Generic;

//TODO: all
namespace Tabulator.Parsers
{
//	public class LaTeXParser : Parser
//	{
//		public override Table2 Parse (string text)
//		{
//			throw new NotImplementedException ();
//			
//			this.text = text;
//			this.index = -1;
//			this.cell = -1;
//			this.line = 0;
//			this.cellStart = this.index +1;
//			bool inText = false;
//			bool backslash = false;
//			
//			this.newTable =  new List<Line>();
//			this.newTable.Add( new Line() );
//			
//			while( index < text.Length-1 ) {
//				index++;
//				if( backslash ) {
//					ProcessInstruction();
//					backslash = false;	
//					continue;
//				}
//				if( text[ index ] == '\\' ) {
//					backslash = true;
//					continue;
//				}
//				if( text[ index ] == '&' ) {
//					addCell();					
//					continue;
//				}
//			}
//			addCell(true); // last cell close by end of stream
//			
//			return new Table2( newTable );   
//		}
//		
//		private void ProcessInstruction() 
//		{
//			switch( text[ index ] ) {
//			case '\\':
//				ProcessEol();
//				break;
//			case 'b':
//				ProcessBegin();
//				break;
//			case 'e':
//				return;
//			case 'h':
//				index++;
//				ProcessHline();
//				break;
//			case 'm':
//				return;
//			default:
//				return;
//			}
//		}
//		
//		private void ProcessBegin() {
//			
//		}
//		
//		private void ProcessEnd() {
//			try {
//				if(	text [ index +0 ] == 'n' &&
//				   	text [ index +1 ] == 'd' &&
//				    text [ index +2 ] == '{' &&
//				   	text [ index +3 ] == 't' &&
//				   	text [ index +4 ] == 'a' &&
//				   	text [ index +5 ] == 'b' &&
//				   	text [ index +6 ] == 'l' &&
//				   	text [ index +7 ] == 'e' &&
//				   	text [ index +8 ] == '}' )
//				{	
//					index--;			// first '\' is not part of cell
//					addCell();
//				}
//			} catch (Exception e) {}
//			
//		}
//		
//		private void ProcessEol() {
//			index--;			// first '\' is not part of cell
//			addCell();	
//			index = index + 2;	// jump over "\\"
//			this.cellStart = index;
//			addLine();
//		}
//		
//		private void ProcessHline() {
//			try {
//				if(	text [ index +0 ] == 'l' &&
//				   	text [ index +1 ] == 'i' &&
//				   	text [ index +2 ] == 'n' &&
//				   	text [ index +3 ] == 'e' )
//				{
//					index = index +3;
//					// add special line
//					return;
//				}
//			} catch (Exception e) {}
//			return;	//nothing happend, just '\h' 
//		}
//		
//		enum instructions {
//			none,
//			begin,
//			end,
//			eol,
//			hline,
//			multicolumn,
//		}
//	}
}


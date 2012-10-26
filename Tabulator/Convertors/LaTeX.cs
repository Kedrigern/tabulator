using System;
using System.Text;
using Tabulator.Core;
using Tabulator.Utils;

namespace Tabulator.Convertor
{
	public class LaTeXConvertor : Convertor
	{
		const string lineDelimeter = "\\\\ \n";
		const char fieldDelimeter = '&';

		public LaTeXConvertor(Options opt = null) : base(opt) 
		{
			if( opt == null )
				opt = MainClass.Options;
		}

		public override string Convert ( Core.Table t )
		{
			if( t.Count < 1 || t[0].Count < 1 ) 
				throw new Exception("Empty table can not be converted.");
			
			this.buffer.Clear();
			this.optionalWidths = t.MaxWidths( this.options.MaxColWidth );
			
			if( t.Caption.Length > 0 ) {
				buffer.Append("\\caption{" + t.Caption + "}\n");
			}
			
			buffer.Append("\\begin{tabular}{|");
			foreach( string s in t[0] ) {
				buffer.Append(" c |");
			}
			buffer.Append("}\n");

			char[] toTrim = new char[] {' ', '\t', '\n', '&'};

			// main cyklus
			foreach( Line line in t )
			{
				if( line.isEmpty() ) continue;
				ConvertLine( line );
				buffer.TrimLineEnd( toTrim );		// remove last delimetr - &; butsometimes is important ?! TODO:
				buffer.Append( lineDelimeter );			// \\ \n
			}
			buffer.Append("\\end{tabular}\n");
			return buffer.ToString();
		}	
		
		private void ConvertLine( Core.Line line ) {
			int overrun = 0;
			
			// for all cells in line
			for(int i = 0; i < line.Count; i++) {
				
				if( overrun == 0 ) {
					buffer.Append( line[i].PadRight( this.optionalWidths[i] ) );
					buffer.Append( fieldDelimeter );
				}
				
				if( overrun < 0 ) throw new Exception("Not allowed state: overrun is negative");
				
				// we have overrun
				if( overrun > 0 ) {
					int content = this.optionalWidths[i] - line[i].Length;
					
					if( overrun + content <= this.optionalWidths[i] ) {
						buffer.Append( line[i].PadRight( this.optionalWidths[i] - overrun ) );
						buffer.Append( fieldDelimeter );
						overrun = 0;
					} else {
						buffer.Append( line[i] );
						buffer.Append( fieldDelimeter );
						overrun = this.optionalWidths[i] - (overrun + line[i].Length);
					}
				}
			}
		}
	}
}
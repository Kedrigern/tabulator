using System;
using System.Xml.Linq;
using Tabulator.Core;
using Tabulator.Utils;

namespace Tabulator.Convertor
{
	public class xhtmlConvertor : Convertor
	{
		const string fieldDelimeter = "</td><td>";

		public xhtmlConvertor ( Options opt = null ) : base( opt )	
		{
			if( opt == null )
				opt = MainClass.Options;
		}

		public override string Convert (Tabulator.Core.Table t)
		{
			this.optionalWidths = t.MaxWidths( this.options.MaxColWidth );
			buffer.Clear();

			buffer.AppendLine("<table>");
			buffer.AppendLine("<thead>");
			buffer.AppendLine("</thead>");

			buffer.AppendLine("<tbody>");
			foreach( Line l in t ) {
				if( l.isEmpty() ) continue;
				buffer.Append("<tr><td>");
				ConvertLine( l );
				buffer.TrimLineEnd();					// remove white spaces
				buffer.Remove( buffer.Length - 5, 4);	// remove last "<td>"
				buffer.AppendLine("</tr>" );
			}
			buffer.AppendLine("</tbody>");
			buffer.AppendLine("</table>");
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


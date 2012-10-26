using System;
using System.Xml.Linq;
using Tabulator.Core;
using Tabulator.Utils;

namespace Tabulator.Convertor
{
	public class xhtmlConvertor : Convertor
	{
		public xhtmlConvertor ( Options opt = null ) : base( opt )	
		{
			if( opt == null )
				opt = MainClass.Options;
			fieldDelimeter = "</td><td>";
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
	}
}


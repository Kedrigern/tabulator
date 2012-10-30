using System;
using System.Text;
using Tabulator.Core;
using Tabulator.Utils;

namespace Tabulator.Convertor
{
	public class LaTeXConvertor : Convertor
	{
		const string lineDelimeter = "\\\\ \n";

		public LaTeXConvertor(Options opt = null) : base(opt) 
		{
			if( opt == null )
				opt = MainClass.Options;
			fieldDelimeter = '&'.ToString();
			border = "\\hline";
		}

		public override string Convert ( Core.Table t )
		{
			BeforeConvert(t);
			
			if( t.Caption.Length > 0 ) {
				buffer.Append("\\caption{" + t.Caption + "}\n");
			}
			
			buffer.Append("\\begin{tabular}{|");
			foreach( string s in t[0] ) {
				buffer.Append(" c |");
			}
			buffer.Append("}\n");

			CreateBorderLine();

			char[] toTrim = new char[] {' ', '\t', '\n', '&'};

			// main cyklus
			foreach( Line line in t )
			{
				if( line.isEmpty() ) continue;
				ConvertLine( line );
				buffer.TrimLineEnd( toTrim );		// remove last delimetr - &; butsometimes is important ?! TODO:
				buffer.Append( lineDelimeter );			// \\ \n
			}
			
			CreateBorderLine();
			buffer.Append("\\end{tabular}\n");

			return buffer.ToString();
		}	
	}
}
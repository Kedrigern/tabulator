using System;
using Tabulator.Core;

namespace Tabulator.Convertor
{
	public class MarkDownConvertor : Convertor
	{	
		public MarkDownConvertor(Options opt = null) : base(opt) 
		{
			if( opt == null )
				opt = MainClass.Options;
			fieldDelimeter = "  ";
		}

		public override string Convert (Tabulator.Core.Table t)
		{
			BeforeConvert(t);
		
			CreateBorder();

			foreach( Line line in t )
			{
				if( line.isEmpty() ) continue;
				ConvertLine( line );
				buffer.AppendLine();
			}

			CreateBorder();

			if( t.Caption.Length > 0 ) {
				buffer.Append("Table: " + t.Caption + "}\n");
			}

			return buffer.ToString();
		}

		private void CreateBorder(char symbol = '-')
		{
			foreach( int i in optionalWidths )
			{
				buffer.Append( "".PadLeft( i, symbol) );
				buffer.Append( fieldDelimeter );
			}
			buffer.AppendLine();
		}
	}
}


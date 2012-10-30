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
		
			CreateBorderLine();

			foreach( Line line in t )
			{
				if( line.isEmpty() ) continue;
				ConvertLine( line );
				buffer.AppendLine();
			}

			CreateBorderLine();

			if( t.Caption.Length > 0 ) {
				buffer.Append("Table: " + t.Caption + "}\n");
			}

			return buffer.ToString();
		}
	}
}


using System;
using Tabulator.Core;

namespace Tabulator.Convertor
{
	public class csvConvertor : Convertor
	{
		public csvConvertor() {}

		public csvConvertor (Options opt = null) : base( opt )	
		{
			if( opt == null )
				opt = MainClass.Options;
			fieldDelimeter = opt.OutDelimiter.ToString();
		}

		public override string Convert (Tabulator.Core.Table t)
		{
			BeforeConvert(t);
			
			if( t.Caption.Length > 0 ) {
				Console.Error.WriteLine("Caption is not posible in csv format.");
			}

			foreach( Line line in t )
			{
				if( line.isEmpty() ) continue;
				ConvertLine( line );
				buffer.AppendLine();
			}

			return buffer.ToString();
		}
	}
}
using System;
using Tabulator.Core;

namespace Tabulator.Convertor
{
	public class csvConvertor : Convertor
	{
		char fieldDelimeter = ';';

		public csvConvertor() {}

		public csvConvertor (Options opt = null) : base( opt )	
		{
			if( opt == null )
				opt = MainClass.Options;
			fieldDelimeter = opt.OutDelimiter;
		}

		public override string Convert (Tabulator.Core.Table t)
		{
			if( t.Count < 1 || t[0].Count < 1 ) 
				throw new Exception("Empty table can not be converted.");
			
			this.buffer.Clear();
			this.optionalWidths = t.MaxWidths( this.options.MaxColWidth );
			
			if( t.Caption.Length > 0 ) {
				Console.WriteLine("Caption is not posible in csv format.");
			}

			foreach( Line line in t )
			{
				if( line.isEmpty() ) continue;
				ConvertLine( line );
				buffer.AppendLine();
			}

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


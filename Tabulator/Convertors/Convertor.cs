using System;
using System.Text;
using Tabulator.Core;

namespace Tabulator.Convertor
{
	public abstract class Convertor
	{
		public int MaxColumnWidth {
			get {
				return maxColumnWidth;
			}
			set {
				if( value > 0 ) 
					maxColumnWidth = value;
			}
		}
		protected int maxColumnWidth;
		protected int[] optionalWidths;
		protected string fieldDelimeter;
		protected string border;
		protected Options options;
		protected StringBuilder buffer;
	
		protected Convertor( Options opt = null)
		{
			if( opt == null )
				this.options = MainClass.Options;
			else 
				this.options = opt;
			this.maxColumnWidth = options.MaxColWidth;
			this.buffer = new StringBuilder();
		}
	
		public abstract string Convert( Table t );

		protected void BeforeConvert(Tabulator.Core.Table t)
		{
			if( t.Count < 1 || t[0].Count < 1 ) 
				throw new Exception("Empty table can not be converted.");
			
			this.buffer.Clear();
			this.optionalWidths = t.MaxWidths( this.options.MaxColWidth );
		}

		protected void ConvertLine( Core.Line line ) {
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

		/// <summary>
		/// Creates the border line, for example some separator or highlighted line
		/// </summary>
		protected void CreateBorderLine()
		{
			buffer.AppendLine( border );
		}

		/// <summary>
		/// Creates the border, for example some separator or highlighted line
		/// </summary>
		/// <param name='symbol'>
		/// Symbol used for line
		/// </param>
		protected void CreateBorderLine(char symbol = '-')
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
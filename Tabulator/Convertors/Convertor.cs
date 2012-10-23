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
		
	}
}
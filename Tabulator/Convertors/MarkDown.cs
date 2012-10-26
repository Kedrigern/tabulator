using System;

namespace Tabulator.Convertor
{
	public class MarkDownConvertor : Convertor
	{	
		public MarkDownConvertor(Options opt = null) : base(opt) 
		{
			if( opt == null )
				opt = MainClass.Options;
		}

		public override string Convert (Tabulator.Core.Table t)
		{
			BeforeConvert(t);
			          
			throw new System.NotImplementedException ();
		}
	}
}


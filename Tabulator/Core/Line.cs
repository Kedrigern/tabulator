using System;
using System.Text;
using System.Collections.Generic;

namespace Tabulator.Core
{
	public class Line : List<string>
	{
		public bool Head {
			get { return head; }
			set { if( !separator )
					this.head = value; }
		}
		public bool Foot {
			get { return foot; }	
			set { if( ! separator )
					this.foot = value; }
		}
		public bool Separator {
			get { return separator; }
			set { 	this.separator = true; 
					this.Clear();	}
		}
		
		private bool head = false;
		private bool foot = false;
		private bool separator = false;
		private SortedSet< Tuple<int, int> > multicolumn;
		
		public Line( bool head = false, SortedSet< Tuple<int, int> > multi = null ) : base ()
		{
			this.head = head;
			if( multi == null )
				this.multicolumn = new SortedSet<Tuple<int, int>>();
			else
				this.multicolumn = multi;
		}
		
		public bool HasRightOverun(int column) 
		{
			if( multicolumn.Contains(new Tuple<int, int>( column, column+1) ) )
				return true;
			else
				return false;
		}

		public bool isEmpty()
		{
			foreach(string s in this )
				if( s.Trim().Length > 0 ) return false;
			return true;
		}

		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder();
			foreach( string s in this ) {
				sb.Append(s);
				sb.Append(";");
			}
			sb.Remove( sb.Length -1, 1);
			return sb.ToString();
		}
	}	
}
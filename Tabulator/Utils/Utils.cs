using System;
using System.Text;

namespace Tabulator.Utils
{
	public static class Utils 
	{
		public static string ConcatArray( string[] input , object delimiter = null) 
		{
			StringBuilder sb = new StringBuilder( 300 );
			foreach( string s in input) {
				sb.Append(s);
				if( delimiter != null ) sb.Append((char) delimiter);
			}
			if( delimiter != null ) sb.Remove( sb.Length -1, 1);
			return sb.ToString();
		}
		
		public static string Trim( this string s) {
			if( string.IsNullOrEmpty( s ) ) return s;
			
			StringBuilder sb = new StringBuilder( s );
			int i = 0;
			while( char.IsWhiteSpace( sb[i] ) ) i++;
			sb.Remove(0,i);
			
			i = sb.Length -1;
			while( char.IsWhiteSpace( sb[i] ) ) i--;
			sb.Remove(i, sb.Length - i);
			
			return sb.ToString();
		}
		
		public static string TrimQuotes(this string s) {
			if( string.IsNullOrEmpty( s ) ) return s;
			
			StringBuilder sb = new StringBuilder( s );
			
			if( sb[0] == sb[sb.Length - 1] ) 
			switch( sb[0] ) {
			case '"':
			case '\'':
				switch( sb[ sb.Length -1 ] ) {
					case '"':
					case '\'':	
					sb.Remove(0,1);
					sb.Remove(sb.Length -1, 1);
					break;
				}
				break;
			}
			return sb.ToString();
		}

		public static StringBuilder TrimLineEnd( this StringBuilder sb, char[] chars = null  )
		{
			if( chars == null ) chars = new char[] {' ', '\n', '\t'};

			int i = sb.Length -1; // last symbol

			try {
				while( chars.Contains( sb[i] ) ) i--;
			} catch( IndexOutOfRangeException ) {
				return sb.Clear();	
			}
			i++;	

			sb.Remove(i, sb.Length - i );

			return sb;
		}

		private static bool Contains(this char[] symbols, char c)
		{
			foreach( char d in symbols) {
				if( d == c ) return true;
			}
			return false;
		}
	}
}
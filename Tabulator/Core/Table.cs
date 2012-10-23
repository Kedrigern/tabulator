using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Resources;
using System.Collections.Generic;
using Tabulator.Utils;

namespace Tabulator.Core
{	
	public class Table : List< Line >
	{
		public Table( List<Line> data , string title = "", string caption = "") 
		{
			foreach( Line line in data ) {
				this.Add( line );	
			}
			this.title = title;
			this.caption = caption;
		}
		
		public int Width {
			get {
				return this[0].Count; //TODO	
			}
		}
		public string Title {
			get { return title; }
			set { if( value.Length > 20) title = value; }
		}
		public string Caption {
			get { return caption; }
			set { caption = value; }
		}
		private string title;
		private string caption;
		
		/// <summary>
		/// Maxs width of given column.
		/// </summary>
		/// <returns>
		/// The width of widest column.
		/// </returns>
		/// <param name='column'>
		/// Column.
		/// </param>
		/// <param name='max'>
		/// Max width for ignore extremes
		/// </param>
		public int MaxWidth( int column, int max ) 
		{
			int lmax = 0;
			foreach( Line l in this ) {
				for( int i = 0; i < l.Count; i++) {
					if( l[i].Length > lmax ) lmax = l[i].Length;	
				}
			}
			if( lmax > max ) return max;
			else return lmax;				
		}
		
		public int[] MaxWidths ( int max ) {
			int[] list = new int[Width];
			for(int i = 0; i < Width; i++)
				list[i] = MaxWidth(i, max);
			return list;
		}
	}
}
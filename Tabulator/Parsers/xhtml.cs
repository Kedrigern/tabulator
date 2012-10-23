using System;
using System.Xml.Linq;
using System.Collections.Generic;
using Tabulator.Core;

namespace Tabulator.Parsers
{
	public class xmlParser : Parser
	{	
		public override Table Parse (string inputText)
		{			
			XElement root;
			try {
				root = XElement.Parse( inputText );
			} catch ( Exception e) {
				Console.WriteLine("During parsing of System.Xml.Linq.XElement throw: {0}.", e.Message);
				Environment.Exit(1);
			}

			this.newTable = new List<Line>();
			this.line = -1;
			this.cell = -1;
			bool head = false;
			
			foreach( var e in root.Descendants() ) {
				switch( e.Name.LocalName ) {
				case "tr":
					this.addLine( head );
					break;
				case "td":
				case "th":
					this.addCell( e.Value );
					break;
				case "thead":
					head = true;
					break;
				case "tbody":
					head = false;
					break;
				default:
					throw new Exception("Unknow element");					
				}
			}
			
			return new Table( newTable );
		}
	}
}


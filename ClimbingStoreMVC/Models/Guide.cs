using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClimbingStoreMVC.Models {
	public class Guide {
		public int Id { get; set; }
		public string Name { get; set; }
		public int YrsExp { get; set; }
		public int PartyId { get; set; }
		public virtual Party Party { get; set; }

		public Guide() {
			
		}
	}
}
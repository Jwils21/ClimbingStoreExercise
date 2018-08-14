using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClimbingStoreMVC.Models {
	public class Party {
		public int Id { get; set; }
		public string PartyName { get; set; }
		public int Days { get; set; }
		public bool Finished { get; set; }

		public Party() {

		}
	}
}
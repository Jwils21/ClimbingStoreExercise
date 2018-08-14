using ClimbingStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClimbingStoreMVC.ViewModels {
	public class GuidesForParties {
		public Party Party { get; set; }
		public IEnumerable<Guide> Guides { get; set; }
	}
}
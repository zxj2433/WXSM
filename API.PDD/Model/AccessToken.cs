using System;
using System.Collections.Generic;
using System.Text;

namespace API.PDD.Model
{
	public class AccessToken
	{
		public List<string> scope { get; set; }
		public string access_token { get; set; }
		public int expires_in { get; set; }
		public string refresh_token { get; set; }
		public string owner_id { get; set; }
		public string owner_name { get; set; }
	}
}

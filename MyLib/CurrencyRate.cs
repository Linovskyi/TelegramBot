using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace MyLib
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class CurrencyRate
	{
		//"r030":36,"txt":"Австралійський долар","rate":21.6395,"cc":"AUD","exchangedate":"17.02.2021"

		[JsonProperty(PropertyName = "r030")]
		public int r030 { get; set; }

		[JsonProperty(PropertyName = "txt")]
		public string txt { get; set; }

		[JsonProperty(PropertyName = "rate")]
		public float rate { get; set; }

		[JsonProperty(PropertyName = "cc")]
		public string cc { get; set; }

		[JsonProperty(PropertyName = "exchangedate")]
		public string exchangedate { get; set; }

		public string[] ToStringArray()
		{
			string[] arr = new String[] { r030.ToString(), txt, rate.ToString(), cc };
			return arr;
		}
	}
}

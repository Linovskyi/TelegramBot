using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace MyLib
{
	public class CurrencyRateNbu
	{
		//"r030":36,"txt":"Австралійський долар","rate":21.6395,"cc":"AUD","exchangedate":"17.02.2021"

		public int r030 { get; set; }
		public string txt { get; set; }
		public float rate { get; set; }
		public string cc { get; set; }
		public string exchangedate { get; set; }

		public string[] ToStringArray()
		{
			string[] arr = new String[] { r030.ToString(), txt, rate.ToString(), cc };
			return arr;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HealthMonitoring.Presentation.WebApp.Models
{
	[DataContract]
	public class DataPoint
	{
		[DataMember(Name = "label")]
		public string Label { get; set; }
		[DataMember(Name = "y")]
		public double Y { get; set; }

		public DataPoint(string label, double y)
		{
			this.Label = label;
			this.Y = y;
		}
	}
}

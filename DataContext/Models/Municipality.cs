using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContextNamespace.Models
{
	[DataContract]
	public class Municipality
	{
		[Key]
		[DataMember]
		public Int32 ID { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public City City { get; set; }
		[DataMember]
		public Country Country { get; set; }
	}
}

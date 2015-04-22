using System;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Logistics.Domain.Model
{
	public class Address
	{	
		public virtual string City { get; set; }

		public virtual string Street { get; set; }

		[RegexValidator(@"\d{2}.\d{3}")]
		public virtual string PostalCode { get; set; }

		public virtual int HouseNumber { get; set; }
	}
}
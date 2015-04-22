using System;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Logistics.Domain.Model
{
	public class Order
	{
		public virtual int Id { get; protected set; }

		[NotNullValidator]
		public virtual Address Address { get; set; }
		public virtual Payment Payment { get; set; }
		public virtual Status Status { get; set; }
		public virtual DateTime UpdatedAt { get; set; }
		public virtual User UpdatedBy { get; set; }

		public virtual DateTime DeliveryDateTime { get; set; }

		[RangeValidator(0, RangeBoundaryType.Inclusive, 3, RangeBoundaryType.Inclusive)]
		public virtual int Priority { get; set; }

		public virtual User Client { get; set; }
		public virtual User Driver { get; set; }
	}
}


using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Logistics.Domain.Model.Entities.Order
{
	public class Payment
	{
		[TypeConversionValidator(typeof(double))]

		public virtual double Value { get; set; }
		public virtual Currency Currency { get; set; }
	}
}


using ParcelDelivery.Models.Interfaces;

namespace ParcelDelivery.Business.Interfaces
{
	public interface IDepartmentChain
	{
		void SetNext(IDepartmentChain nextInChain);
		IParcel Process(IParcel parcelInstance);
	}
}
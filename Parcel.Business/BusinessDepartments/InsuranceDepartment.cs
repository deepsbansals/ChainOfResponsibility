using ParcelDelivery.Business.Interfaces;
using ParcelDelivery.Models.Interfaces;

namespace ParcelDelivery.Business.BusinessDepartments
{
	public class InsuranceDepartment : IDepartmentChain
	{
	    private IDepartmentChain _nextInChain;

	    public void SetNext(IDepartmentChain c)
	    {
		    _nextInChain = c;
	    }

	    public IParcel Process(IParcel parcelInstance)
	    {
		    if (parcelInstance.Value > 1000)
			    parcelInstance.NeedSignOff = true;

		    _nextInChain.Process(parcelInstance);

		    return parcelInstance;
	    }
	}
}

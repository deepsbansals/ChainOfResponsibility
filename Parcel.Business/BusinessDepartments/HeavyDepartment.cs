using ParcelDelivery.Business.Interfaces;
using ParcelDelivery.Models.Interfaces;

namespace ParcelDelivery.Business.BusinessDepartments
{
	public class HeavyDepartment : IDepartmentChain
	{
	    private IDepartmentChain _nextInChain;

	    public void SetNext(IDepartmentChain c)
	    {
		    _nextInChain = c;
	    }

	    public IParcel Process(IParcel parcelInstance)
	    {
		    if (parcelInstance.Weight > 10)
			    parcelInstance.Department = Models.Departments.Heavy;
		    else
			    _nextInChain.Process(parcelInstance);

		    return parcelInstance;
	    }
	}
}

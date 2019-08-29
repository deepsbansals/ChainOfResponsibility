using ParcelDelivery.Business.Interfaces;
using ParcelDelivery.Models.Interfaces;

namespace ParcelDelivery.Business.BusinessDepartments
{
	public class RegularDepartment : IDepartmentChain
	{
	    private IDepartmentChain _nextInChain;

	    public void SetNext(IDepartmentChain c)
	    {
		    _nextInChain = c;
	    }

	    public IParcel Process(IParcel parcelInstance)
	    {
		    if (parcelInstance.Weight > 1 && parcelInstance.Weight <= 10)
			    parcelInstance.Department = Models.Departments.Regular;
		    else
			    _nextInChain.Process(parcelInstance);

		    return parcelInstance;
	    }
	}
}

using ParcelDelivery.Business.BusinessDepartments;
using ParcelDelivery.Business.Interfaces;
using ParcelDelivery.Models.Interfaces;

namespace ParcelDelivery.Business
{
	public class BuildParcelChain : IParcelLogic
	{
		private readonly IDepartmentChain _rootChain;

		public BuildParcelChain()
	    {
		    _rootChain = new InsuranceDepartment();
			IDepartmentChain dep2 = new MailDepartment();
			IDepartmentChain dep3 = new RegularDepartment();
			IDepartmentChain dep4 = new HeavyDepartment();

			_rootChain.SetNext(dep2);
			dep2.SetNext(dep3);
			dep3.SetNext(dep4);
		}

        public IDepartmentChain GetChain()
        {
			return _rootChain;
        }
    }
}
using ParcelDelivery.Models.Interfaces;

namespace ParcelDelivery.Business.Interfaces
{
    public interface IParcelLogic
    {
	    IDepartmentChain GetChain();
    }
}

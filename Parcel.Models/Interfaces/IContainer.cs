namespace ParcelDelivery.Models.Interfaces
{
    public interface IContainer
    {
        Parcel[] parcels { get; set; }
    }
}

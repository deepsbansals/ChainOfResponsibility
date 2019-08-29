namespace ParcelDelivery.Models.Interfaces
{
    public interface IParcel
    {
        bool NeedSignOff { get; set; }
        Departments Department { get; set; }
        decimal Weight { get; set; }
        decimal Value { get; set; }
        T_Sender Sender { get; set; }
        Receipient Receipient { get; set; }
    }
}

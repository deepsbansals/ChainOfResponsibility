using ParcelDelivery.Business;
using ParcelDelivery.Business.Interfaces;
using ParcelDelivery.Models;
using ParcelDelivery.Models.Interfaces;
using System;
using System.IO;
using System.Reflection;
using Unity;

namespace ParcelDelivery.Application
{
	public class Program
    {
        static IContainer _containerInstance;
        static IParcelLogic _parcelLogicInstance;

        static void Main()
        {
            var container = new UnityContainer();
            RegisterComponents(container);

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), "SampleFile//Container_68465468.xml");

            var xmlfile = File.ReadAllText(path);
            var serializer = new Serializer();
            _containerInstance = serializer.Deserialize<Container>(xmlfile);

            var departmentChain = _parcelLogicInstance.GetChain();

			foreach (var parcel in _containerInstance.parcels)
            {
	            departmentChain.Process(parcel);
				Console.WriteLine($"Department : {parcel.Department}");
                Console.WriteLine($"Insurance Sign-off Required? : {parcel.NeedSignOff}");
                Console.WriteLine($"Sender : {parcel.Sender.Name}");
                Console.WriteLine($"Receiver : {parcel.Receipient.Name}");
                Console.WriteLine($"Weight : {parcel.Weight}");
                Console.WriteLine($"Value : {parcel.Value}");
                Console.WriteLine("-------------------------------");
            }

            Console.ReadLine();
        }

        #region Register Compnents with IOC
        private static void RegisterComponents(UnityContainer container)
        {
            container.RegisterType<IContainer, Container>();
            container.RegisterType<IParcelLogic, BuildParcelChain>();

            _containerInstance = container.Resolve<IContainer>();
            _parcelLogicInstance = container.Resolve<IParcelLogic>();
        }
        #endregion
    }
}

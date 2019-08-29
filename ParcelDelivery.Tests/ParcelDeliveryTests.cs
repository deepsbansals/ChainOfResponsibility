using Moq;
using NUnit.Framework;
using ParcelDelivery.Business;
using ParcelDelivery.Business.BusinessDepartments;
using ParcelDelivery.Business.Interfaces;
using ParcelDelivery.Models;
using ParcelDelivery.Models.Interfaces;
using ParcelDelivery.Tests.Properties;
using System.Collections.Generic;

namespace ParcelDelivery.Tests
{
    [TestFixture()]
    public class ParcelDeliveryTests
    {
        Mock<IDepartments> _mockDepartments;
        Mock<IContainer> _mockContainer;
        Mock<IAssignDepartment> _mockAssignDept;
        Mock<IParcel> _mockParcel;
        Mock<IParcelLogics> _parcelLogicInstance;

        Serializer serializer = null;

        string Data = string.Empty;


        [SetUp]
        public void SetupTests()
        {
            Data = Resources.ParcelSample;
            _mockContainer = new Mock<IContainer>();

            serializer = new Serializer();
            _mockAssignDept = new Mock<IAssignDepartment>();
            _mockDepartments = new Mock<IDepartments>();
            _mockParcel = new Mock<IParcel>();
            _parcelLogicInstance = new Mock<IParcelLogics>();
            _parcelLogicInstance.Setup(r => r.SetDepartmentInstance(_mockAssignDept.Object, _mockParcel.Object));
            _mockParcel.Setup(h => h.NeedSignOff).Returns(false);
        }

        [Test]
        public void TestFileSerialization()
        {
            var data = serializer.Deserialize<Container>(Data);
            Assert.IsNotNull(data);
            Assert.AreEqual(68465468, data.Id);
            Assert.AreEqual(4, data.parcels.Length);
        }

        [TestCase(".5", "0", ExpectedResult = typeof(MailDepartment))]
        [TestCase("5", "100", ExpectedResult = typeof(RegularDepartment))]
        [TestCase("15", "300", ExpectedResult = typeof(HeavyDepartment))]
        [TestCase("0", "0", ExpectedResult = typeof(MailDepartment))]
        [TestCase(".02", "500", ExpectedResult = typeof(MailDepartment))]
        [TestCase("3.0", "100", ExpectedResult = typeof(RegularDepartment))]
        [TestCase("11", "80", ExpectedResult = typeof(HeavyDepartment))]
        [TestCase("1", "1100", ExpectedResult = typeof(InsuranceDepartment))]
        public object Call_AssignDept_And_Check_Proper_Objects_Are_Created_Using_Weight(decimal WeightValue, decimal Value)
        {
            _mockParcel.Setup(f => f.Weight).Returns(WeightValue);
            _mockParcel.Setup(f => f.Value).Returns(Value);
            ParcelAssignmentLogics logic = new ParcelAssignmentLogics();
            return logic.AssignDept(_mockParcel.Object).GetType();
        }
    }
}

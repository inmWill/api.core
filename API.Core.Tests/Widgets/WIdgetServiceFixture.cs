using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Widgets;
using DomainWidget = API.Core.Domain.Models.Widgets.Widget;
using API.Core.Service.Services;
using API.Core.Utils.Automapper.AutoMapper;
using Moq;
using NUnit.Framework;


namespace API.Core.Tests.Widgets
{
    [TestFixture]
    public class WhenGetIsCalled
    {

        [SetUp]
        public void Setup()
        {
            AutoMapperConfig.CreateMap<API.Core.Domain.Models.Widgets.Widget, API.Core.Repository.Models.Widgets.Widget>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Widgets.Widget, API.Core.Domain.Models.Widgets.Widget>();
        }

        [Test]
        public void TheWidgetShouldBeReturned()
        {
            //Arrange
            List<DomainWidget> values = new List<DomainWidget>
            {
                new DomainWidget
                {
                    Name = "Test Widget",
                    Description = "A test widget",
                    Manufacturer = "Radix2"
                },
                new DomainWidget
                {
                    Name = "Second Widget",
                    Description = "A second widget",
                    Manufacturer = "Radix2"
                }

            };
            IQueryable<DomainWidget> valuesQueryable = values.AsQueryable();

            var mockRepository = new Mock<IRepository>();
            mockRepository
                .Setup(x => x.All<DomainWidget>(It.IsAny<String[]>()))
                .Returns(()=> valuesQueryable);

            var widgetService = new WidgetService(mockRepository.Object);

            //Act
            var widgets = widgetService.Get();

            //Assert
            Assert.IsInstanceOf<List<DomainWidget>>(widgets);
        }

    }

    [TestFixture]
    public class WhenPostIsCalled
    {

        [SetUp]
        public void Setup()
        {
            AutoMapperConfig.CreateMap<API.Core.Domain.Models.Widgets.Widget, API.Core.Repository.Models.Widgets.Widget>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Widgets.Widget, API.Core.Domain.Models.Widgets.Widget>();
        }

        [Test]
        public void TheWidgetShouldBePersisted()
        {
            //Arrange
            var value = new DomainWidget
            {
                Name = "Test Widget",
                Description = "A test widget",
                Manufacturer = "Radix2"
            };
            var mockRepository = new Mock<IRepository>();
            mockRepository
                .Setup(x => x.Create(It.IsAny<Widget>()));

            var widgetService = new WidgetService(mockRepository.Object);

            //Act
            widgetService.Post(value);

            //Assert
            mockRepository.Verify(v=>v.Create(It.IsAny<Widget>()));
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void TheServiceShouldThrowAnExceptionIfWidgetModelIsNotValid()
        {
            //Arrange
            var mockRepository = new Mock<IRepository>();
            mockRepository
                .Setup(x => x.Create(It.IsAny<Widget>()))
                .Throws(new Exception());

            var mockWidgetService = new WidgetService(mockRepository.Object);

            //Act
            mockWidgetService.Post(new Domain.Models.Widgets.Widget());

            //Assert

        }
    }
}

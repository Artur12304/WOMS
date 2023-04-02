using System.Runtime.Serialization;
using AutoMapper;
using NUnit.Framework;
using RestApi.Application.Carts.Model;
using RestApi.Application.Clients.Model;
using RestApi.Application.Common.Mappings;
using RestApi.Application.Orders.Model;
using RestApi.Application.Products.Model;
using RestApi.Domain.Entities;

namespace RestApi.Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config =>
            config.AddProfile<MappingProfile>());

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(Cart), typeof(CartDto))]
    [TestCase(typeof(Order), typeof(OrderDto))]
    [TestCase(typeof(Client), typeof(ClientDto))]
    [TestCase(typeof(Product), typeof(ProductDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        return FormatterServices.GetUninitializedObject(type);
    }
}

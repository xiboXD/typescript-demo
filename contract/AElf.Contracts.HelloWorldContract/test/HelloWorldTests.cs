using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Shouldly;
using Xunit;
using System;
using AElf.Sdk.CSharp;

namespace AElf.Contracts.HelloWorld
{
    // This class is unit test class, and it inherit TestBase. Write your unit test code inside it.
    public class HelloWorldTests : TestBase
    {
        [Fact]
        public async Task Update_ShouldUpdateMessageAndFireEvent()
        {
            // Arrange
            var inputValue = "Hello, World!";
            var input = new StringValue { Value = inputValue };

            // Act
            await HelloWorldStub.Update.SendAsync(input);

            // Assert
            var updatedMessage = await HelloWorldStub.Read.CallAsync(new Empty());
            updatedMessage.Value.ShouldBe(inputValue);
        }
        
        [Fact]
        public async Task Rng_Test()
        {
            await HelloWorldStub.Initialize.SendAsync(new Empty());
            var result = await HelloWorldStub.CreateCharacter.SendAsync(new Empty());
            var character = await HelloWorldStub.GetMyCharacter.CallAsync(new Empty());
            
            Assert.NotEqual(new Character(), character);
            Assert.Equal(result.Output, character);
        }
    }
    
}
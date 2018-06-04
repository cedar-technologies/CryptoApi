using Moq;

namespace CryptoSharp.Tests.Client.Clients
{
    public interface IClientContext<T> where T : class
    {

        Mock<T> GetClient();

    }
}
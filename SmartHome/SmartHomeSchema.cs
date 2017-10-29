using GraphQL;
using GraphQL.Types;

namespace SmartHome
{
    public class SmartHomeSchema : Schema
    {
        public SmartHomeSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<SmartHomeQuery>();
            Mutation = resolver.Resolve<SmartHomeMutation>();
        }
    }
}
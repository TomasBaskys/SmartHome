using GraphQL.Types;
using SmartHome.Types;

namespace SmartHome
{
    public class SmartHomeQuery : ObjectGraphType<object>
    {
        public SmartHomeQuery(SmartHomeData data)
        {
            Name = "Query";

            Field<LaptopType>(
                "laptop",
                resolve: context => data.GetLaptop()
            );

            Field<LightsType>(
                "lights",
                resolve: context => data.GetLights()
            );
        }
    }
}
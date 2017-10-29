using GraphQL.Types;
using SmartHome.Types;

namespace SmartHome
{
    public class SmartHomeMutation : ObjectGraphType<object>
    {
        public SmartHomeMutation(SmartHomeData data)
        {
            Name = "Mutation";

            Field<LaptopType>(
                "updateLaptop",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<LaptopInputType>> { Name = "laptop" }
                ),
                resolve: context =>
                {
                    var laptop = context.GetArgument<Laptop>("laptop");

                    return data.UpdateLaptop(laptop);
                });

            Field<LightsType>(
                "updateLights",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<LightsInputType>> { Name = "lights" }
                ),
                resolve: context =>
                {
                    var lights = context.GetArgument<Lights>("lights");

                    return data.UpdateLights(lights);
                });
        }
    }
}
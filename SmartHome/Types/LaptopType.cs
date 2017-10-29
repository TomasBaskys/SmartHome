using GraphQL.Types;

namespace SmartHome.Types
{
    public class LaptopType : ObjectGraphType<Laptop>
    {
        public LaptopType()
        {
            Name = "Laptop";

            Field<LaptopStateEnum>("state");
            Field(d => d.Music, nullable: true);
        }
    }

    public class LaptopInputType : InputObjectGraphType
    {
        public LaptopInputType()
        {
            Name = "LaptopInput";

            Field<LaptopStateEnum>("state");
            Field<StringGraphType>("Music");
        }
    }

    public class Laptop : ElectronicDevice
    {
        public LaptopState State { get; set; }

        public string Music { get; set; }
    }

    public class LaptopStateEnum : EnumerationGraphType<LaptopState>
    {
        public LaptopStateEnum()
        {
            Name = "LaptopState";

            AddValue(new EnumValueDefinition {Value = "On"});
            AddValue(new EnumValueDefinition {Value = "Off" });
            AddValue(new EnumValueDefinition {Value = "TurningOn" });
            AddValue(new EnumValueDefinition {Value = "TurningOff" });
            AddValue(new EnumValueDefinition {Value = "Restarting" });
            AddValue(new EnumValueDefinition {Value = "Sleeping" });
        }
    }

    public enum LaptopState
    {
        On,
        Off,
        TurningOn,
        TurningOff,
        Restarting,
        Sleeping
    }
}
using GraphQL.Types;

namespace SmartHome.Types
{
    public class LightsType : ObjectGraphType<Lights>
    {
        public LightsType()
        {
            Name = "Lights";

            Field<LightsStateEnum>("state");
            Field<LightsModeEnum>("mode");
            Field(d => d.RGB, nullable: true);
        }
    }
    public class LightsInputType : InputObjectGraphType
    {
        public LightsInputType()
        {
            Name = "LightsInput";

            Field<LightsStateEnum>("state");
            Field<LightsModeEnum>("mode");
            Field<StringGraphType>("RGB");
        }
    }

    public class Lights : ElectronicDevice
    {
        public LightsState State { get; set; }

        public LightsMode Mode { get; set; }

        public string RGB { get; set; }
    }

    public class LightsStateEnum : EnumerationGraphType<LightsState>
    {
        public LightsStateEnum()
        {
            Name = "LightsState";

            AddValue(new EnumValueDefinition { Value = "On" });
            AddValue(new EnumValueDefinition { Value = "Off" });
        }
    }

    public class LightsModeEnum : EnumerationGraphType<LightsMode>
    {
        public LightsModeEnum()
        {
            Name = "LightsMode";

            AddValue(new EnumValueDefinition { Value = "Static" });
            AddValue(new EnumValueDefinition { Value = "Music" });
            AddValue(new EnumValueDefinition { Value = "Romantic" });
            AddValue(new EnumValueDefinition { Value = "Work" });
            AddValue(new EnumValueDefinition { Value = "Custom" });
        }
    }

    public enum LightsState
    {
        On,
        Off
    }

    public enum LightsMode
    {
        Static,
        Music,
        Romantic,
        Work,
        Custom
    }
}
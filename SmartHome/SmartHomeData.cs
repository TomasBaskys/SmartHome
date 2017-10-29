using SmartHome.Types;

namespace SmartHome
{
    public class SmartHomeData
    {
        private Laptop _laptop;
        private Lights _lights;

        public SmartHomeData()
        {
            _laptop = new Laptop
            {
                Id = "laptop",
                Name = "HP Envy-17",
                Description = "Personal computer",
                State = LaptopState.On,
                Music = "Radistai - Coming Home"
            };

            _lights = new Lights
            {
                Id = "lights",
                Name = "LEDs Strip",
                Description = "5M RGB 5050 300LEDs Waterproof Strip Light",
                State = LightsState.On,
                Mode = LightsMode.Static,
                RGB = "255,255,255"
            };
        }

        public Laptop GetLaptop()
        {
            return _laptop;
        }

        public Lights GetLights()
        {
            return _lights;
        }

        public Laptop UpdateLaptop(Laptop laptop)
        {
            _laptop = laptop;

            return _laptop;
        }

        public Lights UpdateLights(Lights lights)
        {
            _lights = lights;

            return _lights;
        }
    }
}
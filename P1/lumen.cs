// Type Definition Class Lumen

namespace lumenCS
{
    public class Lumen
    {
        // Class Invariants:
        // 1. size is always positive
        // 2. reset_threshold is always positive
        // 3. power_threshold is always non-negative
        // 4. dimming_value is always non-negative
        // 5. brightness_copy and power_copy store initial values of brightness and power, respectively

        private int brightness;
        private int size;
        private int power;
        private int glow_request;

        private int brightness_copy;
        private int power_copy;

        private int power_threshold;
        private int dimming_value;

        private const int reset_threshold = 1;
        private const int INACTIVE_STATE = 0;

        // Preconditions: input_brightness, input_size, and input_power are positive
        // Postconditions: Lumen object is created with given input values
        public Lumen(int input_brightness, int input_size, int input_power)
        {

            if (input_brightness <= 0 || input_size <= 0 || input_power <= 0)
            {
                throw new ArgumentOutOfRangeException("All input values for Lumen must be positive.");
            }


            brightness = input_brightness;
            size = input_size;
            power = input_power;

            brightness_copy = input_brightness;
            power_copy = input_power;

            glow_request = 0;
            dimming_value = (int)(brightness_copy * (10.0 / 100));
            power_threshold = (int)(power_copy * (20.0 / 100));

        }

        // Preconditions: None
        // Postconditions: Returns the glow value based on the state of the Lumen object
        public int glow()
        {
            glow_request++;
            power--;

            if (!isActive())
            {
                if (isErratic())
                {
                    return ErraticValue();
                }
                return dimming_value;
            }
            return brightness * size;
        }

        // Preconditions: None
        // Postconditions: Resets the Lumen object if conditions are met, otherwise reduces brightness by 1
        public void reset()
        {
            if (resetRequest())
            {
                power = power_copy;
                brightness = brightness_copy;
                glow_request = 0;
                return;
            }
            brightness--;
        }


        // Preconditions: The Lumen object is in an erratic state
        // Postconditions: Returns a non-negative value less than the current power
        private int ErraticValue()
        {
            int erraticFactor = 10; // erratic constant
            int erraticValue = brightness * size * (power + erraticFactor);
            return erraticValue;
        }

        // Preconditions: None
        // Postconditions: Returns true if the Lumen object is active, otherwise false
        public bool isActive()
        {
            return power > power_threshold;
        }

        // Preconditions: None
        // Postconditions: Returns true if the Lumen object is erratic, otherwise false
        private bool isErratic()
        {
            return power <= power_threshold && power > INACTIVE_STATE;
        }

        // Preconditions: None
        // Postconditions: Returns true if the reset request is valid, otherwise false
        private bool resetRequest()
        {
            return glow_request >= reset_threshold && power > INACTIVE_STATE;
        }
    }
}

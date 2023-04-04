using Microsoft.VisualStudio.TestTools.UnitTesting;
using lumenCS;

namespace lumenTest
{
    [TestClass]
    public class lumenTest
    {
        private Lumen lumen;

        [TestInitialize]
        public void Setup()
        {
            // Brightness, Size, Power
            lumen = new Lumen(10, 2, 50);
        }

        [TestMethod]
        public void Glow_ReturnsProductOfBrightnessAndSize_WhenActive()
        {
            int result = lumen.glow();
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Glow_ReturnsDimmingValue_WhenInactive()
        {
            for (int i = 0; i < 50; i++)
            {
                lumen.glow();
            }
            int result = lumen.glow();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Glow_ReturnsErraticValue_WhenUnstable()
        {
            for (int i = 0; i < 39; i++)
            {
                lumen.glow();
            }
            int result = lumen.glow();
            Assert.AreEqual(400, result);
        }

        [TestMethod]
        public void Reset_RestoresInitialValues_WhenValid()
        {
            for (int i = 0; i < 6; i++)
            {
                lumen.glow();
            }
            lumen.reset();
            int result = lumen.glow();
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Reset_DecreasesBrightness_WhenInvalid()
        {
            lumen.reset();
            int result = lumen.glow();
            Assert.AreEqual(18, result);
        }


        [TestMethod]
        public void IsActive_ReturnsTrue_WhenPowerIsAboveThreshold()
        {
            Lumen activeLumen = new Lumen(10, 2, 50);
            for (int i = 0; i < 4; i++)
            {
                activeLumen.glow();
            }
            bool result = activeLumen.isActive();
            Assert.IsTrue(result, "IsActive should return true when power is above the threshold.");
        }

        [TestMethod]
        public void IsActive_ReturnsFalse_WhenPowerIsBelowThreshold()
        {
            Lumen inactiveLumen = new Lumen(10, 2, 50);
            for (int i = 0; i < 40; i++)
            {
                inactiveLumen.glow();
            }
            bool result = inactiveLumen.isActive();
            Assert.IsFalse(result, "IsActive should return false when power is below the threshold.");
        }


    }
}

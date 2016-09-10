using core.Wrappers.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace core.tests
{
    public class SharedStaticSpecs : IDisposable
    {
        ApplicationSettingsManager SettingsManager = null;

        public SharedStaticSpecs()
        {
            SettingsManager = new ApplicationSettingsManager();
        }

        public void Dispose()
        {
            SettingsManager.Dispose();
            SettingsManager = null;
        }

        [Fact]
        public void StoreInstanceOfManagerAndInitialiseStaticStorage()
        {
            // Arrange
            
            Action act = () => { var r = ApplicationSettingsContainer.Settings; };

            // Act + Assert

            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void ApplicationSettingsCreatedOnCreate()
        {
            // Arrange

            var manager = new ApplicationSettingsManager();

            // Act

            manager.CreateApplicationSettings();

            // Assert
            
            Assert.NotNull(ApplicationSettingsContainer.Settings);
        }

        [Fact]
        public void ExapleModelIsConfiguredStatically()
        {
            // Arrange

            var testModel = new examples.ExampleModel();

            // Act

            var first = testModel.FirstLine;
            var second = testModel.SecondLine;

            // Assert

            Assert.Equal("Ms Black", first);
            Assert.Equal("Ms White", second);
        }

        [Fact]
        public void WhenSettingsUpdatedSettingsForExampleModelUpdated()
        {
            // Arrange

            var testModel = new examples.ExampleModel(designMode:true);

            // Act

            var first = testModel.FirstLine;

            var writeableSettings = (IApplicationSettingsSetter)ApplicationSettingsContainer.Settings;
            writeableSettings.Title = "Mister";
            
            // Assert

            Assert.Equal("Mister Black", testModel.FirstLine);
        }
    }
}

using core.Wrappers.Client;
using Moq;
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

        private void AssignSettingsToSettingsManager()
        {
            SettingsManager.AssignApplicationSettings(new ClientApplicationSettings(new RawApplicationSettingsSource()));
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

            manager.AssignApplicationSettings(new ClientApplicationSettings(new RawApplicationSettingsSource()));

            // Assert
            
            Assert.NotNull(ApplicationSettingsContainer.Settings);
        }

        [Fact]
        public void ExampleModelIsConfiguredStatically()
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

        [Fact]
        public void SimulateADatabaseRefresh()
        {
            // Arrange

            AssignSettingsToSettingsManager();          
            
            // Act

            var updatedSettings = new Mock<IApplicationSettingsGetter>();
            updatedSettings.Setup(s => s.Title).Returns("McBoatFace");
            SettingsManager.Refresh(updatedSettings.Object);

            var testModel = new examples.ExampleModel();

            // Assert
            
            Assert.Equal("McBoatFace Black", testModel.FirstLine);
            Assert.Equal("McBoatFace White", testModel.SecondLine);
            
            updatedSettings.Verify(s => s.Title, Times.Exactly(2));
        }

        [Fact]
        public void OnceInitialisedStoreWillNotBeOverwrittenByCallToCreate()
        {
            // Arrange

            AssignSettingsToSettingsManager();

            // Act

            var updatedSettings = new Mock<IApplicationSettingsGetter>();
            updatedSettings.Setup(s => s.Title).Returns("McBoatFace");
            SettingsManager.Refresh(updatedSettings.Object);           

            AssignSettingsToSettingsManager(); // call the create method again

            var testModel = new examples.ExampleModel();

            // Assert

            Assert.Equal("McBoatFace Black", testModel.FirstLine);
            Assert.Equal("McBoatFace White", testModel.SecondLine);

            updatedSettings.Verify(s => s.Title, Times.Exactly(2));
        }
    }
}

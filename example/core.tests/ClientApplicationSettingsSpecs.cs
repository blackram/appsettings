using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace core.tests
{       
    public class ClientApplicationSettingsSpecs : IDisposable
    {
        ClientApplicationSettings TestSettings = null;

        public ClientApplicationSettingsSpecs()
        {
            TestSettings = new ClientApplicationSettings(new RawApplicationSettingsSource());
        }
        
        [Fact]
        public void CanGetSetting()
        {
            // Arrange
            
            // Act

            var settings = TestSettings.ApplicationSettings();

            // Assert

            Assert.NotNull(settings);
        }

        [Fact]
        public void CanGetSettingValue()
        {
            // Arrange

            var a = TestSettings;

            // Act

            var settings = a.ApplicationSettings();
            var testValue = settings.PathName;

            // Assert

            Assert.Equal(@"c:\Help\", testValue);
        }

        [Fact]
        public void CanNotGetWritableSetting()
        {
            // Arrange

            var a = TestSettings;

            // Act
            
            var settings = a.ApplicationSettings();
            var settableSettings = settings as IApplicationSettingsSetter;

            // Assert

            Assert.Null(settableSettings);
        }

        [Fact]
        public void ContainerCanBeUpdatedByCallingRefresh()
        {
            // Arrange

            var a = TestSettings;
            var settings = a.ApplicationSettings();

            // Act
            
            var updatedSettings = new Mock<IApplicationSettingsGetter>();
            updatedSettings.Setup(s => s.PathName).Returns("New Path");

            a.Refresh(updatedSettings.Object);

            var testValue = settings.PathName;

            // Assert

            updatedSettings.Verify(s => s.PathName, Times.AtLeastOnce);
            Assert.Equal(@"New Path", testValue);
        }

        public void Dispose()
        {
            TestSettings = null;
        }
    }
}

using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace core.tests
{    
    
    public class ClientSettingsDesignModeSpecs : IDisposable
    {
        ClientApplicationSettings TestClientContainer = null;
             
        public ClientSettingsDesignModeSpecs()
        {
            TestClientContainer = new ClientApplicationSettings(new RawApplicationSettingsSource(), designMode:true);
        }

        [Fact]
        public void CanGetSetting()
        {
            // Arrange

            var a = TestClientContainer;

            // Act

            var settings = a.ApplicationSettings();

            // Assert

            Assert.NotNull(settings);
        }

        [Fact]
        public void CanGetSettingValue()
        {
            // Arrange

            var a = TestClientContainer;

            // Act

            var settings = a.ApplicationSettings();
            var testValue = settings.PathName;

            // Assert

            Assert.Equal(@"c:\Help\", testValue);
        }

        [Fact]
        public void CanGetWritableSettingAndSetValue()
        {
            // Arrange

            var a = TestClientContainer;

            // Act
            
            var settings = a.ApplicationSettings();
            var settableSettings = (IApplicationSettingsSetter)settings;
            settableSettings.PathName = "The Replacements";

            // Assert

            var testValue = settings.PathName;
            Assert.Equal("The Replacements", testValue);            
        }
        
        [Fact]
        public void ContainerCanBeUpdatedByCallingRefresh()
        {
            // Arrange

            var a = TestClientContainer;
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

        [Fact]
        public void LocalWritesNotOverriddenByRefresh()
        {
            // Arrange

            var a = TestClientContainer;
            var settings = a.ApplicationSettings();

            // Act

            var settableSettings = (IApplicationSettingsSetter)settings;
            settableSettings.PathName = "New Jack City";

            var updatedSettings = new Mock<IApplicationSettingsGetter>();
            updatedSettings.Setup(s => s.PathName).Returns("New Path");

            a.Refresh(updatedSettings.Object);

            var testValue = settings.PathName;

            // Assert

            updatedSettings.Verify(s => s.PathName, Times.Never);
            Assert.Equal(@"New Jack City", testValue);
        }

        public void Dispose()
        {
            TestClientContainer = null;
        }
    }
}

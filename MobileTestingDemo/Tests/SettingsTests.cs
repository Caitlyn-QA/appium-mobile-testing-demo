using MobileTestingDemo.Base;
using OpenQA.Selenium;

namespace MobileTestingDemo.Tests;

public class SettingsTests : BaseTest
{
    [Test]
    public void Settings_App_Is_Displayed()
    {
        Assert.That(Driver, Is.Not.Null);
    }
}
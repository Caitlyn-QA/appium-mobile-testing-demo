using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace MobileTestingDemo.Base;

public class BaseTest
{
    protected AndroidDriver? Driver { get; private set; }

    [SetUp]
    public void SetUp()
    {
        var options = new AppiumOptions();
        
        options.PlatformName = "Android";
        options.AutomationName = "UiAutomator2";
        options.DeviceName = "Pixel 8";
        // options.AddAdditionalAppiumOption("appPackage", "com.android.settings");
        //  options.AddAdditionalAppiumOption("appActivity", ".Settings");

        options.AddAdditionalAppiumOption("appPackage", "com.google.android.youtube");
        options.AddAdditionalAppiumOption("appActivity", "com.google.android.apps.youtube.app.WatchWhileActivity");


        Driver = new AndroidDriver(new Uri("http://127.0.0.1:4723/"),options);
    }

    [TearDown]
    public void TearDown()
    {
        Driver?.Quit();
        Driver?.Dispose();
    }
}
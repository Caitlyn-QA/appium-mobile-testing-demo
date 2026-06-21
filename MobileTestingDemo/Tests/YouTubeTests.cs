using MobileTestingDemo.Base;
using OpenQA.Selenium;

namespace MobileTestingDemo.Tests;

public class YouTubeTests : BaseTest
{
    [Test]
    public void User_Can_Search_For_A_Song_In_YouTube()
    {
        Driver!
            .FindElement(By.XPath("//*[@text=\"Don’t allow\" or @text=\"Don't allow\"]"))
            .Click();

        Thread.Sleep(2000);

        ClickSearchButton();

        var searchInput = Driver.FindElement(By.XPath("//*[@text='Search YouTube']"));

        searchInput.SendKeys("don't stop me now lyrics");

        Driver.PressKeyCode(66);

        Thread.Sleep(3000);

        Assert.That(Driver.PageSource.ToLower(), Does.Contain("don't stop me now"));
    }

    private void ClickSearchButton()
    {
        for (int attempt = 0; attempt < 3; attempt++)
        {
            try
            {
                Driver!
                    .FindElement(By.XPath("//*[@content-desc='Search']"))
                    .Click();

                return;
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(1000);
            }
        }

        Assert.Fail("Search button could not be clicked because it kept becoming stale.");
    }
}
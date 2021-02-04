using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace Vivino_Tests
{
    public class TestsVivinoApp
    {
        private const string VivinoLoginEmail = "pesho@abv.bg";
        private const string VivinoLoginPassword = "parola1parola1";
        private const string VivinoAppPackage = "vivino.web.app";
        private const string VivinoAppStartupActivity = "com.sphinx_solution.activities.SplashActivity";
        private AndroidDriver<AndroidElement> driver;

        [OneTimeSetUp]
        public void SetupRemoteServer()
        {
            var appiumOptions = new AppiumOptions() { PlatformName = "Android" };
            //appiumOptions.AddAdditionalCapability("app", @"C:\SoftUni\COURSES\QA-Automation\Jan-2021\07.Appium-Exercises\vivino.web.app_8.18.11.apk");
            appiumOptions.AddAdditionalCapability("appPackage", VivinoAppPackage);
            appiumOptions.AddAdditionalCapability("appActivity", VivinoAppStartupActivity);

            // Start Appium as IPv6 HTTP server before: `appium -a ::1`
            driver = new AndroidDriver<AndroidElement>(
                new Uri("http://[::1]:4723/wd/hub"), appiumOptions);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [Test]
        public void Test()
        {
            // Login in the Vivino app
            var linkLogin = driver.FindElementById("vivino.web.app:id/txthaveaccount");
            linkLogin.Click();

            var textBoxLoginEmail = driver.FindElementById("vivino.web.app:id/edtEmail");
            textBoxLoginEmail.SendKeys(VivinoLoginEmail);

            var textBoxLoginPassword = driver.FindElementById("vivino.web.app:id/edtPassword");
            textBoxLoginPassword.SendKeys(VivinoLoginPassword);

            var buttonLogin = driver.FindElementById("vivino.web.app:id/action_signin");
            buttonLogin.Click();

            // Search for "Katarzyna Reserve Red 2006"
            var tabExplorer = driver.FindElementById("vivino.web.app:id/wine_explorer_tab");
            tabExplorer.Click();

            var buttonSearch = driver.FindElementById("vivino.web.app:id/search_vivino");
            buttonSearch.Click();

            var textBoxSearch = driver.FindElementById("vivino.web.app:id/editText_input");
            textBoxSearch.SendKeys("Katarzyna Reserve Red 2006");

            // Click on the first search result
            var listSearchResults = driver.FindElementById("vivino.web.app:id/listviewWineListActivity");
            var firstResult = listSearchResults.FindElementByClassName("android.widget.FrameLayout");
            firstResult.Click();
            
            var elementWineName = driver.FindElementById("vivino.web.app:id/wine_name");
            Assert.AreEqual("Reserve Red 2006", elementWineName.Text);

            var elementRating = driver.FindElementById("vivino.web.app:id/rating");
            double rating = double.Parse(elementRating.Text);
            Assert.IsTrue(rating >= 3.00 && rating <= 5.00);

            var tabsSummary = driver.FindElementById("vivino.web.app:id/tabs");
            var tabHighlights = tabsSummary.FindElementByXPath("//android.widget.TextView[1]");
            var tabFacts = tabsSummary.FindElementByXPath("//android.widget.TextView[2]");

            tabHighlights.Click();
            var highlightsDescription = driver.FindElementByAndroidUIAutomator(
                "new UiScrollable(new UiSelector().scrollable(true))" +
                ".scrollIntoView(new UiSelector().resourceIdMatches(" +
                "\"vivino.web.app:id/highlight_description\"))"
            );
            Assert.AreEqual("Among top 1% of all wines in the world", highlightsDescription.Text);

            tabFacts.Click();
            var factTitle = driver.FindElementById("vivino.web.app:id/wine_fact_title");
            Assert.AreEqual("Grapes", factTitle.Text);
            var factText = driver.FindElementById("vivino.web.app:id/wine_fact_text");
            Assert.AreEqual("Cabernet Sauvignon,Merlot", factText.Text);
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}
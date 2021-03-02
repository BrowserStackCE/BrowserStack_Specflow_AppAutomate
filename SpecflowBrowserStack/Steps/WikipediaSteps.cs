using TechTalk.SpecFlow;
using FluentAssertions;
using SpecflowBrowserStack.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using Xunit;
using System.Collections.Generic;

namespace SpecflowBrowserStack.Steps
{
	[Binding]
	public class WikipediaSteps
	{
		private readonly WebDriver _webDriver;
		private static bool passed = true;

		private static string message = "";

		public WikipediaSteps(WebDriver driver)
		{
			_webDriver = driver;
		}

		[When(@"open Wikipedia app and click on search bar")]
		public void WhenOpenWikipediaAppAndClickOnSearchBar()
		{
			_webDriver.Current.FindElement(By.Id("search_container")).Click();
			
		}

		[Then(@"enter '(.*)'")]
		public void ThenEnter(string input)
		{
			System.Threading.Thread.Sleep(3000);
			_webDriver.Current.FindElement(By.Id("search_src_text")).SendKeys(input);
		}

		[AfterScenario]
		public void MarkTestAsPassOrFail()
		{
			if (passed)
			{
				((IJavaScriptExecutor)_webDriver.Current).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \"Tests function correctly\"}}");
			}
			else
			{
				((IJavaScriptExecutor)_webDriver.Current).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \"" + message + "\"}}");
			}
		}
	}
}

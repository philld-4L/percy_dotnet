using System;
using TechTalk.SpecFlow;

namespace PercySpecflowSample.Steps
{
    [Binding]
    public class S_Browserstack
    {
        [Given(@"A responsive website I have permission to test")]
        public void GivenAResponsiveWebsiteIHavePermissionToTest()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I take a snapshot using a device")]
        public void WhenITakeASnapshotUsingADevice()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"It will match the expected snapshot")]
        public void ThenItWillMatchTheExpectedSnapshot()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

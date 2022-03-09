using System;
using TechTalk.SpecFlow;

namespace HelloSpec.IntegratedTest;

[Binding]
public class StepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public StepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the first number is (.*)")]
    public void GivenTheFirstNumberIs(int p0)
    {
        //_scenarioContext.Pending();
    }

    [Given(@"the second number is (.*)")]
    public void GivenTheSecondNumberIs(int p0)
    {
        //_scenarioContext.Pending();
    }

    [When(@"the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        //_scenarioContext.Pending();
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(int p0)
    {
        //_scenarioContext.Pending();
    }

    [Then(@"아침이 밝는구나")]
    public void ThenKorean()
    {
        //_scenarioContext.Pending();
    }
}
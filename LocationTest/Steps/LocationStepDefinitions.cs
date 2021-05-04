using TechTalk.SpecFlow;
using FluentAssertions;
using LocationLibrary;
using LocationTest.Fake;

namespace LocationTest.Steps
{
    [Binding]
    public sealed class LocationStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;

        private string _username;
        private string _password;
        private string _lastErrorMessage;
        private Location _target;
        private FakeDataLayer _fakeDataLayer;

        public LocationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this._fakeDataLayer = new FakeDataLayer();
            this._target = new Location(this._fakeDataLayer);
        }

        #region Background

        [Given(@"following existing clients")]
        public void GivenFollowingExistingClients(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                this._fakeDataLayer.Clients.Add(new Client(row[0], row[1]));
            }
        }

        #endregion

        [Given(@"my username is ""(.*)""")]
        public void GivenMyUsernameIs(string username)
        {
            this._username = username;
        }

        [Given(@"my password is ""(.*)""")]
        public void GivenMyPasswordIs(string password)
        {
            this._password = password;
        }

        [When(@"I try to connect to my account")]
        public void WhenITryToConnectToMyAccount()
        {
            this._lastErrorMessage = this._target.ConnectUser(this._username, this._password);
        }

        [Then(@"the connection is refused")]
        public void ThenTheConnectionIsRefused()
        {
            this._target.UserConnected.Should().BeFalse();
        }

        [Then(@"the error message is ""(.*)""")]
        public void ThenTheErrorMessageIs(string errorMessage)
        {
            this._lastErrorMessage.Should().Be(errorMessage);
        }

        [Then(@"the connection is established")]
        public void ThenTheConnectionIsEstablished()
        {
            this._target.UserConnected.Should().BeTrue();
        }
    }
}

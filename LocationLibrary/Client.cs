namespace LocationLibrary
{
    public class Client
    {
        public string Username { get; private set; }

        public string Password { get; private set; }

        public Client(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
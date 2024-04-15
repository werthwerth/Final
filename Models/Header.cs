namespace Final.Models
{
    public class Header
    {
        public Header()
        {
            registerButtonName = "Register";
            registerButtonController = "Register";
            registerButtonAction = "Register";
            loginButtonName = "Login";
            loginButtonController = "Home";
            loginButtonAction = "Privacy";
        }
        public Header(string _login, string _password)
        {
            registerButtonName = $"{_login}/{_password}";
            registerButtonController = "Register";
            registerButtonAction = "Register";
            loginButtonName = "Login";
            loginButtonController = "Home";
            loginButtonAction = "Privacy";
        }
        public string? registerButtonName { get; set; }
        public string? registerButtonController { get; set; }
        public string? registerButtonAction { get; set; }
        public string? loginButtonName { get; set; }
        public string? loginButtonController { get; set; }
        public string? loginButtonAction { get; set; }
        public bool? isLogged {  get; set; }
        public string? login {  get; set; }
    }
}

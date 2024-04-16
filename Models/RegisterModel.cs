using Final.EFW.Database;
using Final.EFW.Entities;
using Final.Static.EntitiesScripts;

namespace Final.Models
{
    public class RegisterModel
    {
        public RegisterModel()
        {
            RegisterButtonName = "Регистрация";
            RegisterButtonController = "Register";
            RegisterButtonAction = "Register";
            LoginButtonName = "Войти";
            LoginButtonController = "Login";
            LoginButtonAction = "Login";
            sessionId = null;
        }
        public RegisterModel(string _login, string _password, string? _salt, string _firstName, string _lastName, string _email, Core.DB _db, string? _sessionId)
        {
            RegisterButtonName = $"{_firstName} {_lastName}";
            RegisterButtonController = "Profile";
            RegisterButtonAction = "Profile";
            LoginButtonName = "Выйти";
            LoginButtonController = "Home";
            LoginButtonAction = "Exit";
            Salt = _salt;
            _registrationResult = UserScripts.Register(_login, _db, _password, _salt, _firstName, _lastName, _email, _sessionId);
            isLogged = _registrationResult.success;
            firstName = _registrationResult.firstName;
            lastName = _registrationResult.lastName;
            sessionId = _registrationResult.newSessionId;
        }
        public RegisterModel(string _sessionId, Core.DB _db)
        {
            if (SessionScripts.CheckById(_sessionId, _db))
            {
                User? _user = SessionScripts.GetUserBySessionId(_sessionId, _db);
                if (_user != null)
                {
                    RegisterButtonName = $"{_user.FirstName} {_user.LastName}";
                    RegisterButtonController = "Profile";
                    RegisterButtonAction = "Profile";
                    LoginButtonName = "Выйти";
                    LoginButtonController = "Home";
                    LoginButtonAction = "Exit";
                    Salt = _user.Salt;
                    isLogged = true;
                    firstName = _user.FirstName;
                    lastName = _user.LastName;
                    sessionId = _sessionId;
                }
                else
                {
                    RegisterButtonName = "Регистрация";
                    RegisterButtonController = "Register";
                    RegisterButtonAction = "Register";
                    LoginButtonName = "Войти";
                    LoginButtonController = "Login";
                    LoginButtonAction = "Login";
                    sessionId = null;
                }
            }
            else
            {
                RegisterButtonName = "Регистрация";
                RegisterButtonController = "Register";
                RegisterButtonAction = "Register";
                LoginButtonName = "Войти";
                LoginButtonController = "Login";
                LoginButtonAction = "Login";
                sessionId = null;
            }
        }
        public string? RegisterButtonName { get; set; }
        public string? RegisterButtonController { get; set; }
        public string? RegisterButtonAction { get; set; }
        public string? LoginButtonName { get; set; }
        public string? LoginButtonController { get; set; }
        public string? LoginButtonAction { get; set; }
        public bool isLogged {  get; set; }
        public string? Login {  get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? Salt {  get; set; }
        public RegistrationResult? _registrationResult { get; set; }
        public string? sessionId { get; set; }
    }
}

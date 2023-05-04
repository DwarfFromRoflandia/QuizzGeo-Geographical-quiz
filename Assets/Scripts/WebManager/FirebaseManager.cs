using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class FirebaseManager : MonoBehaviour
{
//    //Firebase variables
//    [Header("Firebase")]
//    public DependencyStatus dependencyStatus;
//    public FirebaseAuth auth;
//    public FirebaseUser User;
//    public DatabaseReference DBreference;

//    //Login variables
//    [Header("Login")]
//    public string emailLoginField;
//    public string passwordLoginField;
//    public Text warningLoginText;
//    public Text confirmLoginText;

//    public Text emailLogin;
//    public Text passwordLogin;

//    //Register variables
//    [Header("Register")]
//    public string usernameRegisterField;
//    public string emailRegisterField;
//    public string passwordRegisterField;
//    public string passwordRegisterVerifyField;
//    public Text warningRegisterText;

//    public Text usernameRegister;
//    public Text emailRegister;
//    public Text passwordRegister;
//    public Text passwordRegisterVerify;


//    [Header("UserData")]
//    public Text usernameField;
//    public Text scoreField;

//    public GameObject scoreElement;
//    public Transform scoreboardContent;

//    private void Awake()
//    {
//        //Check that all of the necessary dependencies for Firebase are present on the system
//        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
//        {
//            dependencyStatus = task.Result;
//            if (dependencyStatus == DependencyStatus.Available)
//            {
//                //If they are avalible Initialize Firebase
//                InitializeFirebase();
//            }
//            else
//            {
//                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
//            }
//        });
//    }

//    private void Update()
//    {
//        emailLoginField = emailLogin.text;
//        passwordLoginField = passwordLogin.text;

//        usernameRegisterField = usernameRegister.text;
//        emailRegisterField = emailRegister.text;
//        passwordRegisterField = passwordRegister.text;
//        passwordRegisterVerifyField = passwordRegisterVerify.text;
//    }

//    private void InitializeFirebase()
//    {
//        Debug.Log("Setting up Firebase Auth");
//        //Set the authentication instance object
//        auth = FirebaseAuth.DefaultInstance;
//        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
//    }

//    public void ClearLoginFeilds()
//    {
//        emailLogin.text = "";
//        passwordLogin.text = "";

//    }
//    public void ClearRegisterFeilds()
//    {
//        usernameRegister.text = "";
//        emailRegister.text = "";
//        passwordRegister.text = "";
//        passwordRegisterVerify.text = "";

//        Debug.Log("Clear");
//    }

//    //Function for the login button
//    public void LoginButton()
//    {
//        //Call the login coroutine passing the email and password
//        StartCoroutine(Login(emailLoginField, passwordLoginField));
//    }
//    //Function for the register button
//    public void RegisterButton()
//    {
//        //Call the register coroutine passing the email, password, and username
//        StartCoroutine(Register(emailRegisterField, passwordRegisterField, usernameRegisterField));
//    }

//    //Function for the sign out button
//    public void SignOutButton()
//    {
//        auth.SignOut();
//        UIManager.instance.LoginScreen();
//        ClearLoginFeilds();
//        ClearRegisterFeilds();
//    }

//    public void SaveDataButton()
//    {
//        StartCoroutine(UpdateUsernameAuth(usernameField.text));
//        StartCoroutine(UpdateUsernameDatabase(usernameField.text));

//        StartCoroutine(UpdateScore(int.Parse(scoreField.text)));
//        //StartCoroutine(UpdateKills(int.Parse(killsField.text)));
//        //StartCoroutine(UpdateDeaths(int.Parse(deathsField.text)));

//        Debug.Log("usernameField.text: " + usernameField.text);
//        Debug.Log("scoreField.text: " + scoreField.text);
//    }

//    private IEnumerator Login(string _email, string _password)
//    {
//        //Call the Firebase auth signin function passing the email and password
//        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
//        //Wait until the task completes
//        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

//        if (LoginTask.Exception != null)
//        {
//            //If there are errors handle them
//            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
//            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
//            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

//            string message = "Login Failed!";
//            switch (errorCode)
//            {
//                case AuthError.MissingEmail:
//                    message = "Missing Email";
//                    break;
//                case AuthError.MissingPassword:
//                    message = "Missing Password";
//                    break;
//                case AuthError.WrongPassword:
//                    message = "Wrong Password";
//                    break;
//                case AuthError.InvalidEmail:
//                    message = "Invalid Email";
//                    break;
//                case AuthError.UserNotFound:
//                    message = "Account does not exist";
//                    break;
//            }
//            warningLoginText.text = message;
//        }
//        else
//        {
//            //User is now logged in
//            //Now get the result
//            User = LoginTask.Result;
//            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
//            warningLoginText.text = "";
//            confirmLoginText.text = "Logged In";

//            yield return new WaitForSeconds(2);

//            usernameField.text = User.DisplayName;
//            UIManager.instance.UserDataScreen(); // Change to user data UI
//            confirmLoginText.text = "";
//            ClearLoginFeilds();
//            //ClearRegisterFeilds();
//        }
//    }

//    private IEnumerator Register(string _email, string _password, string _username)
//    {
//        if (_username == "")
//        {
//            //If the username field is blank show a warning
//            warningRegisterText.text = "Missing Username";
//        }
//        else if (passwordRegisterField!= passwordRegisterVerifyField)
//        {
//            //If the password does not match show a warning
//            warningRegisterText.text = "Password Does Not Match!";
//        }
//        else
//        {
//            //Call the Firebase auth signin function passing the email and password
//            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
//            //Wait until the task completes
//            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

//            if (RegisterTask.Exception != null)
//            {
//                //If there are errors handle them
//                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
//                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
//                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

//                string message = "Register Failed!";
//                switch (errorCode)
//                {
//                    case AuthError.MissingEmail:
//                        message = "Missing Email";
//                        break;
//                    case AuthError.MissingPassword:
//                        message = "Missing Password";
//                        break;
//                    case AuthError.WeakPassword:
//                        message = "Weak Password";
//                        break;
//                    case AuthError.EmailAlreadyInUse:
//                        message = "Email Already In Use";
//                        break;
//                }
//                warningRegisterText.text = message;
//            }
//            else
//            {
//                //User has now been created
//                //Now get the result
//                User = RegisterTask.Result;

//                if (User != null)
//                {
//                    //Create a user profile and set the username
//                    UserProfile profile = new UserProfile { DisplayName = _username };

//                    //Call the Firebase auth update user profile function passing the profile with the username
//                    var ProfileTask = User.UpdateUserProfileAsync(profile);
//                    //Wait until the task completes
//                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

//                    if (ProfileTask.Exception != null)
//                    {
//                        //If there are errors handle them
//                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
//                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
//                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
//                        warningRegisterText.text = "Username Set Failed!";
//                    }
//                    else
//                    {
//                        //Username is now set
//                        //Now return to login screen
//                        UIManager.instance.LoginScreen();
//                        warningRegisterText.text = "";
//                        ClearLoginFeilds();
//                        //ClearRegisterFeilds();
//                    }
//                }
//            }
//        }
//    }

//    private IEnumerator UpdateUsernameAuth(string _username)
//    {
//        //Create a user profile and set the username
//        UserProfile profile = new UserProfile { DisplayName = _username };

//        //Call the Firebase auth update user profile function passing the profile with the username
//        var ProfileTask = User.UpdateUserProfileAsync(profile);
//        //Wait until the task completes
//        yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

//        if (ProfileTask.Exception != null)
//        {
//            Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
//        }
//        else
//        {
//            //Auth username is now updated
//        }
//    }

//    private IEnumerator UpdateUsernameDatabase(string _username)
//    {
//        //Set the currently logged in user username in the database
//        var DBTask = DBreference.Child("users").Child(User.UserId).Child("username").SetValueAsync(_username);

//        Debug.Log("DBTask: " + DBTask);

//        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

//        if (DBTask.Exception != null)
//        {
//            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
//        }
//        else
//        {
//            //Database username is now updated
//        }
//    }

//    private IEnumerator UpdateScore(int _score)
//    {
//        //Set the currently logged in user xp
//        var DBTask = DBreference.Child("users").Child(User.UserId).Child("xp").SetValueAsync(_score);

//        Debug.Log("DBTask: " + DBTask);

//        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

//        if (DBTask.Exception != null)
//        {
//            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
//        }
//        else
//        {
//            //Xp is now updated
//        }
//    }
}
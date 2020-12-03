using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLogin : MonoBehaviour
{

    void Start()
    {
        //LoginWithCustomID("ID001");

        //RegisterPlayFabUser("johndoe", "passw0rd", "john@doe.com", "John Doe");
        //LoginWithPlayFabUser("johndoe", "passw0rd");
    }

    public void LoginWithCustomID(string ID)
    {
        var request = new LoginWithCustomIDRequest { CustomId = ID, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }
    public void LoginWithPlayFabUser(string username, string password)
    {
        var request = new LoginWithPlayFabRequest();
        request.Username = username;
        request.Password = password;
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
    }

    public void RegisterPlayFabUser(string username, string password, string email, string displayName)
    {
        var request = new RegisterPlayFabUserRequest();
        request.Username = username;
        request.Password = password;
        request.Email = email;
        request.DisplayName = displayName;
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterPlayFabUserSuccess, OnRegisterPlayFabUserError);
    }

    private void OnLoginSuccess(LoginResult obj)
    {
        Debug.Log("Login is succeeded.");

    }

    private void OnLoginFailure(PlayFabError obj)
    {
        Debug.Log("Login is failed.");
    }

    private void OnRegisterPlayFabUserSuccess(RegisterPlayFabUserResult obj)
    {
        Debug.Log("PlayFab user registration is succeeded.");
    }

    public void OnRegisterPlayFabUserError(PlayFabError obj)
    {
        Debug.Log("PlayFab user registration is failed.");
    }


}

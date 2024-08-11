using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using TMPro;
using System.Threading.Tasks;
public class AuthenticationManager : MonoBehaviour
{


    [SerializeField]
    private  GameObject player;
    [SerializeField]
    private GameObject authUI; 
    private cloudManager cloudManager;
 
 
  async void Awake()
    {
        await UnityServices.InitializeAsync();
        cloudManager = FindObjectOfType<cloudManager>();
        SetupEvents();

     

        if (!AuthenticationService.Instance.IsSignedIn)
        {
              try
              {
                  await AuthenticationService.Instance.SignInAnonymouslyAsync();
                  player.SetActive(true);
                  authUI.SetActive(false);
              }
              catch (AuthenticationException ex)
              {
                GameObject.Find("error").GetComponent<TMP_Text>().text = ex.Message;

              }
              catch (RequestFailedException ex)
              {
                GameObject.Find("error").GetComponent<TMP_Text>().text = ex.Message;
    
              }

        
        }
        else
        {
            player.SetActive(true);
            authUI.SetActive(false);
        }
    }


  void SetupEvents() 
    {
        AuthenticationService.Instance.SignedIn += () => 
        {
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

            player.SetActive(true);
            authUI.SetActive(false);
        };

        AuthenticationService.Instance.SignInFailed += (err) => 
        {
            Debug.LogError(err);
        };

        AuthenticationService.Instance.SignedOut += () => 
        {
            Debug.Log("Player signed out.");
        };

        AuthenticationService.Instance.Expired += () =>
        {
            Debug.Log("Player session could not be refreshed and expired.");
        };
    }
}

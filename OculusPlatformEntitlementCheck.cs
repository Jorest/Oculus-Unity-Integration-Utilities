//Code OculusPlatformEntitlementCheck 
using UnityEngine;
using Oculus.Platform;

public class OculusPlatformEntitlementCheck : MonoBehaviour
{

    void Awake()
    {
        try
        {
            Core.AsyncInitialize();
            Oculus.Platform.Entitlements.IsUserEntitledToApplication().OnComplete(GetEntitlementCallback);
        }
        catch (UnityException e)
        {
            Debug.LogError("Platform failed to initialize due to exception.");
            Debug.LogException(e);
            // Immediately quit the application.
            UnityEngine.Application.Quit();
        }
    }

    void GetEntitlementCallback(Message msg)
    {
        if (msg.IsError)
        {
            Debug.LogError("You are NOT entitled to use this app.");
            UnityEngine.Application.Quit();
        }
        else
        {
            Debug.Log("You are entitled to use this app.");
        }
    }
}
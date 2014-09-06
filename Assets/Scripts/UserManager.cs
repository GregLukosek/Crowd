using UnityEngine;
using System.Collections;
using Parse;
using System;
using Facebook;
using System.Threading.Tasks;

public class UserManager : MonoBehaviour
{
	public static UserManager instance;


	void Awake()
	{
		instance = this;
	}


	public IEnumerator FacebookLogin(Action<string> status, Action<string> response)
	{
		if (!FB.IsInitialized)
		{
			status("Initializing");
			FB.Init(delegate() 
			{
				Debug.Log("Init finished");
			},
			OnHideUnity);

			while (!FB.IsInitialized) yield return new WaitForEndOfFrame();
		}

		if(FB.IsLoggedIn)
		{
			response("ok");
		}
		else
		{
			status("Authorizing");

			FB.Login("public_profile", delegate(FBResult result)
			{
				if(result.Error != null)
				{
					response(result.Error);
				}
				else
				{
					response("ok");
				}
			} );
		}
	}


	public IEnumerator ParseLogin(Action<string> response)
	{
		Task<ParseUser> task = ParseFacebookUtils.LogInAsync(FB.UserId, FB.AccessToken, FB.AccessTokenExpiresAt);

		while (!task.IsCompleted) yield return new WaitForEndOfFrame();

		if (task.IsFaulted)
		{
			response(task.Exception.InnerException.Message);
		}
		else
		{
			response("ok");
		}
	}




	private void OnHideUnity(bool isShown)
	{
		string s = isShown ? "The game screen is shown." : "The game screen is hidden.";
		Debug.Log(s);
	}






}

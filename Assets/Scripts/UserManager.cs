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

			FB.Login("email", delegate(FBResult result)
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


	private void OnHideUnity(bool isShown)
	{
		string s = isShown ? "The game screen is shown." : "The game screen is hidden.";
		Debug.Log(s);
	}






}

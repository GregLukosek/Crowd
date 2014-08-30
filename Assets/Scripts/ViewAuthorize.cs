using UnityEngine;
using System.Collections;

public class ViewAuthorize : UIView 
{

	public UILabel labelStatus;


	public override void Hide ()
	{
		base.Hide ();
	}

	
	public override void Show ()
	{
		base.Show ();
		StartCoroutine(LoginSignup());
	}



	IEnumerator LoginSignup()
	{
		string status = "";
		string response = "";
		StartCoroutine(UserManager.instance.FacebookLogin(value=>status=value,
		                                                value=>response=value));
		
		while (response == "")
		{
			if (status != labelStatus.text) labelStatus.text = status;
			yield return new WaitForEndOfFrame();
		}
		
		if (response != "ok")
		{
			Debug.LogError(response);
			labelStatus.color = Color.red;
			labelStatus.text = response;
		}
		else
		{
			//all went fine ready to parse login
			Debug.Log("Facebook login fine");
			labelStatus.text = "Logging in";

			string parseResponse = "";
			StartCoroutine(UserManager.instance.ParseLogin(value=>parseResponse=value));
			while (parseResponse == "")
			{
				yield return new WaitForEndOfFrame();
			}


			if (parseResponse != "ok")
			{
				Debug.LogError(parseResponse);
				labelStatus.color = Color.red;
			}
			else
			{
				ViewController.instance.ToMainRoom();
			}
		}

	}



}

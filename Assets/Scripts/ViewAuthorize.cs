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
			ViewController.instance.ToMainRoom();
		}
		else
		{
			//all went fine ready to parse login
			Debug.Log("Facebook login fine");
			ViewController.instance.ToMainRoom();
		}

	}



}

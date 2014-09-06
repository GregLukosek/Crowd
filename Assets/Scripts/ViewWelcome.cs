using UnityEngine;
using System.Collections;

public class ViewWelcome : UIView 
{
	

	public override void Hide ()
	{
		base.Hide ();
	}

	
	public override void Show ()
	{
		base.Show ();
	}



	public void EmailSupport()
	{
		Application.OpenURL("mailto:lukos86@gmail.com?subject=CrowdSupport");
	}



}

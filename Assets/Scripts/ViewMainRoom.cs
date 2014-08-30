using UnityEngine;
using System.Collections;

public class ViewMainRoom : UIView 
{
	


	public override void Hide ()
	{
		base.Hide ();
	}

	
	public override void Show ()
	{
		base.Show ();

		StartCoroutine(Connect());

	}


	IEnumerator Connect()
	{
		PhotonManager.instance.Connect();



		yield return null;

	}





}

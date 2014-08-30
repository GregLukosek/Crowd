using UnityEngine;
using System.Collections;
using Parse;

public class ViewController : MonoBehaviour 
{
	public Camera guiCamera;
	public UIView viewAuthorize;

	
	private UIView _currentView;
	public UIView currentView
	{
		get { return _currentView ; }
		set
		{
			_currentView = value;
		}
		
	}


	public void ChangeView(UIView view)
	{
		view.Show();
		guiCamera.transform.position = new Vector3(view.transform.position.x, view.transform.position.y);
		if (currentView != null && view != currentView) currentView.Hide();
		currentView = view;
	}




	void Start()
	{
		ChangeView(viewAuthorize);
	}

	


}








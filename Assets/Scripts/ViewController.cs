using UnityEngine;
using System.Collections;
using Parse;

public class ViewController : MonoBehaviour 
{
	public static ViewController instance;

	public Camera guiCamera;
	public UIView viewAuthorize;
	public UIView viewMainRoom;
	
	private UIView _currentView;
	public UIView currentView
	{
		get { return _currentView ; }
		set
		{
			_currentView = value;
		}
		
	}


	void Awake()
	{
		instance = this;
		Application.targetFrameRate = 30;
	}


	void Start()
	{
//		ChangeView(viewAuthorize);
//		ToMainRoom();
	}


	void ChangeView(UIView view)
	{
		view.Show();
		guiCamera.transform.position = new Vector3(view.transform.position.x, view.transform.position.y);
		if (currentView != null && view != currentView) currentView.Hide();
		currentView = view;
	}


	public void ToAuthorize() { ChangeView(viewAuthorize);}
	public void ToMainRoom() { ChangeView(viewMainRoom);}





	


}








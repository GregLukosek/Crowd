using UnityEngine;
using System.Collections;

public class User : MonoBehaviour 
{
	public float speed = 5f;
	public float rotationSensitivity = 60f;
	public string facebookId = "";
	public Renderer cube;
	public int playerId = -1;


	public IEnumerator LoadAvatar(string url)
	{
		cube.material = new Material(Shader.Find("Diffuse"));

		WWW www = new WWW(url);
		yield return www;

		if (www.error != null) Debug.LogError("Loading avatar error: " + www.error);
		else
		{
			cube.material.mainTexture = www.texture;
		}
	}


	void Update()
	{
		if (GetComponent<PhotonView>().isMine)
		{
			transform.localPosition += (transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);
			transform.Rotate(Vector3.up * Time.deltaTime * Input.GetAxis("Horizontal") * rotationSensitivity, Space.World);
		}
	}



	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
		StartCoroutine(LoadAvatar("http://graph.facebook.com/" + (string)info.sender.customProperties["fbid"] + "/picture?type=large"));

		
	}


}

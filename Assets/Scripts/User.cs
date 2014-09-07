using UnityEngine;
using System.Collections;

public class User : MonoBehaviour 
{
	public string facebookId = "";
	public Renderer cube;
	public int playerId = -1;
	public Camera cam;
	public CharacterController characterController;
	public MouseLook[] mouseLooks;
	
	private RaycastHit hit;


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



	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
		StartCoroutine(LoadAvatar("http://graph.facebook.com/" + (string)info.sender.customProperties["fbid"] + "/picture?type=large"));

		cam.gameObject.SetActive(info.sender.isLocal);
		characterController.enabled = info.sender.isLocal;
		foreach(MouseLook mouseLook in mouseLooks) mouseLook.enabled = info.sender.isLocal;
	}





	void Update()
	{
		Ray ray = cam.ScreenPointToRay (new Vector3((float)Screen.width/2f, (float)Screen.height/2f, cam.nearClipPlane));

		if (Physics.Raycast(ray, out hit, 20f))
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (hit.collider.transform.parent.GetComponent<PieceUI>() != null)
				{
					Piece piece = hit.collider.transform.parent.GetComponent<PieceUI>().piece;
					Chunk chunk = piece.chunk;
					if (hit.normal == new Vector3(0,1f,0)) chunk.AddPiece(piece.x, piece.y+1, piece.z);
					else if (hit.normal == new Vector3(1f,0,0)) chunk.AddPiece(piece.x+1, piece.y, piece.z);
					else if (hit.normal == new Vector3(-1f,0,0)) chunk.AddPiece(piece.x-1, piece.y, piece.z);
					else if (hit.normal == new Vector3(0,0,1f)) chunk.AddPiece(piece.x, piece.y, piece.z+1);
					else if (hit.normal == new Vector3(0,0,-1f)) chunk.AddPiece(piece.x, piece.y, piece.z-1);
					else if (hit.normal == new Vector3(0,-1f,0)) chunk.AddPiece(piece.x, piece.y-1, piece.z);
				}
			}
			Debug.DrawLine(ray.origin, hit.point, Color.green);
		}


	}








}




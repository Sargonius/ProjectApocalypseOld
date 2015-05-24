using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextMoveFade : MonoBehaviour {
	
	public float Speed = 5;
	public float FadeOutSpeed = 0.05f;
	public Vector3 MoveToPosition = new Vector3 (0, -10);
	public float distanceOffset = 1;
	public RectTransform RectTransform;
	public Text CustomText;
	
	// Use this for initialization
	void Start () {
		StartCoroutine (MoveAndFade ());
		Destroy(this.gameObject,1);
	}
	
	private IEnumerator MoveAndFade()
	{
		while (true) {
			RectTransform.position -= Vector3.down * Time.deltaTime * Speed;
			CustomText.color -= new Color(0,0,0,FadeOutSpeed);
			
			if(Vector3.Distance(MoveToPosition, RectTransform.position) < distanceOffset)
				break;
			
			yield return null;
		}
	}

}
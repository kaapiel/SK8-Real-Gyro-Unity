using UnityEngine;

public class VisaoDoSkater : MonoBehaviour {

	Vector2 touchLook;
	Vector2 smoothV;
	public float sensitivity = 20f;
	public float smoothing = 1.0f;

	public GameObject skate;
    public Camera cam;

	void Start () {
	}
	
	void Update () {
		var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

		smoothV.x = Mathf.Lerp(smoothV.x, md.x, 0.8f / smoothing);
		//smoothV.y = Mathf.Lerp(smoothV.y, md.y, 0.8f / smoothing);
		touchLook += smoothV;

		//transform.localRotation = Quaternion.AngleAxis(/*-touchLook.y*/ 30, Vector3.right);

        cam.transform.localRotation = Quaternion.Euler(skate.transform.rotation.y + 40, 
                                                       touchLook.x + 180, 
                                                       skate.transform.rotation.z);

        cam.transform.position = new Vector3(skate.transform.position.x, 
                                             skate.transform.position.y + 1.4f, 
                                             skate.transform.position.z + 1);
        
	}
}

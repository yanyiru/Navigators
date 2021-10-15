using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{

    private bool pedestalTouching;

	private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
		//camera = GetComponent<Camera>();
    }

	// Update is called once per frame
	void Update()
	{
		//if (pedestalTouching == true && )

		//if (Input.GetMouseButtonDown(0))
		//{ // if left button pressed...
		//	Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		//	RaycastHit hit;
		//	if (Physics.Raycast(ray, out hit))
		//	{
		//		// the object identified by hit.transform was clicked
		//		// do whatever you want
		//	}
		//}
	}

	private void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag.Equals("player") == true)
		{
			pedestalTouching = true;
			print(pedestalTouching);
		}
	}

	private void OnCollisionExit2D(Collision2D target)
	{
		if (target.gameObject.tag.Equals("player") == true)
		{
			pedestalTouching = false;
			print(pedestalTouching);
		}
	}
}

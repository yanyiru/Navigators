using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{

	private bool pedestalTouching;

	public SpriteRenderer PWOCrown;
	public Sprite PWCrown;
	private Animator animator;


	// Start is called before the first frame update
	void Start()
    {
		PWOCrown = gameObject.GetComponent<SpriteRenderer>();
		Resources.LoadAll<Sprite>("Pedestal with Crown");
		animator = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			Debug.Log("Mouse Clicked");
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

			if (hit.collider != null)
			{
				if (hit.collider.gameObject.name == "Pedestal" && pedestalTouching == true)
				{
					Debug.Log("Something was clicked!");
					//ChangeSprite(PWCrown);
					animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Disappearing Pedestal");
					
					

				}

			}
		}

	}

	private void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.name.Equals("Player") == true)
		{
			pedestalTouching = true;
			print(pedestalTouching);

		}
	}

	private void OnCollisionExit2D(Collision2D target)
	{
		if (target.gameObject.name.Equals("Player") == true)
		{
			pedestalTouching = false;
			print(pedestalTouching);
		}
	}

	private void ChangeSprite(Sprite newsprite)
	{
		PWOCrown.sprite = newsprite;
	}

	IEnumerator WaitCoroutine()
	{
		//Print the time of when the function is first called.
		Debug.Log("Started Coroutine at timestamp : " + Time.time);

		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(2f);

		//After we have waited 5 seconds print the time again.
		Debug.Log("Finished Coroutine at timestamp : " + Time.time);

		
	}
}

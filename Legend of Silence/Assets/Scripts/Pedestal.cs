using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{

	private bool pedestalTouching;

	public SpriteRenderer PWOCrown;
	public Sprite PWCrown;


	// Start is called before the first frame update
	void Start()
    {
		PWOCrown = GetComponent<SpriteRenderer>();
		PWCrown = GetComponent<Sprite>();
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
					ChangeSprite(PWCrown);
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
}

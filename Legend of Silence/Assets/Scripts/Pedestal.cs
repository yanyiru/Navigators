using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{

	private bool pedestalTouching;
	public SpriteRenderer PWOCrown;
	public Sprite PWCrown;
	private Animator animator;
	private float counter;
	public bool counterCheck;
	private bool changedTwice;
	public bool pedestalGone;


	// Start is called before the first frame update
	void Start()
    {
		PWOCrown = gameObject.GetComponent<SpriteRenderer>();
		Resources.LoadAll<Sprite>("Pedestal with Crown");
		animator = gameObject.GetComponent<Animator>();
		counter = 0.0f;
		counterCheck = false;
		changedTwice = GameObject.Find("Weapons Rack").GetComponent<WeaponsRack>().changedTwice;
		pedestalGone = false;

	}

	// Update is called once per frame
	void Update()
	{
		changedTwice = GameObject.Find("Weapons Rack").GetComponent<WeaponsRack>().changedTwice;
		if (changedTwice == true)
		{
			if (counterCheck == true)
			{
				counter++;
			}
			if (animator.GetCurrentAnimatorStateInfo(9).normalizedTime > 1)
            {
				pedestalGone = true;
				gameObject.GetComponent<Renderer>().enabled = false;
				gameObject.GetComponent<BoxCollider2D>().enabled = false;
			}

			//if (counter > 1200)
			//{
				
			//}
			if (Input.GetMouseButtonDown(1))
			{
				Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

				RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

				if (hit.collider != null)
				{
					if (hit.collider.gameObject.name == "Pedestal" && pedestalTouching == true)
					{
						counterCheck = true;

						animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Disappearing Pedestal");
					}

				}
			}
		}
        else
        {
			if (Input.GetMouseButtonDown(1))
			{
				Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

				RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

				if (hit.collider != null)
				{
					if (hit.collider.gameObject.name == "Pedestal" && pedestalTouching == true)
					{
						Debug.Log("you don't feel safe without your weapons!");
					}

				}
			}
			
        }

	}

	private void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.name.Equals("Player") == true)
		{
			pedestalTouching = true;

		}
	}

	private void OnCollisionExit2D(Collision2D target)
	{
		if (target.gameObject.name.Equals("Player") == true)
		{
			pedestalTouching = false;
		}
	}

	private void ChangeSprite(Sprite newsprite)
	{
		PWOCrown.sprite = newsprite;
	}

	public bool animationFinished()
    {
		return animator.GetCurrentAnimatorStateInfo(8).length > animator.GetCurrentAnimatorStateInfo(8).normalizedTime;
	}


}

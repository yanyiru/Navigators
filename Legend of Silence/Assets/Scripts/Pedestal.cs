using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{

	private bool pedestalTouching;

	public SpriteRenderer PWOCrown;
	public Sprite PWCrown;
	private Animator animator;
	public float normalizedTime;
	public float counter;
	public bool counterCheck;
	

	// Start is called before the first frame update
	void Start()
    {
		PWOCrown = gameObject.GetComponent<SpriteRenderer>();
		Resources.LoadAll<Sprite>("Pedestal with Crown");
		animator = gameObject.GetComponent<Animator>();
		normalizedTime = animator.GetCurrentAnimatorStateInfo(8).normalizedTime;
		counter = 0.0f;
		counterCheck = false;
	}

	// Update is called once per frame
	void Update()
	{
		print((int)gameObject.layer + normalizedTime + gameObject.name);
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
					counterCheck = true;
					
					//counter += Time.deltaTime;
					Debug.Log("Something was clicked!");
					//ChangeSprite(PWCrown);
					animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Disappearing Pedestal");
					if (counter == 11.333f)
					{
						print("destroyed");
						Destroy(gameObject);
					}
				}

			}
		}

		if (counterCheck == true)
        {
			counter++;
			print(counter);
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

	public bool animationFinished()
    {
		return animator.GetCurrentAnimatorStateInfo(8).length > animator.GetCurrentAnimatorStateInfo(8).normalizedTime;
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementwithAnim : MonoBehaviour
{


	public float moveSpeed;

	private Animator anim;

	private bool playerMoving;

	private Vector2 lastMove;

	private SpriteRenderer renderee;

	private Rigidbody2D Player;

	private bool pedestalTouching;

	private Animator animator;


	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		renderee = GetComponent<SpriteRenderer>();
		Player = GetComponent<Rigidbody2D>();

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
					animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("player1");
				}

			}
		}

		playerMoving = false;

		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
		{

			transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			playerMoving = true;
			lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
		}
		if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
		{

			transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
			playerMoving = true;
			lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
		}

		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetBool("PlayerMoving", playerMoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);

		if (transform.position.y < -0.6)
		{
			renderee.sortingOrder = 2;
		}
		if(transform.position.y > -0.6)
        {
			renderee.sortingOrder = 0;
        }


	}

	private void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.name.Equals("Pedestal") == true)
		{
			pedestalTouching = true;
			print(pedestalTouching);

		}
	}

	private void OnCollisionExit2D(Collision2D target)
	{
		if (target.gameObject.name.Equals("Pedestal") == true)
		{
			pedestalTouching = false;
			print(pedestalTouching);
		}
	}



}
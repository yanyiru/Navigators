using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsRack : MonoBehaviour

    

{

    private bool rackTouching;
    private bool changedOnce;
    public bool changedTwice;
    public SpriteRenderer rack;
    public Sprite noBow;
    public Sprite emptyRack;

    // Start is called before the first frame update
    void Start()
    {
        rack = gameObject.GetComponent<SpriteRenderer>();
        Resources.LoadAll<Sprite>("Weapons Rack_1");
        Resources.LoadAll<Sprite>("Weapons Rack_0");
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
                if (hit.collider.gameObject.name == "Weapons Rack" && rackTouching == true)
                {
                    if (changedOnce == false)
                    {
                        Debug.Log("Something was clicked!");
                        ChangeSprite(noBow);
                        changedOnce = true;
                    }
                    else if(changedOnce==true && changedTwice == false)
                    {
                        Debug.Log("Something was clicked!");
                        ChangeSprite(emptyRack);
                        changedTwice = true;
                    }

                    
                }

            }
        }

    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.name.Equals("Player") == true)
        {
            rackTouching = true;
            print(rackTouching);

        }
    }

    private void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.name.Equals("Player") == true)
        {
            rackTouching = false;
            print(rackTouching);
        }
    }

    private void ChangeSprite(Sprite newsprite)
    {
        rack.sprite = newsprite;
    }
}

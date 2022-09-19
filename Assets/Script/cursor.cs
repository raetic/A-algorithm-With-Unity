using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{

    public Texture2D cursorTexture ;    
    public Vector2 adjustHotSpot = Vector2.zero;  
    private Vector2 hotSpot;
    private Vector3 mousePosition;
    [SerializeField] private Camera camera;
    [SerializeField] GameObject effectPrefebs;
    public void Start(){        
        StartCoroutine ("MyCursor");
        hotSpot.x = cursorTexture.width / 2;
        hotSpot.y = cursorTexture.height / 2;
    }      
    IEnumerator MyCursor() {        
 
        yield return new WaitForEndOfFrame();    
        Cursor.SetCursor (cursorTexture, hotSpot, CursorMode.Auto);  
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          
            mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, -3);
            GameObject effectprefeb = Instantiate(effectPrefebs, mousePosition,transform.rotation);
        }
    }

}

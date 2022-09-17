using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Transform tra;
    Vector3 mousePositon;
    [SerializeField] Camera camera;
    [SerializeField] Pathfinding path;

    Animator anim;
    void Start()
    {
        tra = GetComponent<Transform>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
     void Update()
     {
         if (Input.GetMouseButtonDown(0))
         {
             mousePositon = camera.ScreenToWorldPoint(Input.mousePosition);
             mousePositon = new Vector3(mousePositon.x, mousePositon.y, 0);
             anim.SetBool("Run", true);
         }
         if (tra.transform.position != mousePositon)
         {

             tra.position=Vector3.MoveTowards(tra.transform.position, mousePositon, Time.deltaTime*3);
             if (tra.position.x < mousePositon.x)
             {
                 tra.localScale = new Vector3(-1, 1, 1);
             }
             else if(tra.position.x>mousePositon.x)
             {
                 tra.localScale = new Vector3(1, 1, 1);
             }
             if (tra.position == mousePositon)
             {
                 anim.SetBool("Run",false);
             }           
         }
     }
    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePositon = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePositon = new Vector3(mousePositon.x, mousePositon.y, 0);
            
        }
    }*/

}

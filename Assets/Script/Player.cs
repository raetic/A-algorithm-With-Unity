using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Vector3 mousePosition;
    [SerializeField] Camera camera;
    [SerializeField] Pathfinding path;

    Animator anim;
    List<Node> myWay;
    Node targetNode;
    void Start()
    {
        anim = GetComponent<Animator>();
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);
            List<Node> newWay = path.PathFind(transform.position, mousePosition);
            if (newWay != null) //path를 찾아오지 못하면 이동하지 않는다.
            //즉, 이동 불가능한 곳 클릭 시 아예 이동하지 않도록 설정이 되어있는데,
            //이는 게임마다 다르기 때문에 본인이 원하는 방식으로 수정을 하면 된다.
            {
                StopCoroutine("move");
                anim.SetBool("Run", true);
                myWay = newWay;
                StartCoroutine("move");
                if (transform.position.x < mousePosition.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (transform.position.x > mousePosition.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }

        }

    }
    IEnumerator move()
    {
        int idx = 0;
        targetNode = myWay[0]; //시작 점
        while (true)
        {
            if (transform.position == targetNode.myPos) //내위치가 타켓 노드까지 왔다면,
            //새로운 타겟 노드를 설정해줘야한다.
            {
                idx++; //인덱스 값을 올려서 다음 경로의 노드 탐색
                if (idx >= myWay.Count) //만약 인덱스값이 경로의 개수와 같아진다면, 도착했음을 뜻함
                {
                    anim.SetBool("Run", false);
                    yield break; //빠져나와준다.
                }
                targetNode = myWay[idx];
                if (transform.position.x < targetNode.myPos.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (transform.position.x > targetNode.myPos.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, targetNode.myPos, Time.deltaTime * 10);
            //타겟 노드까지 이동해준다.
            yield return null;
        }
    }

}
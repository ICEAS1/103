using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueContr : MonoBehaviour
{
    // Start is called before the first frame update
    int hp=100;
    int time=20;
    public CharacterController contr;

    float speed=12f;

    void Start()
    {
        contr=GetComponent<CharacterController>();
        InvokeRepeating("forInvoke",2.0f,2.0f);
        print(hp);
    }

    // Update is called once per frame
    void forInvoke()
    {
        time=time-1;
        hp=hp-1;
        print(time);
        FindObjectOfType<HeathBar>().decreaseValue(hp);
        if(time==0)
        {
            CancelInvoke();
            FindObjectOfType<HeathBar>().decreaseValue(hp);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown("space")){
            hp=hp-5;
            FindObjectOfType<HeathBar>().decreaseValue(hp);
        }
        if(hp==0){
            Destroy(gameObject);
        }

        float vertical=Input.GetAxis("Vertical");
        float horizontal=Input.GetAxis("Horizontal");

        contr.Move(transform.forward*speed*vertical*Time.deltaTime);
        contr.Move(transform.right*speed*horizontal*Time.deltaTime);
    }
    void OnControllerColliderHit(ControllerColliderHit CCH)
    {
        if(CCH.transform.tag=="med"){
            hp=hp+100;
            if(hp>100){
                hp=100;
            }
            Destroy(CCH.transform.gameObject);
            FindObjectOfType<HeathBar>().decreaseValue(hp);
            print(hp);
        }
        if(CCH.transform.tag=="bomb"){
            hp=hp-90;
            Destroy(CCH.transform.gameObject);
            FindObjectOfType<HeathBar>().decreaseValue(hp);
            print(hp);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character_Animation : MonoBehaviour
{
    //public GameObject characterAnimation;
    public Text scoreBox;
    Rigidbody2D rigidbody;
    float speed = 4f;
    float jump = 7f;
    bool isJump = false;
    bool isRight = false;
    bool isLeft = false;
    bool isDown = false;
    int Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isJump)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump);
        }
        if(isRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        }
        if(isLeft)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y); //rigidbody.velocity.x-(speed/3)
            //transform.rotation = Quaternion.Euler(0, 180, 0);
            //float posX = this.transform.position.x;
            //float posY = this.transform.position.y-speed;
            //Vector2 pos = new Vector2(posX, posY);
            //this.transform.position = new Vector2(this.transform.position.x - speed, this.transform.position.y);
        }
        if(isDown)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump * 1.3f);
            isDown = false;
        }
        scoreBox.text = Score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="coin")
        {
            Score++;
            Destroy(collision.gameObject);
        }
    }

    public void pressJumpBtn()
    {
        //rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump);
        isJump = true;
    }
    public void leaveJumpBtn()
    {
        //rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y);
        isJump = false;
    }

    public void pressRightBtn()
    {
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        //rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        isRight = true;
    }
    public void leaveRightBtn()
    {
        //rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y);
        isRight = false;
    }

    public void pressLeftBtn()
    {
        ////rigidbody.velocity = new Vector2(rigidbody.velocity.x - speed, rigidbody.velocity.y);
        //transform.rotation = Quaternion.Euler(0, 180, 0);
        //float posX = this.transform.position.x - speed;
        //float posY = this.transform.position.y;
        //Vector2 pos = new Vector2(posX, posY);
        //this.transform.position = new Vector2(this.transform.position.x - speed, this.transform.position.y);
        isLeft = true;
    }
    public void leaveLeftBtn()
    {
        //rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y);
        isLeft = false;
    }

    public void pressDownBtn()
    {
        //rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y);
        isDown = false;
    }
    public void leaveDownBtn()
    {
        //rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump * 1.3f);
        isDown = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Camera : MonoBehaviour
{
    public GameObject characterAnimation;
    Vector3 posDif;
    // Start is called before the first frame update
    void Start()
    {
        posDif = transform.position - characterAnimation.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(characterAnimation.transform.position.x + posDif.x, transform.position.y, transform.position.z);
        transform.position = newPos;
    }
}

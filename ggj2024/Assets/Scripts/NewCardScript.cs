using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCardScript : MonoBehaviour
{
    public Animator animation;
    public Vector3 velocity;
    public float moveSpeed = 2f;
    public MainCharacterLogic charLogic;
    public Vector3 targetPosition;

    public float maxSpeed;
    // Start is called before the first frame update

    private void Awake()
    {
        charLogic = GameObject.FindGameObjectWithTag("mainCharacter").GetComponent<MainCharacterLogic>();
       
        if (charLogic.selectedCardIndex == 4)
        {
            targetPosition = new Vector3(3f, -2f, 0f);
        }
        if (charLogic.selectedCardIndex == 3)
        {
            targetPosition = new Vector3(0.5f, -2f, 0f);
        }
        if (charLogic.selectedCardIndex == 2)
        {
            targetPosition = new Vector3(-2f, -2f, 0f);
        }
        if (charLogic.selectedCardIndex == 1)
        {
            targetPosition = new Vector3(-4.5f, -2f, 0f);
        }
        if (charLogic.selectedCardIndex == 0)
        {
            targetPosition = new Vector3(-7f, -2f, 0f);
        }
    }

    void Start()
    {
        
        animation.SetTrigger("flipTheCard");
        // gameObject.transform.position = new Vector2(-4, -2);
    }

    private void FixedUpdate()
    {
        // transform.position = Vector3.LerpUnclamped(transform.position, targetPosition, Time.fixedDeltaTime);
        // transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref velocity ,moveSpeed,maxSpeed);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime*3f);
    }
}

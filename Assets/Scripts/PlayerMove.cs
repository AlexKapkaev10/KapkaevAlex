using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    Camera myCamera = null;

    [SerializeField] float speed = 5;

    Vector3 direction = Vector3.zero;

    Vector3 startPos = Vector3.zero;

    bool directionForward;

    bool startGame;

    bool gameOver;

    void Start()
    {
        myCamera = GetComponentInChildren<Camera>();
        startPos = transform.position;
    }

    void Update()
    {
        if (transform.position.y < startPos.y)
        {
            gameOver = true;
            RestartLevel();
        }

        MovementInput();

    }

    void MovementInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!gameOver)
                directionForward = !directionForward;
            if (!startGame)
                startGame = true;
        }

        if (startGame)
            transform.Translate(direction * Time.deltaTime * speed);
        
        if(directionForward)
            direction = Vector3.forward;
        else
            direction = Vector3.right;
    }

    void RestartLevel()
    {
        
        myCamera.gameObject.transform.SetParent(null);
        StartCoroutine(Restart());

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "diamond")
        {
            Destroy(other.gameObject);
            GameManager.instance.diamonds++;
            GameManager.instance.UpdateResourse();
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        GameManager.instance.Restart();
    }

}

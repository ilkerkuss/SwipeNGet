using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public delegate void ObjectEvents();
    public static event ObjectEvents ObjectPicked;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _chrSpeed = 1500f;


    void Start()
    {

    }

    private void FixedUpdate()
    {

    }

    void Update()
    {
        if (!CheckIsMoving() && GameManager.Instance.GameState == GameManager.GameStates.IsGamePlaying)
        {
            MoveCharacter();
        }

    }


    private void MoveCharacter()
    {

        if (MobileInput.Instance.swipeUp )
        {
            _rb.velocity += Vector3.forward * _chrSpeed * Time.fixedDeltaTime;
            AudioController.Instance.PlaySound("SwipeSound");
        }
        else if (MobileInput.Instance.swipeDown )
        {
            _rb.velocity += Vector3.back * _chrSpeed * Time.fixedDeltaTime;
            AudioController.Instance.PlaySound("SwipeSound");
        }
        else if (MobileInput.Instance.swipeLeft )
        { 
            _rb.velocity += Vector3.left * _chrSpeed * Time.fixedDeltaTime;
            AudioController.Instance.PlaySound("SwipeSound");
        }
        else if (MobileInput.Instance.swipeRight )
        {
            _rb.velocity += Vector3.right * _chrSpeed * Time.fixedDeltaTime;
            AudioController.Instance.PlaySound("SwipeSound");
        }
    }


    private bool CheckIsMoving()
    {
        if (_rb.velocity.magnitude > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            _rb.velocity = Vector3.zero;
        }

        else if (collision.transform.CompareTag("Pick"))
        {
            ObjectPicked?.Invoke(); //event invoke every pick collision

            Destroy(collision.gameObject);

            _rb.velocity = Vector3.zero;
            transform.position = collision.gameObject.transform.position;
        }

        else if (collision.transform.CompareTag("Teleport"))
        {
            collision.gameObject.tag = "Untagged";
            Destroy(collision.gameObject);

            _rb.velocity = Vector3.zero;
            if (GameObject.FindGameObjectWithTag("Teleport"))
            {
                transform.position = GameObject.FindGameObjectWithTag("Teleport").transform.position;
            }
            

        }
    }
}

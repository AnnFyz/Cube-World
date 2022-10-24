using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float speed;
    public float moveSpeed;
    public float ZoomSpeed = 50;
    Quaternion startRotation;

    [SerializeField] private Transform target;
    [SerializeField] private Camera cam;
    private bool topview;


    void Start()
    {

        transform.position = target.position + new Vector3(0, -0.5f, 0);
        topview = false;
    }

    void Update()
    {
        //transform.position = target.position + new Vector3(0, -0.5f, 0);

        if (topview == false)
        {
            if (Input.GetKey("q"))
            {
                transform.Rotate(0, speed * Time.deltaTime, 0);
            }

            if (Input.GetKey("e"))
            {
                transform.Rotate(0, -speed * Time.deltaTime, 0);
            }

            if (Input.GetKey("w"))
            {
                if (transform.position.y <= 0.75f)
                {
                    transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
                }
            }

            if (Input.GetKey("s"))
            {
                if (transform.position.y >= -0.75f)
                {
                    transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
                }
            }
        }

        if (topview == true)
        {
            if (Input.GetKey("q"))
            {

                cam.transform.Rotate(0, 0, 1);
            }

            if (Input.GetKey("e"))
            {
                cam.transform.Rotate(0, 0, -1);
            }
        }




        if (Input.GetKeyDown("1"))
        {
            Reposition();
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown("2"))
        {
            Reposition();
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }

        if (Input.GetKeyDown("3"))
        {


            Reposition();
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKeyDown("4"))
        {
            Reposition();
            transform.rotation = Quaternion.Euler(0, 135, 0);
        }

        if (Input.GetKeyDown("5"))
        {
            Reposition();
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKeyDown("6"))
        {
            Reposition();
            transform.rotation = Quaternion.Euler(0, 225, 0);
        }

        if (Input.GetKeyDown("7"))
        {
            Reposition();
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }

        if (Input.GetKeyDown("8"))
        {
            Reposition();
            transform.rotation = Quaternion.Euler(0, 315, 0);
        }

        if (Input.GetKeyDown("9"))
        {
            transform.rotation = Quaternion.Euler(56.25f, 0, 0);

            topview = true;
        }



        if (cam.orthographic)
        {
                cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;

        }
        else
        {
                cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
        }

    }

    void Reposition()
    {
        if (topview == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            cam.transform.rotation = Quaternion.Euler(33.75f, 0, 0);
            topview = false;
        }
    }
}

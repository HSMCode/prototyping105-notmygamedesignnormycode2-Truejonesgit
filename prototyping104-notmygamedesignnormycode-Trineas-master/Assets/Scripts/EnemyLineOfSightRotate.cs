using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineOfSightRotate : MonoBehaviour
{
    public GameManager gameManager;
   public float rotationSpeed;
   public float distance;
   public static bool isDetected = false;

   public LineRenderer lineofsight;
   public Gradient hitColor;
   public Gradient nonhitColor;

    public bool clockwise;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clockwise)
        {
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        
         RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        
        if(hitInfo.collider != null){

            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineofsight.SetPosition(1, hitInfo.point);
            lineofsight.colorGradient = hitColor;

            if(hitInfo.collider.CompareTag("Player")){
                isDetected = true;

                if(isDetected == true){
                    gameManager.EndGame();
                    isDetected = false;
                    }

               
            }
             if(hitInfo.collider.CompareTag("Frame")){
                    lineofsight.colorGradient = nonhitColor;
                }
                if(hitInfo.collider.CompareTag("Food")){
                    lineofsight.colorGradient = nonhitColor;
                }

        } else {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.white);
            lineofsight.SetPosition(1, transform.position + transform.right * distance);
            lineofsight.colorGradient = nonhitColor;
        }

        lineofsight.SetPosition(0, transform.position);
    }

   
}

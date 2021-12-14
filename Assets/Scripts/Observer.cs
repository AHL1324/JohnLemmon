using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    bool m_IsPLayerRange;
    public GameEnding gameEnding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsPLayerRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);

            //Almacena información del rayo
            RaycastHit raycastHit;

            //Existe algo que colisiona con el rayo, que sea el player
            if(Physics.Raycast(ray, out raycastHit))
            {
                //Está viendo algo
                if (raycastHit.collider.transform == player)
                {
                    //Está viendo a player
                    gameEnding.CaughtPlayer();
                    //Pillaron al player y se explica en el código GameEnding
                }


            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPLayerRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPLayerRange = false;
        }
          
    }
}

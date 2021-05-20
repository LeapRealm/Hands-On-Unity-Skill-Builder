// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FinishPad : MonoBehaviour
{
    private GameHandler gameHandler;

    private void Start()
    {
        //Challenge 3: 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            //This next line of code will console log an error until Challenge 3 is complete.
            gameHandler.RemovePlayerCubeFromList(other.gameObject.GetComponent<PlayerMovement>());
            Destroy(other.gameObject);
            //Challenge 4:  
        }
    }
}

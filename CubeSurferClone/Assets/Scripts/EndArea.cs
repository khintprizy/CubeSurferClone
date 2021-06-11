using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.mainCubeTag) || other.gameObject.CompareTag(Tags.playerGFXTag))
        {
            GameManager.instance.GameEnd();
        }
    }
}

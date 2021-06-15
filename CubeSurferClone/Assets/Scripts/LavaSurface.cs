using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSurface : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.mainCubeTag))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag(Tags.playerGFXTag))
        {
            GameManager.instance.GameWin();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrab : MonoBehaviour
{
    void AnimationCompleted()
    {
        GameObject.Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOARMaths : MonoBehaviour
{
    public static bool CloseEnoughNoY(Vector3 p_val1, Vector3 p_val2, float p_closeEnough)
    {
        p_val1.y = 0.0f;
        p_val2.y = 0.0f;
        return Vector3.Distance(p_val1, p_val2) < p_closeEnough;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Monitoring : MonoBehaviour
{
    public int fpsCount;
    private void Start()
    {
        Application.targetFrameRate = fpsCount;
    }
}

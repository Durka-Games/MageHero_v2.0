using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = string.Format("FPS: {0}\nFrameTime: {1}\nMaxFrameTime: {2}", 1 / Time.deltaTime, Time.deltaTime, Time.maximumDeltaTime);
    }
}

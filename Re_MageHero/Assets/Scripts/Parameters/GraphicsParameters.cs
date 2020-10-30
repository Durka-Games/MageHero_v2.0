using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsParameters
{



    public enum GraphicsPreset
    {


        Low,
        Middle,
        High,
        Ultra

    }

    public void SetDefault(GraphicsPreset preset)
    {

        switch (preset)
        {

            case GraphicsPreset.Low:



                break;

            case GraphicsPreset.Middle:



                break;

            case GraphicsPreset.High:



                break;

            case GraphicsPreset.Ultra:



                break;

        }

    }

}

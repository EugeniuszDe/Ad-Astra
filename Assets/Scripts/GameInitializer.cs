using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour 
{
	void Awake()
    {
        // initialize screen utils
        ScreenUtils.Initialize();
    }
}

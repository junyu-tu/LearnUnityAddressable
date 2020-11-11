using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Demo6UsingHosting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Addressables.InstantiateAsync("whitecube");

        Addressables.InstantiateAsync("redcube");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

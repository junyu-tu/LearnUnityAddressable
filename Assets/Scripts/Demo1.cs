using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Demo1 : MonoBehaviour
{
    public AssetReference blackCube;
    public AssetReference whiteCube;

    // Start is called before the first frame update
    void Start()
    {
        //加载并实例化
        blackCube.InstantiateAsync();
        whiteCube.InstantiateAsync();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Demo3LoadByAddressables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //1.通过类型和名称来加载
        var handle1 = Addressables.LoadAssetAsync<GameObject>("blackcube");
        handle1.Completed += arg =>
        {
            //加载完毕后实例化
            Instantiate(arg.Result);
        };
        //卸载方式
        //Addressables.Release(handle1);

        //2.通过名称加载<这个是加载并实例化>
        var handle2 = Addressables.InstantiateAsync("whitecube");
        //卸载方式
        //Addressables.ReleaseInstance(handle2);

        //3.通过名称加载场景
        var hScene = Addressables.LoadSceneAsync("cubeScene", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        //卸载方式
        //Addressables.UnloadSceneAsync(hScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

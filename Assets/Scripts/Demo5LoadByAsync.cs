using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Demo5LoadByAsync : MonoBehaviour
{
    //因为Addressable是异步  如果有些资源需要顺序加载  可以使用以下方式来实现
    public AssetReference A;
    public AssetReference B;
    public AssetReference C;


    // Start is called before the first frame update
    void Start()
    {
        //方式一：使用Completed回调 来达到异步变为同步
        //A.InstantiateAsync().Completed += e =>
        //{
        //    B.InstantiateAsync().Completed += t =>
        //    {
        //        C.InstantiateAsync().Completed += x =>
        //        {
        //            Debug.Log("Load is Over!!!");
        //        };
        //    };
        //};

        //方式二：使用协程
        StartCoroutine(SyncLoad());

        //方式三：使用关键字await/async  来进行顺序加载
        LoadAssetByAsync();
    }


    IEnumerator SyncLoad()
    {
        var handle = A.InstantiateAsync();
        yield return handle;

        handle = B.InstantiateAsync();
        yield return handle;

        C.InstantiateAsync();
    }

    async void LoadAssetByAsync()
    {
        var handle = A.InstantiateAsync();
        await handle.Task;

        handle = B.InstantiateAsync();
        await handle.Task;

        C.LoadAssetAsync<Texture>();

    }
}

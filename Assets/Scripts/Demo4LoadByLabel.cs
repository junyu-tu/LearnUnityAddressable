using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Demo4LoadByLabel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //批量加载一：加载属于同一个label的obj <这里的名称是label的名称>   需要一个callback
        //加载一个labels下的obj
        //Addressables.LoadAssetsAsync<GameObject>("haha", t =>
        //{
        //    Debug.Log(t.name);
        //}).Completed += e =>
        //{
        //    Debug.Log(e.Result.Count);
        //};

        //批量加载二：加载变体
        //比如一批贴图有两个质量  一个Normal  一个HD

        //如果单纯根据名称去加载一个obj 就会去加载 找到的第一个名为blackcube的obj
        //Addressables.LoadAssetAsync<GameObject>("blackcube").Completed += arg =>
        //{
        //    //加载完毕后 打印name
        //    Debug.Log(arg.Result.name);
        //};

        //去加载一系列  
        //Addressables.LoadAssetsAsync<GameObject>("blackcube", null).Completed += e =>
        // {
        //     Debug.Log(e.Result.Count);
        // };

        //如果在这两个obj里面 选择某一个 怎么去加载呢： 根据名称和label字段 进行筛选 加载
        //参数List里面的参数实际上 就是查询相关的条件《可以用地址+标签  也可以用双标签》
        //MergeMode.None 和 MergeMode.UseFirst  表示返回 查询到的第一个资源
        //MergeMode.Union          查询结果的并集
        //MergeMode.Intersection   查询结果的交集
        Addressables.LoadAssetsAsync<GameObject>(new List<object> { "blackcube","HD" }, null, Addressables.MergeMode.Intersection).Completed += arg =>
        {
            //加载完毕后 打印List
            Debug.Log(arg.Result.Count);
            foreach (var item in arg.Result)
            {
                Debug.Log(item.name);
                Instantiate(item);
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

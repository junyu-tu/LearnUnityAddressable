using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

public class Demo2LoadByAssetReference : MonoBehaviour
{
    public AssetReference blueCube;
    public AssetReference yellowCube;
    public AssetReferenceTexture redTex;
    public AssetReference cubeScene;

    private GameObject acheGo;

    //对Material 扩展AssetReference
    [Serializable]
    public class AssetReferenceMaterial : AssetReferenceT<Material>
    {
        public AssetReferenceMaterial(string guid) : base(guid) {
      
        }
    }
    public AssetReferenceMaterial blueMaterial;

    void Start()
    {
        //1.基本操作  prefab的加载并实例化
        //blueCube.InstantiateAsync();

        //2.可以添加回调方法  
        //yellowCube.InstantiateAsync().Completed += arg =>
        //{
        //    //获取当前实例化prefab的name
        //    Debug.Log("Obj Name: " + arg.Result.name);
        //    acheGo = arg.Result;
        //};
        //对应的卸载
        //yellowCube.ReleaseInstance(acheGo);

        //3.可以加载Texture   单纯的加载
        //redTex.LoadAssetAsync().Completed += arg =>
        //{
        //    //打印Texture的name  看是否加载成功
        //    Debug.Log("Texture Name: " + arg.Result.name);
        //};
        //对应的卸载
        //redTex.ReleaseAsset();

        //4.可以对相关属性组件进行扩展后  进行使用
        //使用扩展AssetReferenceMaterial
        blueMaterial.LoadAssetAsync().Completed += arg =>
        {
                //获取当前实例化prefab的name
                Debug.Log("Material Name: " + arg.Result.name);
        };

        //5.加载Sence  没有对应的卸载API  因为加载其他场景时自动释放
        //cubeScene.LoadSceneAsync();

    }

}

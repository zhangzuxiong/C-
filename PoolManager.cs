using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//预置物
public static class PrefabManagent {

    //预置物字典，键为预置物的名字，值为预置物的对象
    public static Dictionary<string, UnityEngine.Object> prefabDic = new Dictionary<string, UnityEngine.Object>();


    //属性访问器
    public static Dictionary<string, UnityEngine.Object> PrefabDic
    {
        get
        {
            if (prefabDic==null)
            {
                prefabDic = new Dictionary<string, UnityEngine.Object>();
            }
            return prefabDic;
        }

        set
        {
            prefabDic = value;
        }
    }


    //添加预置物
    public static void AddPrefab(string name)
    {
        prefabDic.Add(name, Resources.Load<UnityEngine.Object>(name));
    }


    //获取预置物
    public static UnityEngine.Object GetPrefab(string name)
    {
        if (prefabDic.ContainsKey(name)==false)
        {
            AddPrefab(name);
        }
        return prefabDic[name];
    }
}


//对象池
public class PoolGameObject  {

    //对象池容器
    private List<GameObject> poolObjectList = new List<GameObject>();

    //属性访问器
    public List<GameObject> PoolObjectList
    {
        get
        {
            if (poolObjectList==null)
            {
                poolObjectList = new List<GameObject>();
            }
            return poolObjectList;
        }
        set
        {
            poolObjectList = value;
        }
    }


    //获取对象池中的对象
    public GameObject GetGameObject(String name)
    {
        for (int i = 0; i < poolObjectList.Count; i++)
        {
            //判断容器中是否存在被关闭的对象
            if (poolObjectList[i].activeSelf == false)
            {
                poolObjectList[i].SetActive(true);
                return poolObjectList[i];
            }
        }

        //没有创建一个新的对象返回，并加入对象池
        //GameObject go = Resources.Load<GameObject>(name);
        GameObject go = GameObject.Instantiate((GameObject)PrefabManagent.GetPrefab(name));
        poolObjectList.Add(go);//将新创建的对象添加到对象池
        return go;
    }

}

/// <summary>
/// 对所有实例类的对象进行管理的类
/// </summary>
public static class PoolManagent
{
    //字典，保存所有对象池
    public static Dictionary<string, PoolGameObject> poolDic = new Dictionary<string, PoolGameObject>();

    //属性访问器
    public static Dictionary<string,PoolGameObject> PoolDic
    {
        get
        {
            if (poolDic==null)
            {
                poolDic = new Dictionary<string, PoolGameObject>();
            }
            return poolDic;
        }
        set
        {
            poolDic = value;
        }
    }

    //查找容器中是否存指定的对象池
    public static PoolGameObject GetPoolGameObject(string name)
    {
        //当前键对包含这个名字的对象
        if (poolDic.ContainsKey(name))
        {
            return poolDic[name];
        }
        else
        {
            //不存在当前键的对象池，新建一个对象池加入字典
            PoolGameObject poolGameObject = new PoolGameObject();
            poolDic.Add(name, poolGameObject);
            return poolGameObject;
        }
    }

    //实例化游戏对象
    public static GameObject GetGameObject(string name)
    {
        PoolGameObject poolGameObject = GetPoolGameObject(name);
        return poolGameObject.GetGameObject(name);
    }


    //逻辑上销毁游戏对象
    public static void Destory(GameObject game)
    {
        game.SetActive(false);
    }

}

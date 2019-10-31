using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class ReourcesManager
    {
        static Dictionary<string, GameObject> resDic = new Dictionary<string, GameObject>();

        //加载预置物:如果已经加载过，将这个预置物保存到字典
        public static GameObject Load(string path)
        {
            if (resDic.ContainsKey(path))
            {
                return resDic[path];
            }

            GameObject prefab = Resources.Load(path) as GameObject;
            resDic[path] = prefab;
            return prefab;
        }



        static Hashtable resTable = new Hashtable();
        //加载资源
        public static T Load<T>(string path) where T : UnityEngine.Object
        {
            if (resTable.ContainsKey(path))
            {
                return resTable[path] as T;
            }
            T t = Resources.Load<T>(path);
            resTable[path] = t;
            return t;
        }
    }
}

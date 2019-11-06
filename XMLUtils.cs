using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;


public static class XMLUtils 
{
    /// <summary>
    /// 在指定的路径创建一个XML文档，并且声称第一个节点为rootName的头结点
    /// </summary>
    /// <param name="path">生成XML文档的路径</param>
    /// <param name="rootName">头结点的名称，默认为root</param>
    public static void CreateXML(string path,string rootName="root")
    {
        char division = '/';//路径分割符
        for (int i = 0; i < path.Length; i++)
        {
            if (path[i]==division)
            {
                break;
            }
            if (i==path.Length-1)
            {
                division = '\\';
            }
        }
        string directory = path.Substring(0, path.LastIndexOf(division));

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement(rootName);
            xmlDoc.AppendChild(root);
            xmlDoc.Save(path);
        }
        if (!File.Exists(path))
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement(rootName);
            xmlDoc.AppendChild(root);
            xmlDoc.Save(path);
        }

    }


    /// <summary>
    /// 往xml文档中添加一条数据
    /// </summary>
    /// <param name="path">xml文档的地址</param>
    /// <param name="data">存储数据的字典</param>
    /// <param name="nodeName">添加的新节点的名称</param>
    /// <param name="rootName">xml文档头结点的名称，默认为root</param>
   public static void InsertOne(string path,Dictionary<string,System.Object> data,string nodeName = "node",string rootName="root")
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);

        XmlNode root = xmlDoc.SelectSingleNode(rootName);
        XmlElement newNode = xmlDoc.CreateElement(nodeName);
        foreach (var item in data)
        {
            newNode.SetAttribute(item.Key,item.Value.ToString());
        }
        root.AppendChild(newNode);

        xmlDoc.Save(path);
    }

    /// <summary>
    /// 批量保存数据到xml文档中
    /// </summary>
    /// <param name="path">xml文档的路径</param>
    /// <param name="data">保存数据的列表</param>
    /// <param name="nodeName">新节点的名称</param>
    /// <param name="rootName">头结点的名称，默认root</param>
    public static void InsertMany(string path,List<Dictionary<string,System.Object>> data,string nodeName = "node",string rootName = "root")
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);
        XmlNode root = xmlDoc.SelectSingleNode(rootName);
        for (int i = 0; i < data.Count; i++)
        {
            XmlElement newNode = xmlDoc.CreateElement(nodeName);
            foreach (var item in data[i])
            {
                newNode.SetAttribute(item.Key, item.Value.ToString());
            }
            root.AppendChild(newNode);
        }
        xmlDoc.Save(path);
    }

    /// <summary>
    /// 更新xml文档
    /// </summary>
    /// <param name="path">xml文档的路径</param>
    /// <param name="data">更新之后的数据</param>
    /// <param name="primaryKey">更新数据的主键</param>
    /// <param name="nodeName">更新的节点名称</param>
    /// <param name="rootName">xml头结点，默认root</param>
    public static void UpdateOne(string path, Dictionary<string, System.Object> data,string primaryKey ,string nodeName = "node", string rootName = "root")
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);
        XmlNode root = xmlDoc.SelectSingleNode(rootName);
        XmlNodeList list = root.ChildNodes;
        for (int i = 0; i < list.Count; i++)
        {
            XmlElement element = list[i] as XmlElement;
            if (element.Name==nodeName)
            {
                if (element.GetAttribute(primaryKey)==data[primaryKey].ToString())
                {
                    foreach (var item in data)
                    {
                        element.SetAttribute(item.Key, item.Value.ToString());
                    }
                    xmlDoc.Save(path);
                    break;
                }
            }
        }
    }

    /// <summary>
    /// 删除一条数据
    /// </summary>
    /// <param name="path">xml文档的路径</param>
    /// <param name="primaryKey">xml文档中节点的主键</param>
    /// <param name="value">主键对应的值</param>
    /// <param name="nodeName">删除节点的名称</param>
    /// <param name="rootName">xml文档头结点，默认root</param>
    public static void DeleteOne(string path, string primaryKey,string value, string nodeName = "node", string rootName = "root")
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);
        XmlNode root = xmlDoc.SelectSingleNode(rootName);
        XmlNodeList list = root.SelectNodes(nodeName);
        for (int i = 0; i < list.Count; i++)
        {
            XmlElement element = list[i] as XmlElement;
            if (element.GetAttribute(primaryKey) == value)
            {
                root.RemoveChild(element);
                xmlDoc.Save(path);
                break;
            }
        }
    }

    /// <summary>
    /// 查找一条数据
    /// </summary>
    /// <param name="path">xml文档的地址</param>
    /// <param name="keys">查找的关键字</param>
    /// <param name="primaryKey">查找的主键</param>
    /// <param name="value">查找主键对应的值</param>
    /// <param name="nodeName">查找的节点名称</param>
    /// <param name="rootName">xml文档的头结点，默认root</param>
    /// <returns>如果找到了返回找到的结果，否则返回null</returns>
    public static Dictionary<string, System.Object> SelectOne(string path,List<string> keys, string primaryKey,string value,string nodeName = "node",string rootName = "root")
    {
        Dictionary<string, System.Object> res = new Dictionary<string, object>();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);
        XmlNode root = xmlDoc.SelectSingleNode(rootName);
        XmlNodeList list = root.SelectNodes(nodeName);
        for (int i = 0; i < list.Count; i++)
        {
            XmlElement element = list[i] as XmlElement;
            if (value!=null)
            {
                if (element.GetAttribute(primaryKey)==value)
                {
                    for (int j = 0; j < keys.Count; j++)
                    {
                        res.Add(keys[j], element.GetAttribute(keys[j]));
                    }
                    return res;
                }
            }
            else
            {
                for (int j = 0; j < keys.Count; j++)
                {
                    res.Add(keys[j], element.GetAttribute(keys[j]));
                }
                return res;
            }
        }
        return null;
    }

    /// <summary>
    /// 查找一条数据
    /// </summary>
    /// <param name="path">xml文档的地址</param>
    /// <param name="keys">查找的关键字</param>
    /// <param name="key">查找的主键</param>
    /// <param name="nodeName">查找的节点名称</param>
    /// <param name="rootName">xml文档的头结点，默认root</param>
    /// <returns>如果找到了返回找到的结果，否则返回null</returns>
    public static Dictionary<string, System.Object> SelectOneByKey(string path, List<string> keys, string Key, string nodeName = "node", string rootName = "root")
    {
        Dictionary<string, System.Object> res = new Dictionary<string, object>();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);
        XmlNode root = xmlDoc.SelectSingleNode(rootName);
        XmlNodeList list = root.SelectNodes(nodeName);
        for (int i = 0; i < list.Count; i++)
        {
            XmlElement element = list[i] as XmlElement;
            for (int j = 0; j < keys.Count; j++)
            {
                res.Add(keys[j], element.GetAttribute(keys[j]));
            }
            return res;
        }
        return null;
    }
}

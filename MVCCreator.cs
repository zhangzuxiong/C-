using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

/*
* 作者：
* 代码思路：
* 代码功能：
* 日期：
*/

public class MVCCreator
{
    private static string thisGameObjectName = "";

    [MenuItem("GameObject/MVC自动工具/生成View层",false,0)]
    private static void CreateView()
    {
        GameObject obj = Selection.gameObjects[0];
        string name = obj.name;
        thisGameObjectName = name;
        string path = Application.dataPath + "/Scripts/Views";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName = path + "/" + name + ".cs";
        if (File.Exists(fileName))
        {
            throw new UnityException("当前已经有这个脚本，无法生成新的脚本");
        }
        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("using System.Collections;");
                sw.WriteLine("using System.Collections.Generic;");
                sw.WriteLine("using UnityEngine;");
                sw.WriteLine("using UnityEngine.UI;");
                sw.WriteLine();

                sw.WriteLine("public class " + name + " : MonoBehaviour");
                sw.WriteLine("{");
                WriteComponent(sw, obj.transform);
                sw.WriteLine("}");
            }
        }
        AssetDatabase.Refresh();
    }

    private static string GetFindMethodString(string name,string parentName,string thisType)
    {
        string parent = "";
        if (parentName != thisGameObjectName)
        {
            parent = ChangeFirstCharUpper(parentName) + ".transform";
        }
        else
        {
            parent = "transform";
        }
        StringBuilder sb = new StringBuilder();
        sb.Append(parent);
        sb.Append(".Find(");
        sb.Append('"');
        sb.Append(name);
        sb.Append('"');
        sb.Append(")");
        sb.Append(".GetComponent<");
        sb.Append(thisType);
        sb.Append(">();");
        return sb.ToString();
    }

    private static void WriteComponent(StreamWriter sw,Transform trans)
    {
        for (int i = 0; i < trans.childCount; i++)
        {
            Transform _trans = trans.GetChild(i);
            string name = _trans.name;
            string thisType = "";
            string thisName = "";
            if (name.Contains("_"))
            {
                string[] names = name.Split('_');
                thisType = names[0];
            }
            thisName = ChangeFirstCharLower(name);
            thisType = GetTypeByString(thisType);
            //写出字段
            sw.WriteLine("    " + thisType + " " + thisName + ";");
            //写出属性
            sw.WriteLine();
            sw.WriteLine("    " + "public " + thisType + " " + ChangeFirstCharUpper(thisName));
            sw.WriteLine("    " + "{");
            sw.WriteLine("    " + "    " + "get");
            sw.WriteLine("    " + "    " + "{");
            sw.WriteLine("    " + "    " + "    " + "if(" + thisName + " == null)");
            sw.WriteLine("    " + "    " + "    " + "{");
            sw.WriteLine("    " + "    " + "    " + "    " + thisName + " = " + GetFindMethodString(name,trans.name,thisType));
            sw.WriteLine("    " + "    " + "    " + "}");
            sw.WriteLine("    " + "    " + "    " + "return " + thisName + ";");
            sw.WriteLine("    " + "    " + "}");
            sw.WriteLine("    " + "}");
            sw.WriteLine();
            if (_trans.childCount > 0)
            {
                WriteComponent(sw, _trans);
            }
        }
    }

    private static string GetTypeByString(string thisType)
    {
        switch (thisType)
        {
            case "Text":
                return "Text";
            case "Button":
                return "Button";
            case "Img":
                return "Image";
            case "Tog":
                return "Toggle";
            case "Slider":
                return "Slider";
            case "IF":
                return "InputField";
            default:
                return "Transform";
        }
    }

    private static string ChangeFirstCharLower(string content)
    {
        char[] charArr = content.ToCharArray();
        if (charArr[0] >= 'A' && charArr[0] <= 'Z')
        {
            charArr[0] = (char)(charArr[0] + ('a' - 'A'));
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < charArr.Length; i++)
        {
            sb.Append(charArr[i]);
        }
        return sb.ToString();
    }

    private static string ChangeFirstCharLower1(string content)
    {
        StringBuilder sb = new StringBuilder(content);
        if (sb[0] >= 'A' && sb[0] <= 'Z')
        {
            sb[0] = (char)(sb[0] + 'a' - 'A');
        }
        return sb.ToString();
    }

    private static string ChangeFirstCharUpper(string content)
    {
        char[] charArr = content.ToCharArray();
        if (charArr[0] >= 'a' && charArr[0] <= 'z')
        {
            charArr[0] = (char)(charArr[0] + ('A' - 'a'));
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < charArr.Length; i++)
        {
            sb.Append(charArr[i]);
        }
        return sb.ToString();
    }
}

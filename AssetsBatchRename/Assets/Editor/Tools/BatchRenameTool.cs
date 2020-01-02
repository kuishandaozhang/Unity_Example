using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

using Object = UnityEngine.Object;

/// <summary>
/// 资源批量重命名
/// </summary>
public class BatchRenameTool : MonoBehaviour
{
    private const string UPSET_NAME = "_UPSET_NAME_";   //打乱名字马甲，用于预改名，否则当有文件名称在改名规则内，会因为重名影响文件名称修改

    [MenuItem("Assets/BatchRename")]
    private static void AssetsBatchRename()
    {
        Object[] m_objects = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);//选中的所有对象
        if (m_objects == null || m_objects.Length <= 0) return;

        SortAsFileName(ref m_objects);              //文件根据名称排序，否则是乱的

        BatchRename(m_objects, UPSET_NAME);         //先打乱名称，防止名称重复改名失败

        string newName = "Tex_";                    //名字马甲
        int index = 0;                              //序号
        BatchRename(m_objects, newName, index);     //批量改名
    }

    /// <summary>
    /// 批量改名
    /// </summary>
    /// <param name="assets">文件</param>
    /// <param name="newName">新名称马甲</param>
    /// <param name="startIndex">起始序号</param>
    private static void BatchRename(Object[] assets, string newName, int startIndex = 0)
    {
        foreach (Object item in assets)
        {
            if (Path.GetExtension(AssetDatabase.GetAssetPath(item)) != "")  //判断路径是否为空
            {
                string path = AssetDatabase.GetAssetPath(item);
                AssetDatabase.RenameAsset(path, newName + startIndex);
                startIndex++;
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// 将文件按名称排序
    /// </summary>
    private static void SortAsFileName(ref Object[] assets)
    {
        Array.Sort(assets, delegate (Object x, Object y) { return x.name.CompareTo(y.name); });
    }
}

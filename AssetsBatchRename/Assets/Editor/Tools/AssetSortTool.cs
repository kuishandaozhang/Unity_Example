using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetSortTool : MonoBehaviour
{
    //调用方法：

　　private void SortFiles()
    {
        //string filePath = "E:\\";
        //DirectoryInfo di = new DirectoryInfo(filePath);

        //FileInfo[] arrFi = di.GetFiles("*.*");
        //SortAsFileName(ref arrFi);

        //for (int i = 0; i < arrFi.Length; i++)
        //    Response.Write(arrFi[i].Name + "：<br />");
    }

    //上面的代码是对 E 盘根目录下的所有文件排序，代码测试通过，可直接调用。


    //1、按名称顺序排列

    /// <summary>
    　　/// C#按文件名排序（顺序）
    　　/// </summary>
    　　/// <param name="arrFi">待排序数组</param>
    private void SortAsFileName(ref FileInfo[] arrFi)
    {
        Array.Sort(arrFi, delegate (FileInfo x, FileInfo y) { return x.Name.CompareTo(y.Name); });
    }


    //2、按名称倒序排列

    /// <summary>
    　　/// C#按文件名排序（倒序）
    　　/// </summary>
    　　/// <param name="arrFi">待排序数组</param>
    private void SortAsFileName_Reverse(ref FileInfo[] arrFi)
    {
        Array.Sort(arrFi, delegate (FileInfo x, FileInfo y) { return y.Name.CompareTo(x.Name); });
    }

    //调用方法跟顺序排列一样，就不举例了。

 

　　//3、按创建时间顺序排列

    /// <summary>
　　/// C#按创建时间排序（顺序）
　　/// </summary>
　　/// <param name="arrFi">待排序数组</param>
    private void SortAsFileCreationTime(ref FileInfo[] arrFi)
    {
        Array.Sort(arrFi, delegate (FileInfo x, FileInfo y) { return x.CreationTime.CompareTo(y.CreationTime); });
    }

    //调用方法与上同。

 

　　//4、按创建时间倒序排列

/// <summary>
　　/// C#按创建时间排序（倒序）
　　/// </summary>
　　/// <param name="arrFi">待排序数组</param>
  private void SortAsFileCreationTime_Reverse(ref FileInfo[] arrFi)
    {
        Array.Sort(arrFi, delegate (FileInfo x, FileInfo y) { return y.CreationTime.CompareTo(x.CreationTime); });
    }

    //调用方法与上同。

 

 

　　//二、C#文件夹排序
    //调用方法：

　　private void FolderSort()
    {
        //string filePath = "E:\\";
        //DirectoryInfo di = new DirectoryInfo(filePath);

        //DirectoryInfo[] arrDir = di.GetDirectories();
        //SortAsFolderName(ref arrDir);

        //for (int i = 0; i < arrDir.Length; i++)
        //    Response.Write(arrDir[i].Name + "：<br />");
    }

    //上述代码是对 E 盘根目录下的所有文件夹按名称顺序排列，代码也通过 Visual studio 2010 测试。


    //1、按文件夹名称顺序排列

    /// <summary>
    　　/// C#按文件夹名称排序（顺序）
    　　/// </summary>
    　　/// <param name="dirs">待排序文件夹数组</param>
    private void SortAsFolderName(ref DirectoryInfo[] dirs)
    {
        Array.Sort(dirs, delegate (DirectoryInfo x, DirectoryInfo y) { return x.Name.CompareTo(y.Name); });
    }


    //2、按文件夹名称倒序排列

    /// <summary>
    /// C#按文件夹名称排序（倒序）
    /// </summary>
    /// <param name="dirs">待排序文件夹数组</param>
    private void SortAsFolderName_Reverse(ref DirectoryInfo[] dirs)
    {
        Array.Sort(dirs, delegate (DirectoryInfo x, DirectoryInfo y) { return y.Name.CompareTo(x.Name); });
    }

 

　　//3、按文件夹创建时间顺序排列

/// <summary>
　　/// C#按文件夹夹创建时间排序（顺序）
　　/// </summary>
　　/// <param name="dirs">待排序文件夹数组</param>
    private void SortAsFolderCreationTime(ref DirectoryInfo[] dirs)
    {
        Array.Sort(dirs, delegate (DirectoryInfo x, DirectoryInfo y) { return x.CreationTime.CompareTo(y.CreationTime); });
    }


　　//4、按文件夹创建时间倒序排列

/// <summary>
　　/// C#按文件夹创建时间排序（倒序）
　　/// </summary>
　　/// <param name="dirs">待排序文件夹数组</param>
    private void SortAsFolderCreationTime_Reverse(ref DirectoryInfo[] dirs)
    {
        Array.Sort(dirs, delegate (DirectoryInfo x, DirectoryInfo y) { return y.CreationTime.CompareTo(x.CreationTime); });
    }

    //如果要按文件或文件夹的最后修改时间排序，方法也是一样的，只需把 CreationTime 改为 LastWriteTime 即可。
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileIO 
{ 
    public static void WriteStringToFile(string filename, string content, bool append)
    {
        StreamWriter sw = new StreamWriter(filename, append);
        sw.WriteLine(content);
        sw.Close();
    }
}

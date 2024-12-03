using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager
{
    public static List<string> ReadTextFile(string filePath, bool includeBlanklines = true)
    {
        if (!filePath.StartsWith('/'))
            filePath = FilePath.root + filePath;
        List<string> lines = new List<string>();
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string Line = sr.ReadLine();
                    if (includeBlanklines || !string.IsNullOrWhiteSpace(Line))
                        lines.Add(Line);
                }
            }

        }
        catch (FileNotFoundException ex)
        {
            Debug.LogError($"File not found: '{ex.FileName}'");
        }
        return lines;
    }
}
   
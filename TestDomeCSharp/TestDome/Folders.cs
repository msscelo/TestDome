using System;
using System.Collections.Generic;
using System.Xml;

public class Folders
{
    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        var foldernames = new List<string>();
        var xmlreader = XmlReader.Create(new System.IO.StringReader(xml));
        while (xmlreader.Read())
        {
            if (xmlreader.NodeType == XmlNodeType.Element && xmlreader.Name.ToLower() == "folder")
            {
                var name = xmlreader.GetAttribute("name");
                if (name != null && name[0] == startingLetter)//(!string.IsNullOrEmpty(name))
                {
                    foldernames.Add(name);
                }

            }
        }

        return foldernames;
    }

    public static void TestFolder(string[] args)
    {
        string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";

        foreach (string name in Folders.FolderNames(xml, 'u'))
        {
            Console.WriteLine(name);
        }
    }
}

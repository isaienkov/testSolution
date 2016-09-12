using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EmpeekTestTask.Models
{
    public class Document
    {
        public string Name { get; set; }            // name
        public long Size { get; set; }              // size in Mb
        public int Type { get; set; }               // Type (file or directory)
        public string Pat { get; set; }             // full path

        // Get list of documents and directories in a curent directory
        public IEnumerable<Document> findAll(string currentPath)
        {
            Document[] docs;
            DirectoryInfo directory = new DirectoryInfo(currentPath);
            try
            {
                var files = directory.GetFiles();
                var dirs = directory.GetDirectories();

                docs = new Document[files.Count() + dirs.Count()];

                int i = 0;
                foreach (FileInfo finf in files)
                {
                    docs[i++] = new Document { Name = finf.Name, Size = finf.Length / 1024 / 1024, Type = 1, Pat = finf.DirectoryName };
                }
                foreach (var dr in dirs)
                {
                    docs[i++] = new Document { Name = dr.Name, Size = 0, Type = 0, Pat = dr.FullName };
                }

            }
            catch (Exception ex)
            {
                docs = new Document[0];
            }


            return docs;
        }
    }
}
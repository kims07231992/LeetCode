using System.Collections.Generic;
using System.Text;

namespace Design_In_Memory_File_System
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        /// <summary>
        /// Time Complexity: O(N*L) where N is number of words in wordList and L is length of beginWord
        /// Space Complexity: O(N) 
        /// </summary>
        private static void Run()
        {
            var fileSystem = new FileSystem();

            fileSystem.Ls("/"); // []
            fileSystem.Mkdir("/a/b/c"); // null
            fileSystem.AddContentToFile("/a/b/c/d", "hello"); // null
            fileSystem.Ls("/"); // ["a"]
            fileSystem.ReadContentFromFile("/a/b/c/d"); // hello

        }

        public class File
        {
            public bool isFile;
            public Dictionary<string, File> children = new Dictionary<string, File>();
            public StringBuilder content = new StringBuilder();
        }

        public class FileSystem
        {
            private File root;

            public FileSystem()
            {
                root = new File();
            }

            /// <summary>
            /// Time Complexity: O(N + MlogM) where N is number of directories and M is number of files in directory
            /// Given a path in string format. 
            /// If it is a file path, return a list that only contains this file's name. 
            /// If it is a directory path, return the list of file and directory names in this directory. 
            /// Your output (file and directory names together) should in lexicographic order.
            /// </summary>
            public IList<string> Ls(string path)
            {
                var dirs = path.Split("/");
                var currentFile = root;
                var result = new List<string>();
                var name = string.Empty;
                foreach (var dir in dirs)
                {
                    if (dir.Length == 0)
                        continue;

                    if (!currentFile.children.ContainsKey(dir))
                    {
                        return result;
                    }
                    currentFile = currentFile.children[dir];
                    name = dir;
                }

                if (currentFile.isFile)
                {
                    result.Add(name);
                }
                else
                {
                    foreach (var key in currentFile.children.Keys)
                    {
                        result.Add(key);
                    }
                    result.Sort();
                }

                return result;
            }

            /// <summary>
            /// Time Complexity: O(N*L) where N is number of words in wordList and L is length of beginWord
            /// Space Complexity: O(N) 
            /// Given a directory path that does not exist, you should make a new directory according to the path. 
            /// If the middle directories in the path don't exist either, you should create them as well. 
            /// This function has void return type.
            /// </summary>
            public void Mkdir(string path)
            {
                var dirs = path.Split("/");
                var currentFile = root;
                foreach (var dir in dirs)
                {
                    if (dir.Length == 0)
                        continue;

                    if (!currentFile.children.ContainsKey(dir))
                    {
                        var file = new File();
                        currentFile.children.Add(dir, file);
                    }
                    currentFile = currentFile.children[dir];
                }
            }

            /// <summary>
            /// Time Complexity: O(N) where N is number of directories
            /// Given a file path and file content in string format. 
            /// If the file doesn't exist, you need to create that file containing given content. 
            /// If the file already exists, you need to append given content to original content. 
            /// This function has void return type.
            /// </summary>
            public void AddContentToFile(string filePath, string content)
            {
                var dirs = filePath.Split("/");
                var currentFile = root;
                foreach (var dir in dirs)
                {
                    if (dir.Length == 0)
                        continue;

                    if (!currentFile.children.ContainsKey(dir))
                    {
                        var file = new File();
                        currentFile.children.Add(dir, file);
                    }
                    currentFile = currentFile.children[dir];
                }
                currentFile.isFile = true;
                currentFile.content.Append(content);
            }

            /// <summary>
            /// Time Complexity: O(N) where N is number of directories
            /// Given a file path, return its content in string format.
            /// </summary>
            public string ReadContentFromFile(string filePath)
            {
                var dirs = filePath.Split("/");
                var currentFile = root;
                foreach (var dir in dirs)
                {
                    if (dir.Length == 0)
                        continue;

                    if (!currentFile.children.ContainsKey(dir))
                    {
                        var file = new File();
                        currentFile.children.Add(dir, file);
                    }
                    currentFile = currentFile.children[dir];
                }

                return currentFile.content.ToString();
            }
        }
    }
}

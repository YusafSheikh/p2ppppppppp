namespace p2ppppppppp.Managers
{
    public class FileManager
    {
        private static readonly Dictionary<string, List<string>> _fileDictionary = new Dictionary<string, List<string>>();

        public IEnumerable<string> GetAllFileNames()
        {
            return _fileDictionary.Keys;
        }

        public IEnumerable<string> GetFileEndPoints(string fileName)
        {
            if (_fileDictionary.ContainsKey(fileName))
            {
                return _fileDictionary[fileName];
            }
            else
            {
                return null;
            }
        }
    }
}

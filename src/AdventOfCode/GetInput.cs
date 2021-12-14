
using System.IO;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class GetInput
    {
        public GetInput()
        {
        }

        public string GetInputAsString(int dayNumber){
            string path = $@"data/{dayNumber}.txt";

        // This text is added only once to the file.
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Input file not found", path);
        }

        string readText = File.ReadAllText(path);
        return readText;
        }
    }
}
using System.Text;

namespace SimplifyStringPath;
public class Class1
{
    public string SimplifyPath(string path)
    {
        Stack<string> stack = new Stack<string>();
        path = path.Replace("//", "/").TrimEnd('/');

        foreach (string s in path.Split("/", StringSplitOptions.RemoveEmptyEntries))
        {
            if (s == ".." && stack.Count > 0)
            {
                stack.Pop();
            }
            else if (s == ".." || s == ".")
            {
                continue;
            }
            else
            {
                stack.Push(s);
            }
        }

        StringBuilder stringBuild = new StringBuilder();

        while (stack.Count > 0)
        {
            stringBuild.Insert(0, "/" + stack.Pop());
        }

        if (stringBuild.Length == 0)
        {
            stringBuild.Append('/');
        }

        return stringBuild.ToString();
    }
}

namespace ReverseWords
{
    public static class Model
    {
        public static string ReverseWords(string str)
        {
            if (string.IsNullOrEmpty(str)) { return str; }
            else
            {
                string[] arr = DivideString(str);
                string resultString = arr[arr.Length - 1];
                for (int i = arr.Length - 2; i >= 0; i--)
                {
                    resultString = string.Concat(resultString, " ", arr[i]);
                }
                return resultString;
            }
        }
        
        public static string[] DivideString(string str)
        {
            if (string.IsNullOrEmpty(str)) { return null; }
            else
            {
                return str.Split(' ');
            }
        }
    }
}

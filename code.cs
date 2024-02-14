static string split_sum(string[] content, int start, int end)
{
    int i = 0;
    string output = "";
    foreach (string line in content)
    {
        if ((i >= start)&&(i <= end))
        {
            output += line + " ";
        }
        i++;
    }
    return output;
}

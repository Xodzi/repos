string[] a = new string[] { "NORTH","NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST", "SOUTH" };
dirReduc(a);

static string[] dirReduc(string[] arr)
{
    List<string> res = new List<string>(arr);
    bool flagNS = NorSCheck(res);
    bool flagEW = EorWCheck(res);
    while(flagNS || flagEW)
    {
        if(flagNS)
        {
            res.Remove("NORTH");
            res.Remove("SOUTH");
        }
        if(flagEW)
        {
            res.Remove("EAST");
            res.Remove("WEST");
        }
        flagNS = NorSCheck(res);
        flagEW = EorWCheck(res);
    }
    int stop = 5;
    return res.ToArray();
}

static bool NorSCheck(List<string> ls)
{
    for(int i = 0; i < ls.Count - 1; i++)
    {
        if (ls[i] == "NORTH" & ls[i+1]=="SOUTH" || ls[i]== "SOUTH" & ls[i + 1] == "NORTH")
        {
            return true;
        }
    }
    return false;
}
static bool EorWCheck(List<string> ls)
{
    for (int i = 0; i < ls.Count - 1; i++)
    {
        if (ls[i] == "EAST" & ls[i + 1] == "WEST" || ls[i] == "WEST" & ls[i + 1] == "EAST")
        {
            return true;
        }
    }
    return false;
}
using System.Collections.Generic;

// Class option to structor the data comming from the JSON
// A list is created with all the data
[System.Serializable]
public class Option
{
    public int id;
    public string insult;
    public string answer;
}

[System.Serializable]
public class OptionList
{
    public List<Option> option;
}

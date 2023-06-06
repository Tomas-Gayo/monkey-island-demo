using UnityEngine;

public class JSONReader : MonoBehaviour
{ 
    public OptionList myOptionList = new OptionList();

    // Get the JSON file from resources folder and save the data in an object
    void Start()
    {
        var jsonTextFile = Resources.Load<TextAsset>("Text/options");
        myOptionList = JsonUtility.FromJson<OptionList>(jsonTextFile.text);
    }    

    // The following methods can access to the list and get the needed values
    public Option getOptionByID(int id)
    {
        return myOptionList.option.Find(option => option.id == id);
    }

    public int getOptionsSize()
    {
        return myOptionList.option.Count;
    }
}

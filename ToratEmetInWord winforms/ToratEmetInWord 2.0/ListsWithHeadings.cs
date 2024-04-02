using System.Collections.Generic;

// Define a class to manage multiple lists with headings
public class ListsWithHeadings
{
    // Dictionary to store lists with headings
    public Dictionary<string, List<string>> ListDictionary { get; set; }

    // Constructor to initialize the dictionary
    public ListsWithHeadings()
    {
        ListDictionary = new Dictionary<string, List<string>>();
    }

    // Method to add a list with a specified heading
    public void AddList(string heading, List<string> items)
    {
        if (!ListDictionary.ContainsKey(heading))
        {
            ListDictionary.Add(heading, items);
        }
    }

    // Method to remove a list by heading
    public void RemoveList(string heading)
    {
        if (ListDictionary.ContainsKey(heading))
        {
            ListDictionary.Remove(heading);
        }
    }

    // Method to get a list by heading
    public List<string> GetList(string heading)
    {
        if (ListDictionary.ContainsKey(heading))
        {
            return ListDictionary[heading];
        }
        return null;
    }
}



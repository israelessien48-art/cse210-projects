using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public Entry(string prompt, string response)
    {
        _date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        _prompt = prompt;
        _response = response;
    }

    // Overloaded constructor for loading existing entries
    public Entry(string prompt, string response, string date)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
    }
}

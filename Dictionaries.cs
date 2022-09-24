
namespace Collections
{
    class Dictionaries
    {
        // key: 'd', value: "Dot" "Developer"
        private static Dictionary<char, List<string>> lettersDictionary = new Dictionary<char, List<string>>();
        public static void Sort(string text)
        {
            foreach (var word in text.Split()) // Here we split each word at the above article by space => article is considered as List of strings we will use each word downthere.
            {
                foreach (var ch in word)// now we split each word to chars 
                {
                    char c = Char.ToLower(ch);
                    if (!lettersDictionary.ContainsKey(c)) // first letter of word "Dot" is 'd' and it will be considered as Dictionary Key in the 1st cycle 
                                                           //this condition will be performed just in the first time of key 'd', Dot will be added by this condition, the other words which has d in it after dot will be added by " else "
                                                           //this will happen with each new key, which wasn't added before.
                    {
                        lettersDictionary.Add(c, new List<string> { word.ToLower() });
                    }
                    else
                    {
                        if (!lettersDictionary[c].Contains(word.ToLower())) // حتى لا تتكرر الكلمات foreach key
                            lettersDictionary[c].Add(word);
                    }
                }
            }
        }
        public static void Print()
        {
            foreach (var entry in lettersDictionary)
            {
                Console.Write($"'{entry.Key}': ");
                foreach (var word in entry.Value) // entry.Value is a list of values for each Letter aka key.
                {
                    Console.WriteLine($"\t\t \"{word}\"");
                }
            }
        }
    }
}
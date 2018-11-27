using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta
{
  class Program
  {
    public class Person
    {
      public string name;
      public string family;
      public string target;

      public Person(string _name, string _family)
      {
        name = _name;
        family = _family;
        target = "Not Assigned";
      }
    }

    static void Main(string[] args)
    {
      List<Person> people;
      Dictionary<Person, Person> secretSantaList;
      Random rand = new Random();
      people = Load();
      secretSantaList = SecretSanta(people, rand);
      PrintList(secretSantaList);
    }

    public static List<Person> Load()
    {
      List<Person> _people = new List<Person>();
      string[] fileImport = File.ReadAllLines("input.txt");
      for(int i = 0; i < fileImport.Length; i++)
      {
        string[] data = fileImport[i].Split(' ');
        string name = data[0];
        string family = data[1];

        Person person = new Person(name, family);
        _people.Add(person);
      }

      return _people;
    }

    public static Dictionary<Person, Person> SecretSanta(List<Person> _people,
      Random rand)
    {
      Dictionary<Person, Person> secretSantaList = 
        new Dictionary<Person, Person>();
      foreach (Person p in _people.Reverse<Person>())
      {
        Person temp = p;
        while (temp.family == p.family)
        {
          int randNum = rand.Next(_people.Count);
          temp = _people[randNum];
        }

        secretSantaList.Add(p, temp);
        _people.Remove(temp);
      }

      return secretSantaList;
    }

    public static void PrintList(Dictionary<Person, Person> secretSantaList)
    {
      using (TextWriter outputFile = new StreamWriter("output.txt"))
      {
        foreach (KeyValuePair<Person, Person> kv in secretSantaList){
          outputFile.WriteLine("{0, -10} has {1, -10}", kv.Key.name, kv.Value.name);
        }
      }
    }
  }
}

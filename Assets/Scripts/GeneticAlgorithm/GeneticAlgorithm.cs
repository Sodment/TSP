using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneticAlgorithm : MonoBehaviour
{
    private List<Vector3Int> cityCopy;
    public int populationSize;
    private void Start()
    {
        GameManager.instance.SwitchingToSimulating.AddListener(CopyListOfCities);
    }

    void CopyListOfCities()
    {
        cityCopy = new List<Vector3Int>(ListOfCities.instance.CityList);
    }
    public static void Shuffle(List<Vector3Int> list)
    {
        int n = list.Count;
        while(n > 1)
        {
            n--;
            int k = Random.Range(1, n + 1);
            Vector3Int temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }
    public void PrintList(List<Vector3Int> list)
    {
        string toPrint = "";
        foreach(Vector3Int vec in list)
        {
            toPrint += ListOfCities.instance.CityList.IndexOf(vec).ToString() + "-->";
        }
        Debug.Log(toPrint);
        
    }

    //Fisher-Yates Shuffle
    public void GenerateFirstGenome()
    {
        PrintList(cityCopy);
        int n = cityCopy.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(1, n + 1);
            Vector3Int temp = cityCopy[k];
            cityCopy[k] = cityCopy[n];
            cityCopy[n] = temp;
        }
        cityCopy.Add(cityCopy[0]);
        PrintList(cityCopy);
        Debug.Log(CalculateFitness(cityCopy));
    }

    public float CalculateFitness(List<Vector3Int> list)
    {
        float fitness = 0;
        for (int i = 1; i < list.Count; i++)
        {
            fitness += Vector3Int.Distance(list[i - 1], list[i]);
        }
        return fitness;
    }

    public void MutateGenome(List<Vector3Int> gen)
    {
        while (true)
        {
            int swap_a = Random.Range(1, gen.Count);
            int swap_b = Random.Range(1, gen.Count);
            if(swap_a != swap_b)
            {
                Debug.Log(swap_a + " " + swap_b);
                Vector3Int temp = gen[swap_a];
                gen[swap_a] = gen[swap_b];
                gen[swap_b] = temp;
                break;

            }
        }
    }

}

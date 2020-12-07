using System;
using System.Collections.Generic;
using UnityEngine;
public struct Individual
{
    public List<Vector3Int> genome;
    public double fitness;
}

public class GeneticAlgorithm : MonoBehaviour
{
    private List<Vector3Int> cityCopy;
    public int populationSize;
    public Individual[] population;
    //public List<Individual> population;
    private void Start()
    {
        GameManager.instance.SwitchingToSimulating.AddListener(CopyListOfCities);
        GameManager.instance.SwitchingToSimulating.AddListener(GeneticMain);
    }

    void CopyListOfCities()
    {
        cityCopy = new List<Vector3Int>(ListOfCities.instance.CityList);
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
    public List<Vector3Int> GenerateFirstGenome()
    {
        List<Vector3Int> first_genome = new List<Vector3Int>(cityCopy);
        //PrintList(cityCopy);
        int n = cityCopy.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(1, n + 1);
            Vector3Int temp = first_genome[k];
            first_genome[k] = first_genome[n];
            first_genome[n] = temp;
        }
        first_genome.Add(first_genome[0]);
        //PrintList(cityCopy);
        //Debug.Log(CalculateFitness(cityCopy));
        return first_genome;
    }

    public double CalculateFitness(List<Vector3Int> list)
    {
        double fitness = 0;
        for (int i = 1; i < list.Count; i++)
        {
            fitness += Vector3Int.Distance(list[i - 1], list[i]);
        }
        return fitness;
    }

    public List<Vector3Int> Crossover(List<Vector3Int> parent_a, List<Vector3Int> parent_b)
    {
        int cut_point = Mathf.FloorToInt(cityCopy.Count * 0.5f);
        List<Vector3Int> child = new List<Vector3Int>(cityCopy.Count);
        for (int i = 0; i < cut_point; i++)
        {
            child.Add(parent_a[i]);
        }
        for (int i = cut_point; i < cityCopy.Count; i++)
        {
            child.Add(parent_b[i]);
        }
        child.Add(child[0]);
        return child;
    }

    public List<Vector3Int> PMXCrossover(List<Vector3Int> parent_a, List<Vector3Int> parent_b)
    {
        int cut_left = Mathf.RoundToInt(cityCopy.Count * 0.33f);
        int cut_right = Mathf.RoundToInt(cityCopy.Count * 0.66f);
        //Debug.Log(cut_left + " " + cut_right);
        List<Vector3Int> child = new List<Vector3Int>(cityCopy);
        //List<Vector3Int> map = parent_b.GetRange(cut_left, cut_right);
        for (int i = cut_left; i < cut_right; i++)
        {
            child[i] = parent_b[i];
        }
        for (int i = 0; i < cut_left; i++)
        {
            if (child.Contains(parent_a[i]))
            {
                Debug.Log(parent_a.IndexOf(parent_a[i]));
                int mapping_index = parent_a.IndexOf(parent_a[i]);
                child[i] = parent_b[mapping_index];
            }
            else
            {
                child[i] = parent_a[i];
            }
        }
        child.Add(child[0]);
        PrintList(child);
        return child;
    }

    public void CreateFirstPopulation()
    {
        population = new Individual[populationSize];
        //population = new List<Individual>(2 * populationSize);
        //Individual individual;
        List<Vector3Int> firstGenome = new List<Vector3Int>(cityCopy.Count);
        firstGenome = GenerateFirstGenome();
        for (int i = 0; i < populationSize; i++)
        {

            population[i].genome = new List<Vector3Int>(firstGenome);
            MutateGenome(population[i].genome);
            population[i].fitness = CalculateFitness(population[i].genome);


            //individual.genome = new List<Vector3Int>(firstGenome);
            //MutateGenome(individual.genome);
            //individual.fitness = CalculateFitness(individual.genome);
            //population[i] = individual;

        }
        //PrintList(population[0].genome);
        //PrintList(population[1].genome);
        //PrintList(population[2].genome);
        //Debug.Log(population[0].fitness);
        //Debug.Log(population[1].fitness);
        //Debug.Log(population[2].fitness);
    }

    public void NextGenerataion()
    {
        Array.Sort(population, (x, y) => x.fitness.CompareTo(y.fitness));
        //population.Sort((x, y) => x.fitness.CompareTo(y.fitness));
        //Individual individual;
        List<Vector3Int> child_a = Crossover(population[0].genome, population[1].genome);
        List<Vector3Int> child_b = Crossover(population[1].genome, population[0].genome);
        for (int i = 0; i < Mathf.FloorToInt(population.Length/2); i++)
        {

            population[i].genome = new List<Vector3Int>(child_a);
            MutateGenome(population[i].genome);
            population[i].fitness = CalculateFitness(population[i].genome);


            //individual.genome = new List<Vector3Int>(child_a);
            //MutateGenome(individual.genome);
            //individual.fitness = CalculateFitness(individual.genome);
            //population.Add(individual);

        }
        for (int i = Mathf.FloorToInt(population.Length / 2); i < population.Length; i++)
        {

            population[i].genome = new List<Vector3Int>(child_b);
            MutateGenome(population[i].genome);
            population[i].fitness = CalculateFitness(population[i].genome);


            //individual.genome = new List<Vector3Int>(child_b);
            //MutateGenome(individual.genome);
            //individual.fitness = CalculateFitness(individual.genome);
            //population.Add(individual);
            
        }
        //Array.Sort(population, (x, y) => x.fitness.CompareTo(y.fitness));
        //population.Sort((x, y) => x.fitness.CompareTo(y.fitness));
        //population = population.GetRange(0, populationSize);
    }

    public void GeneticMain()
    {
        CreateFirstPopulation();
        PrintList(population[0].genome);
        Debug.Log(population[0].fitness);
        //Debug.Log(population[0].genome.Count);
        for (int i = 0; i < 2000; i++)
        {
            NextGenerataion();
        }
        PrintList(population[0].genome);
        Debug.Log(population[0].fitness);
        //Debug.Log(population[0].genome.Count);
    }

    public void MutateGenome(List<Vector3Int> gen)
    {
        while (true)
        {
            int swap_a = UnityEngine.Random.Range(1, gen.Count-1);
            int swap_b = UnityEngine.Random.Range(1, gen.Count-1);
            if(swap_a != swap_b)
            {
                //Debug.Log(swap_a + " " + swap_b);
                Vector3Int temp = gen[swap_a];
                gen[swap_a] = gen[swap_b];
                gen[swap_b] = temp;
                break;

            }
        }
    }

}

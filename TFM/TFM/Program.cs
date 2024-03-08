using System.Security.Cryptography.X509Certificates;
using TFM;
using static System.Runtime.InteropServices.JavaScript.JSType;

//State q1 = new State(new List<int> { 4, 1 }, new List<string> { "0", "1" }, 1);
//State q2 = new State(new List<int> { 2, 3 }, new List<string> { "0", "1" }, 2);
//State q3 = new State(new List<int> { 4 }, new List<string> { "0", "1" }, 3);
//State q4 = new State(new List<int> { 1, 2, 4 }, new List<string> { "0" }, 4);
State q1 = new State(new List<int> { 2, 3, 5 }, new List<string> { "a", "b" }, 1);
State q2 = new State(new List<int> { 4 }, new List<string> { "a" }, 2);
State q5 = new State(new List<int> { 4 }, new List<string> { "a" }, 5);
State q3 = new State(new List<int> { 4, 3 }, new List<string> { "a", "b" }, 3);
State q4 = new State(new List<int> { 1 }, new List<string> { "a" }, 4);

// Создаем список состояний и добавляем созданные состояния
List<State> states = new List<State> { q1, q2, q3, q4, q5 };

// Создаем конечный автомат
FSM fsm = new FSM(states);


Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

fsm.PrintStates();

Console.WriteLine();
Console.WriteLine();

var test = fsm.FindReachableStates();

//fsm.DeleteReachableStates(test);


Console.WriteLine("Минимизированные состояния:");

var minimizationAlgorithm = new MinimizationAlgorithm();
var minimizedGroups = minimizationAlgorithm.Minimize(fsm);
foreach (var outerList in minimizedGroups)
{
    foreach (var group in outerList)
    {
        // Выводим ключи
        var key = group.Key;
        Console.WriteLine($"Эквавалентный переход: [{string.Join(", ", key)}]");

        // Выводим элементы внутри группы
        foreach (var state in group)
        {
            Console.WriteLine($"  Эквивалентные состояния: {state.Data}");
        }
    }
}

fsm.PrintStates();


while (true)
{
    try
    {
        fsm.Transit(Convert.ToInt32(Console.ReadLine()));
    }
    catch
    {

    }
}
    
public class FSM
{
    public List<State> States { get; set; }
    public State CurrentState { get; set; }
    public FSM(List<State> states)
    {
        States = states;
        CurrentState = states[0];
    }
    public void Transit(int transit_state)
    {
        if (CurrentState.Q.Contains(transit_state) && States.Any(x => x.Data == transit_state))
        {
            CurrentState = States[transit_state-1];
            Console.WriteLine($"Перешли");
            CurrentState.Print();
        }
        else
        {
            Console.WriteLine("Нет такого перехода");
        }
    }
    public List<State> FindReachableStates()
    {
        List<State> ReachableStates = new List<State>();
        foreach (var state in States)
        {
            bool flag = false;
            foreach (var state2 in States)
            {
                if (state2.Q.Contains(state.Data))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                ReachableStates.Add(state);
            }
        }
        return ReachableStates;
    }
    public void DeleteReachableStates(List<State> states)
    {
        foreach (var state in states)
        {
            States.Remove(state);
        }
    }
    public void PrintStates()
    {
        foreach(var state in States)
        {
            state.Print();
        }
    }
}

public class State
{
    public List<int>? Q { get; set; }
    public List<string>? V { get;set; }

    public int Data { get; set; }

    public State()
    {
        Q = new List<int>();
        V = new List<string>();
        Data = 0;
    }
    public State(List<int> q, List<string> v, int data)
    {
        Q = q; V = v; Data= data;
    }
    public State(Tuple<int, string> tuple, int data)
    {
        Q = new List<int>();
        V = new List<string>();
        Q.Add(tuple.Item1);
        V.Add(tuple.Item2);
        Data = data;
    }
    public void AddTransition(Tuple<int, string> tuple)
    {
        Q.Add(tuple.Item1);
        V.Add(tuple.Item2);
    }
    public void Print()
    {
        Console.WriteLine($"Состояние - {Data}");
        Console.WriteLine("Состояния для перехода");
        Console.WriteLine(string.Join(" ", Q));
        Console.WriteLine("Выходной алфавит");
        Console.WriteLine(string.Join(" ", V));
        Console.WriteLine("--------------------------");
    }
    public string GetOutputString()
    {
        return string.Join(",", Q.OrderBy(q => q));
    }
}
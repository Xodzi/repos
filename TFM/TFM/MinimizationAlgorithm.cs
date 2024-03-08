using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFM
{
    public class MinimizationAlgorithm
    {
        public List<List<IGrouping<List<int>, State>>> Minimize(FSM fsm)
        {
            // Шаг 1: Инициализация
            var states = fsm.States;
            var unreachableStates = fsm.FindReachableStates();
            fsm.DeleteReachableStates(unreachableStates);
            states = fsm.States;

            // Шаг 2: Разбиение по выходам
            var groups = new List<List<State>> { };

            var needMinimise = new List<List<IGrouping<List<int>, State>>>();

            foreach(var state in states)
            {
                List<State> subState= new List<State>();
                foreach(var transition in state.Q)
                {
                    subState.AddRange(states.Where(s => s.Data == transition));
                }

                var groupedObjects = subState.GroupBy(g => g.Q, new ListEqualityComparer<int>());

                var duplicates = groupedObjects.Where(d => d.Count() > 1);

                var test = duplicates.ToList();

                if(duplicates.Count() > 0)
                {
                   needMinimise.Add(test);
                }



                var stop = 5;
            }
            foreach(var state in needMinimise)
            {
                for(int i=0; i < needMinimise.Count; i++)
                {
                    for(int j=0; j < needMinimise[i].Count; j++)
                    {
                        var statesToDelete = needMinimise[i][j];
                        for(int z =1; z < statesToDelete.ToList().Count; z++)
                        {
                            var state1 = statesToDelete.ToList()[z];
                            fsm.States.Remove(state1);
                        }

                    }
                }
            }

            return needMinimise;
        }
    }
    public class ListEqualityComparer<T> : IEqualityComparer<List<T>>
    {
        public bool Equals(List<T> x, List<T> y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(List<T> obj)
        {
            return obj.Aggregate(0, (hash, item) => hash ^ item.GetHashCode());
        }
    }

}

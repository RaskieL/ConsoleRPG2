namespace ConsoleRPG2
{
    public class StateMachine
    {

        // Régit les états du jeu
        private static List<Object> States = new List<Object>();


        // Retire le dernier état ajouté
        public static void removeLastState()
        {
            States.RemoveAt(0);
        }

        // Ajoute à l'index 0 un nouvel état
        public static void addState(object state)
        {
            States.Insert(0, state);
        }

        // Renvoie l'état courant
        public static Object getCurrentState()
        {
            return States.First();
        }

        // Renvoie l'état à l'index voulu
        public static Object getState(int index)
        {
            return States.ElementAt(index);
        }

        // Permet d'assigner l'état à un index à un autre état.
        public static void setState(int index, object state)
        {
            States[0] = state;
        }

        // Remplace l'état courant par un autre.
        public static void updateCurrentState(object state)
        {
            removeLastState();
            addState(state);
        }
    }
}
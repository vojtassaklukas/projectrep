using Structures;


namespace MainApplication.Classes
{
    public class State
    {
        public AvlTree<int,Cadastral> CadastralAreas { get; } // unique cadaster id
        public AvlTree<string,Citizen> Citizens { get; } // unique EAN string

        private State()
        {
            CadastralAreas = new AvlTree<int, Cadastral>();
            Citizens = new AvlTree<string, Citizen>();
        }
    }
}

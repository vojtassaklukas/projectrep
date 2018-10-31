using Structures;


namespace MainApplication.Classes
{
    class State
    {
        public AvlTree<int, Cadastral> CadastralAreas { get; } // unique cadaster id
        public AvlTree<string,Citizen> Citizens { get; } // unique EAN string

        private static State _instance;

        public static State Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new State();
                }
                return _instance;
            }
        }

        private State()
        {
            CadastralAreas = new AvlTree<int, Cadastral>();
            Citizens = new AvlTree<string, Citizen>();
        }
    }
}

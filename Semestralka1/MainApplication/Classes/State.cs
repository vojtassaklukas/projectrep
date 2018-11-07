using Structures;


namespace MainApplication.Classes
{
    class State
    {
        public AvlTree<int, Cadastral> CadastralAreas { get; } // unique cadaster id
        public AvlTree<string,Citizen> Citizens { get; } // unique EAN string
        public AvlTree<string, Cadastral> CadastralAreasByName { get; } // unique cadaster name

        public int CadastralNumerator { get; set; }
        public int CitizenNumebrator { get; set;  }
        public int PropertyListNumerator { get; set; }
        public int PropertyNumerator { get; set; }

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
            CadastralAreasByName = new AvlTree<string, Cadastral>();
            CadastralNumerator = 1;
            CitizenNumebrator = 1;
            PropertyListNumerator = 100; 
            PropertyNumerator = 10000;
        }
    }
}

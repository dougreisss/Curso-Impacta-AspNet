namespace Projeto.AspNet._03.MVC.CRUD.Models
{
    public static class Repository
    {
        private static List<Colab> _todosOsColabs = new List<Colab>();
        public static IEnumerable<Colab> TodosOsColabs 
        { 
            get { return _todosOsColabs; }
            // definido o encapsulamento como IEnumerable<Colab> basta,
            // agora fazer referencia ao elemento publico para que todos os registros
            // sejam recuperados e exibidos em tela
        }

        public static void Inserir(Colab registroColab)
        {
            _todosOsColabs.Add(registroColab);
        }

        public static void Excluir(Colab registroColab)
        {
            _todosOsColabs.Remove(registroColab);
        }       
    }
}

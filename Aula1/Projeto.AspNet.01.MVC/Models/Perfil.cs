namespace Projeto.AspNet._01.MVC.Models
{
    // esta classe assume o "papel" de model domain da aplicação.
    // Isso significa que: as regras/formatos com quais os dados serão manipulados pela aplicação
    // ficam estabelecidas aqui.
    public class Perfil
    {
        // definir as props/atributos de classe

        /* 
         
            private string _nome;

            public string? Nome { 
            
                // uso dos métodos acessores

                get { return _nome;  } 
                set { _nome = value; }

            }
        
        */

        public string? Nome { get; set; }
        public int Idade { get; set; }
        public string? Endereco { get; set; }
    }
}

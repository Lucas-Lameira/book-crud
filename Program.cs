using System;

namespace Project.Books
{
    class Program
    {   
        static BookRepository repository = new BookRepository();
        static void Main(string[] args)
        {   
            int userChoice = 0;            
            
            while(userChoice != 7){
                OptionsMenu();
                userChoice = getUserChoice();

                switch(userChoice){
                    case 1:
                        bookList();
                    break;
                    case 2:
                        createBook();
                    break;
                    case 3:
                        updateBook();
                    break;
                    case 4:
                        deleteBook();
                    break;
                    case 5:
                        readBook();
                    break;
                    case 6:
                        Console.Clear();
                    break;
                    case 7:
                        Console.WriteLine("Saindo...");
                    break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                if(userChoice == 7) return;
            }  

            //pause                      
        }

        private static void OptionsMenu (){
            Console.WriteLine("=============== Biblioteca digital ===============");
            Console.WriteLine("1 - Lista de livros");
            Console.WriteLine("2 - Registrar novo livro");
            Console.WriteLine("3 - Alterar os dados de um livro");
            Console.WriteLine("4 - Excluir um livro");
            Console.WriteLine("5 - Vizualizar os dados de um livro");
            Console.WriteLine("6 - Limpar tela");
            Console.WriteLine("7 - Sair");
            Console.WriteLine("==================================================");
            Console.WriteLine("Digite o número correspondente a opção desejada!");
        }

        private static int getUserChoice()
        {
            int userChoice = int.Parse(Console.ReadLine());
            Console.WriteLine($"userInput: {userChoice}");
            if(userChoice < 1 || userChoice > 7)
            {
                userChoice = validateUserInput(userChoice);
            }
            Console.WriteLine($"userInput: {userChoice}");

            return userChoice;                       
        }

        private static int validateUserInput(int userChoice)
        {
             while(userChoice < 1 || userChoice > 7){
                Console.Clear();
                OptionsMenu();
                Console.WriteLine("Digite um número de 1 a 7, correspondente aos items abaixo!");
                userChoice = getUserChoice();
            }
            return userChoice;
        }

        private static void bookList(){
            var listOfBooks = repository.List();
            
            if(listOfBooks.Count == 0){
                Console.WriteLine("Não há livros cadastrados!");
                return;
            }

            Console.WriteLine("Aqui está uma lista de livros");

            foreach(var book in listOfBooks){
                //if(!book.getIsDeleted()){}
                
                Console.WriteLine($"ID: {book.getId()}: {book.getTitle()}");
            }
        }

        private static void createBook(){
            Console.WriteLine("Digite os dados do livro:");
            foreach(int i in Enum.GetValues(typeof(Genre))){
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            Console.WriteLine("Escolha um genero dentre as opções acima:");
            int bookGenre = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o título do livro:");
            string bookTitle = Console.ReadLine();
            
            Console.WriteLine("Quem é o autor do livro:");
            string bookAuthor = Console.ReadLine();

            Console.WriteLine("Quantas páginas tem o livro:");
            int bookPages = int.Parse(Console.ReadLine());

            Books book = new Books(
                repository.NextId(), 
                (Genre)bookGenre, 
                bookTitle, 
                bookAuthor, 
                bookPages
            );

            repository.create(book);
        }
    
        private static void updateBook()
        {
            Console.WriteLine("Qual o id do livro:");
            int bookId = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genre))){
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            Console.WriteLine("Escolha um genero dentre as opções acima:");
            int bookGenre = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o título do livro:");
            string bookTitle = Console.ReadLine();
            
            Console.WriteLine("Quem é o autor do livro:");
            string bookAuthor = Console.ReadLine();

            Console.WriteLine("Quantas páginas tem o livro:");
            int bookPages = int.Parse(Console.ReadLine());

            Books book = new Books(
                bookId, 
                (Genre)bookGenre, 
                bookTitle, 
                bookAuthor, 
                bookPages
            );

            repository.update(bookId, book);
        }
    
        private static void deleteBook(){
            Console.WriteLine("Qual o id do livro:");
            int bookId = int.Parse(Console.ReadLine());

            //confirmaçãp

            repository.delete(bookId);
        }
    
        private static void readBook() {
            Console.WriteLine("Qual o id do livro:");
            int bookId = int.Parse(Console.ReadLine());

            var book = repository.ReturnById(bookId);
            Console.WriteLine(book);
        }
    }
}

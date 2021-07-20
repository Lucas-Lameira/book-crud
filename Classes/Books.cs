using System;

namespace Project.Books
{
    public class Books : BaseEntity
    {   
        private Genre genre {get; set;}
        private string title {get; set;}
        private string author {get; set;}
        private int pages {get; set;}
        private bool isDeleted {get; set;}

        public Books(int id, Genre genre, string title, string author, int pages)
        {
            this.id = id;
            this.genre = genre;
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.isDeleted = false;
        }

        public override string ToString()
        {
            string returnBooks = "";
            returnBooks += "Title: " + this.title + Environment.NewLine;
            returnBooks += "Author: " + this.author + Environment.NewLine;
            returnBooks += "Genre: " + this.genre + Environment.NewLine;
            returnBooks += "Total Pages: " + this.pages;
            return returnBooks;
        }

        public string getTitle()
        {
            return this.title;
        }
        public int getId()
        {
            return this.id;
        }
        public bool getIsDeleted()
        {
            return this.isDeleted;
        }
        public void setHasBeenDeleted () {
            this.isDeleted = true;
        }
    }
}
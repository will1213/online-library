using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace online_library.Models
{
    public static class Database
    {

        
        public static string connectionString = "Server=localhost;Database=master;Trusted_Connection=True";

        public static Book getBookByID(int ISBN)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string temp = "SELECT * FROM Book WHERE ISBN = @ID";
            SqlCommand command = new SqlCommand(temp, myConnection);
            command.Parameters.AddWithValue("@ID", ISBN);

            SqlDataReader reader = command.ExecuteReader();

            int ID;
            string Title;
            string Author;
            string Text;
            int Like;
            string Category;


            //
            // Find specific book from database using book's ID 
            //
            if (!reader.Read())
            {
                reader.Close();
                myConnection.Close();
                return null;
            }
            else {
                ID = int.Parse(reader["ISBN"].ToString());
                Title = reader["Title"].ToString();
                Author = reader["Author"].ToString();
                Text = reader["Text"].ToString();
                Like = int.Parse(reader["Like"].ToString());
                Category = reader["Category"].ToString();
            }


            Book myBook = new Book(ID, Title, Author, Text, Like,Category);

            reader.Close();
            myConnection.Close();
            return myBook;
        }

        public static LinkedList<Book> getAllBooks()
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            LinkedList<Book> books = new LinkedList<Book>();


            string temp = "SELECT * FROM Book";
            SqlCommand command = new SqlCommand(temp, myConnection);
            SqlDataReader reader = command.ExecuteReader();

            int ID;
            string Title;
            string Author;
            string Text;
            int Like;
            string Category;


            //
            // Find specific book from database using book's ID 
            //
            while (reader.Read())
            {
                ID = int.Parse(reader["ISBN"].ToString());
                Title = reader["Title"].ToString();
                Author = reader["Author"].ToString();
                Text = reader["Text"].ToString();
                Like = int.Parse(reader["Like"].ToString());
                Category = reader["Category"].ToString();
                Book aBook = new Book(ID, Title, Author, Text, Like, Category);
                books.AddLast(aBook);

            }
            reader.Close();
            myConnection.Close();
            return books;

        }
        public static LinkedList<string> getAllCategory()
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            LinkedList<string> booksCategory = new LinkedList<string>();
            //LinkedList<string> books = new LinkedList<string>();

            string temp = "SELECT * FROM Book";
            SqlCommand command = new SqlCommand(temp, myConnection);
            SqlDataReader reader = command.ExecuteReader();

            /*int ID;
            string Title;
            string Author;
            string Text;
            int Like;*/
            string Category;


            //
            // Find specific book from database using book's ID 
            //
            while (reader.Read())
            {
                /*ID = int.Parse(reader["ISBN"].ToString());
                Title = reader["Title"].ToString();
                Author = reader["Author"].ToString();
                Text = reader["Text"].ToString();
                Like = int.Parse(reader["Like"].ToString());*/
                Category = reader["Category"].ToString();
                //Book aBook = new Book(ID, Title, Author, Text, Like, Category);



                if (!booksCategory.Contains(Category))
                {
                    booksCategory.AddLast(Category);
                    Console.WriteLine(Category);
                }

            }
            reader.Close();
            myConnection.Close();
            return booksCategory;

        }
        public static LinkedList<Book> SearchByCategory(string category)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            LinkedList<Book> books = new LinkedList<Book>();

            string temp = "SELECT * FROM Book WHERE Category = '"+category+"'";
            SqlCommand command = new SqlCommand(temp, myConnection);
            SqlDataReader reader = command.ExecuteReader();

            int ID;
            string Title;
            string Author;
            string Text;
            int Like;
            string Category;


            //
            // Find specific book from database using book's ID 
            //
            while (reader.Read())
            {
                ID = int.Parse(reader["ISBN"].ToString());
                Title = reader["Title"].ToString();
                Author = reader["Author"].ToString();
                Text = reader["Text"].ToString();
                Like = int.Parse(reader["Like"].ToString());
                Category = reader["Category"].ToString();
                Book aBook = new Book(ID, Title, Author, Text, Like, Category);
                books.AddLast(aBook);


            }
            reader.Close();
            myConnection.Close();
            return books;

        }
        public static Book searchByTitle(string title)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string temp = "SELECT * FROM Book WHERE Title = '"+ title + "'";
            SqlCommand command = new SqlCommand(temp, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            int ID;
            string Title;
            string Author;
            string Text;
            int Like;
            string Category;


            //
            // Find specific book from database using book's ID 
            //
            if (!reader.Read())
            {
                reader.Close();
                myConnection.Close();
                return null;
            }
            else
            {
                ID = int.Parse(reader["ISBN"].ToString());
                Title = reader["Title"].ToString();
                Author = reader["Author"].ToString();
                Text = reader["Text"].ToString();
                Like = int.Parse(reader["Like"].ToString());
                Category = reader["Category"].ToString();
            }


            Book myBook = new Book(ID, Title, Author, Text, Like, Category);

            reader.Close();
            myConnection.Close();
            return myBook;
        }
        public static void LikeBook(int ISBN)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string temp = "UPDATE Book " +
                          "SET \"Like\" = \"Like\" + 1" +
                          "Where ISBN = @ID";
            SqlCommand command = new SqlCommand(temp, myConnection);
            command.Parameters.AddWithValue("@ID", ISBN);
            command.ExecuteNonQuery();;
            myConnection.Close();
        }
    }
}

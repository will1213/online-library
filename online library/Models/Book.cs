using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace online_library.Models
{
    public class Book
    {

        
        public int ID
        {
            get; set;
        }

        public string title
        { 
            get; set;
        }
        public string author
        {
            get; set;
        }


        public string text
        {
            get; set;
        }


        public int like
        {
            get; set;
        }

        public string category
        {
            get; set;
        }
        /**
         * Default constructor
         */
        public Book()
        {

        }

        //
        // field constructor
        //
        public Book(int ID, string title, string author,string text, int like, string category)
        {
            this.ID = ID;
            this.title = title;
            this.author = author;
            this.text = text;
            this.like = like;
            this.category = category;
        }

        /// <summary>
        /// Copy Constructor.
        /// <param name="instance"></param>
        public Book(Book instance) : this(instance.ID, instance.title, instance.author, instance.text, instance.like, instance.category)
        {

        }

    }
}

// JoiningTableData.cs
// Using LINQ to perform a join and aggregate data across tables.
using System;
using System.Linq;
using System.Windows.Forms;

namespace JoinQueries
{
    public partial class JoiningTableData : Form
    {
        public JoiningTableData()
        {
            InitializeComponent();
        } // end constructor

        private void JoiningTableData_Load(object sender, EventArgs e)
        {
            // Entity Framework DBContext
            BooksEntities dbcontext =
               new BooksEntities();


            // KEIRA: Titles & Authors -------------------------------------------------

            // get titles and the authors who wrote them
            var titlesAndAuthors =
               from book in dbcontext.Titles
               from author in book.Authors
               orderby book.Title1
               select new
               {
                   book.Title1,
                   author.FirstName,
                   author.LastName
               };

            outputTextBox.AppendText("\r\n\r\nTitles and Authors:");

            // display authors and titles in tabular format
            foreach (var element in titlesAndAuthors)
            {
                outputTextBox.AppendText(
                   String.Format("\r\n\t{0,-10} {1} {2}",
                      element.Title1, element.FirstName, element.LastName));
            } // end foreach


            // KEIRA: Authors & Titles ------------------------------------------------

            // get authors and titles w/ authors sorted for each title
            var authorsAndTitles =
               from book in dbcontext.Titles
               from author in book.Authors
               orderby book.Title1, author.LastName, author.FirstName
               select new
               {
                   book.Title1,
                   author.FirstName,
                   author.LastName                   
               };

            outputTextBox.AppendText("\r\n\r\nAuthors and titles with authors sorted for each title:");

            // display authors and titles in tabular format
            foreach (var element in authorsAndTitles)
            {
                outputTextBox.AppendText(
                   String.Format("\r\n\t{0,-10} {1} {2}",
                      element.Title1, element.FirstName, element.LastName));
            } // end foreach


            // KEIRA: Authors Grouped by Title ----------------------------------------

            // get titles and authors of each book 
            // group by title
            var authorsByTitle =
               from title in dbcontext.Titles
               orderby title.Title1
               select new
               {
                   Title = title.Title1, 
                   Authors =
                     from author in title.Authors
                     orderby author.LastName, author.FirstName
                     select author.FirstName + " " + author.LastName
               };

            outputTextBox.AppendText("\r\n\r\nAuthors grouped by title:");

            // display titles written by each author, grouped by author
            foreach (var title in authorsByTitle)
            {
                // display title's name
                outputTextBox.AppendText("\r\n\t" + title.Title + ":");

                // display titles written by that author
                foreach (var author in title.Authors)
                {
                    outputTextBox.AppendText("\r\n\t\t" + author);
                } // end inner foreach
            } // end outer foreach
                     
               
        } // end method JoiningTableData_Load
    } // end class JoiningTableData
} // end namespace JoinQueries


//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JoinQueries
{
    using System;
    using System.Collections.Generic;
    
    public partial class Author
    {
        public Author()
        {
            // KEIRA: An Author can have many Titles. (As modeled in BooksModel.edmx)
            this.Titles = new HashSet<Title>();
        }
    
        // PROPERTIES
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        // NAVIGATION PROPERTIES
        public virtual ICollection<Title> Titles { get; set; }
    }
}

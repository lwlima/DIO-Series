using DIO.Series.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Classes
{
    public class Serie : BaseEntity
    {
        private Genre Genre { get; set; }
        public string Title { get; private set; }
        private string Description { get; set; }
        private int Year { get; set; }

        public bool hasDeleted { get; private set; }

        public Serie (int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.hasDeleted = false;
        }

        public override string ToString()
        {
            string @return = "";
            @return += $"Genre: {this.Genre} {Environment.NewLine}";
            @return += $"Title: {this.Title} {Environment.NewLine}";
            @return += $"Description: {this.Description} {Environment.NewLine}";
            @return += $"Release year: {this.Year}";

            return @return;
        }

        public string getTitle()
        {
            return this.Title;
        }

        public int getId()
        {
            return this.Id;
        }

        public void Delete()
        {
            this.hasDeleted = true;
        }

        public bool getDeleted()
        {
            return this.hasDeleted;
        }
    }
}

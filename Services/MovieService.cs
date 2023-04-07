using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clase4.Models;

namespace Clase4.Services;

public static class MovieService{
    static List<Movie> Movies {get;set;}

    static MovieService(){
        Movies = new List<Movie>
        {
            new Movie{Name="Back to the Future", Code="BTF", Category="Sci FY", Minutes=120, Review="OK"},
            new Movie{Name="Avatar", Code="AVT", Category="Sci FY", Minutes=500, Review="ASD"},
            new Movie{Name="Hannibal", Code="HNL", Category="Terror", Minutes=90, Review="Hannibal nunca pestanea"}
        };
    }
    public static List<Movie> GetAll() => Movies;

    public static void Add(Movie obj){
        if (obj == null)
        {
            return;
        }
        Movies.Add(obj);
    }

    public static Movie? Get(string code) => Movies.FirstOrDefault(x=>x.Code.ToLower()==code.ToLower());

    public static void Delete(string code){
        var movieToDelete= Get(code);
        if (movieToDelete != null)
        {
            Movies.Remove(movieToDelete);
        }
    }

    

}

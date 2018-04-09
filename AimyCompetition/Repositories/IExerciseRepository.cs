using AimyCompetition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimyCompetition.Repositories
{
    public interface IExerciseRepository : IDisposable
    {
        IQueryable<Exercise> GetExercises();
        //Search the Exercise by name
        Exercise GetExerciseByName(string exerciseName);
        //Insert a new Exercise
        void InsertExercise(Exercise exercise);
        //Save the changes
        void SaveChanges();
        //Get the Exercise by date
        Boolean GetExercieByDate(string exerciseName,DateTime exerciseDate);
    }
}

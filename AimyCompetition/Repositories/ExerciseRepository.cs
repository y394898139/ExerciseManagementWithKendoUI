using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AimyCompetition.Models;
using System.Data.Entity;

namespace AimyCompetition.Repositories
{
    public class ExerciseRepository : IExerciseRepository, IDisposable
    {
        private ExerciseContext context;

        public ExerciseRepository(ExerciseContext context)
        {
            this.context = context;
        }

        public Exercise GetExerciseByName(string exerciseName)
        {
            return context.Exercises.Find(exerciseName);
        }

        public IQueryable<Exercise> GetExercises()
        {
            return context.Exercises.OrderByDescending(e=>e.ExerciseDate);
        }

        public void InsertExercise(Exercise exercise)
        {
            context.Exercises.Add(exercise);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public Boolean GetExercieByDate(string exerciseName,DateTime exerciseDate)
        {
            return context.Exercises.Where(e => e.ExerciseDate == exerciseDate && e.ExerciseName == exerciseName).Any();
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
using AimyCompetition.Repositories;
using Kendo.Mvc.UI;
using KendoGridBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using AimyCompetition.Models;
using System.Net;

namespace AimyCompetition.Controllers
{

    public class ExerciseController : Controller
    {
        ExerciseContext db = new ExerciseContext();
        private IExerciseRepository exerciseRepository;
        
        public ExerciseController()
        {
            this.exerciseRepository = new ExerciseRepository(new Models.ExerciseContext());
        }

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }
 
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Exercises_Read()
        {
            IQueryable<Exercise> exercises = exerciseRepository.GetExercises();
            
            return Json(exercises, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Exercise_Create(Exercise exercise)
        {
            if (exercise.ExerciseName != null)
            {
                if (exerciseRepository.GetExercieByDate(exercise.ExerciseName,exercise.ExerciseDate))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "ExerciseDate");
                }
                else
                {
                    exerciseRepository.InsertExercise(exercise);
                    exerciseRepository.SaveChanges();
                }
            }
            return Json(exercise, JsonRequestBehavior.AllowGet);
        }

    }
}
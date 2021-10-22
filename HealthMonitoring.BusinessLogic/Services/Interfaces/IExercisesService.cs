using HealthMonitoring.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Services.Interfaces
{
    public interface IExercisesService
    {
        List<ExerciseModel> GetAllExercises();
        void AddCompletedExercise(CompletedExerciseModel completedExercise);
        List<CompletedExerciseModel> AllCompletedExercise(int id);
    }
}

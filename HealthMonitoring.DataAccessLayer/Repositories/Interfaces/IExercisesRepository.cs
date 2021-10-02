using HealthMonitoring.DataAccessLayer.DataModels;
using HealthMonitoring.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.Repositories.Interfaces
{
    public interface IExercisesRepository
    {
        List<ExerciseDataModel> GetAllExercises();
        void AddCompletedExercise(CompletedExercise completedExercise);
    }
}

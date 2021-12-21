using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportSystemAPI.Model;

namespace SportSystemAPI.Data.Workout
{
    public interface IWorkoutRepo
    {
        Task SaveChangesAsync();
        Task<IEnumerable<WorkoutModel>> GetWorkoutListAsync();
        Task<WorkoutModel> GetWorkoutByIdAsync(int id);
        Task CreateWorkoutAsync(WorkoutModel workoutModel);
        Task UpdateWorkoutAsync(WorkoutModel workoutModel);
        Task DeleteWorkoutAsync(int id);
    }
}
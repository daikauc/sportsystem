using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportSystemAPI.Model;

namespace SportSystemAPI.Data.WorkoutRegistration
{
    public interface IWorkoutRegistrationRepo
    {
        Task SaveChangesAsync();
        Task<IEnumerable<WorkoutRegistrationModel>> GetWorkoutRegistrationListAsync();
        Task<WorkoutRegistrationModel> GetWorkoutRegistrationByIdAsync(int id);
        Task<List<WorkoutModel>> GetWorkoutRegistrationByUserIdAsync(int id);
        Task CreateWorkoutRegistrationAsync(int userId, int workoutId);
        Task UpdateWorkoutRegistrationAsync(WorkoutRegistrationModel workoutRegistrationModel);
        Task DeleteWorkoutRegistrationAsync(int id);
        Task<WorkoutModel> GetWorkoutByIdAsync(int id);
    }
}
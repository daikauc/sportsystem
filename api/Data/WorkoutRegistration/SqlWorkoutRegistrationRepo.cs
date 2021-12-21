using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportSystemAPI.Model;
using Microsoft.EntityFrameworkCore;
using SportSystemAPI.Context;

namespace SportSystemAPI.Data.WorkoutRegistration
{
    public class SqlWorkoutRegistrationRepo : IWorkoutRegistrationRepo
    {
        public SqlWorkoutRegistrationRepo(SportSystemContext context)
        {
            _context = context;
        }
        private readonly SportSystemContext _context;

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkoutRegistrationModel>> GetWorkoutRegistrationListAsync()
        {
            var workoutRegistrationList = _context.WorkoutRegistrations.ToList();

            return await Task.FromResult(workoutRegistrationList);
        }
        public async Task<WorkoutRegistrationModel> GetWorkoutRegistrationByIdAsync(int id)
        {
            WorkoutRegistrationModel workoutRegistration = await _context.WorkoutRegistrations.FirstOrDefaultAsync(x => x.Id == id);
            return workoutRegistration;
        }

        public async Task<List<WorkoutModel>> GetWorkoutRegistrationByUserIdAsync(int id)
        {
            var workoutRegistrationList = _context.WorkoutRegistrations.Where(x => x.UserId == id).ToList();
            List<WorkoutModel> workoutRegistrationList2 = new List<WorkoutModel>();
            foreach (var item in workoutRegistrationList)
            {
                var temp = await GetWorkoutByIdAsync(item.WorkoutId);
                workoutRegistrationList2.Add(temp);
            }
            return workoutRegistrationList2;
        }


        public async Task CreateWorkoutRegistrationAsync(int userId, int workoutId)
        {
            WorkoutRegistrationModel newModel = new WorkoutRegistrationModel();
            newModel.UserId = userId;
            newModel.WorkoutId = workoutId;
            await _context.WorkoutRegistrations.AddAsync(newModel);
        }

        public async Task UpdateWorkoutRegistrationAsync(WorkoutRegistrationModel workoutRegistrationModel)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteWorkoutRegistrationAsync(int id)
        {
            var workoutRegistrationList = _context.WorkoutRegistrations.Where(x => x.WorkoutId == id).ToList();
            foreach (var item in workoutRegistrationList)
            {
                await Task.FromResult(_context.WorkoutRegistrations.Remove(item));
            }
        }

        public async Task<WorkoutModel> GetWorkoutByIdAsync(int id)
        {
            WorkoutModel workout = await _context.Workouts.FirstOrDefaultAsync(x => x.Id == id);

            return workout;
        }

    }
}
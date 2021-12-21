using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportSystemAPI.Model;
using Microsoft.EntityFrameworkCore;
using SportSystemAPI.Context;

namespace SportSystemAPI.Data.Workout
{
    public class SqlWorkoutRepo : IWorkoutRepo
    {
        public SqlWorkoutRepo(SportSystemContext context)
        {
            _context = context;
        }
        private readonly SportSystemContext _context;

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkoutModel>> GetWorkoutListAsync()
        {
            var workoutList = _context.Workouts.ToList();

            return await Task.FromResult(workoutList);
        }
        public async Task<WorkoutModel> GetWorkoutByIdAsync(int id)
        {
            WorkoutModel workout = await _context.Workouts.FirstOrDefaultAsync(x => x.Id == id);

            return workout;
        }


        public async Task CreateWorkoutAsync(WorkoutModel workoutModel)
        {
            await _context.Workouts.AddAsync(workoutModel);
        }

        public async Task UpdateWorkoutAsync(WorkoutModel workoutModel)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteWorkoutAsync(int id)
        {
            WorkoutModel workout = await _context.Workouts.FirstOrDefaultAsync(x => x.Id == id);
            if (workout is null)
            {
                throw new ArgumentException(nameof(workout));
            }
            await Task.FromResult(_context.Workouts.Remove(workout));

        }

    }
}
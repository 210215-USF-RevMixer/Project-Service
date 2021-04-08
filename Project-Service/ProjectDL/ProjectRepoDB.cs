﻿using Microsoft.EntityFrameworkCore;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDL
{
    public class ProjectRepoDB : IProjectRepoDB
    {
        private readonly ProjectDBContext _context;
        public ProjectRepoDB(ProjectDBContext context)
        {
            _context = context;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// This block of code has to do with the adding of different models to our database.
        /// We do that by taking in a object type of the data we are trying to save and then adding that to our database.
        /// </summary>
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<Sample> AddSampleAsync(Sample newSample)
        {
            await _context.Sample.AddAsync(newSample);
            await _context.SaveChangesAsync();
            return newSample;
        }
        public async Task<SamplePlaylist> AddSamplePlaylistAsync(SamplePlaylist newSamplePlaylist)
        {
            await _context.SamplePlaylist.AddAsync(newSamplePlaylist);
            await _context.SaveChangesAsync();
            return newSamplePlaylist;
        }
        public async Task<SampleSets> AddSampleSetsAsync(SampleSets newSampleSets)
        {
            await _context.SampleSet.AddAsync(newSampleSets);
            await _context.SaveChangesAsync();
            return newSampleSets;
        }

        public async Task<SavedProject> AddSavedProjectAsync(SavedProject newSavedProject)
        {
            await _context.SavedProject.AddAsync(newSavedProject);
            await _context.SaveChangesAsync();
            return newSavedProject;
        }

        public async Task<Track> AddTrackAsync(Track newTrack)
        {
            await _context.Track.AddAsync(newTrack);
            await _context.SaveChangesAsync();
            return newTrack;
        }
        public async Task<UserProject> AddUserProjectAsync(UserProject newUserProject)
        {
            await _context.UserProject.AddAsync(newUserProject);
            await _context.SaveChangesAsync();
            return newUserProject;
        }
        public async Task<Pattern> AddPatternAsync(Pattern newPattern)
        {
            await _context.Pattern.AddAsync(newPattern);
            await _context.SaveChangesAsync();
            return newPattern;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// This block of code has to do with the deleting of different models in our database.
        /// We do that by taking in a object type of the data we are trying to delete, find that object with that data in the database and then deleting
        /// it from the database.
        /// </summary>
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<Pattern> DeletePatternAsync(Pattern pattern2BDeleted)
        {
            _context.Pattern.Remove(pattern2BDeleted);
            await _context.SaveChangesAsync();
            return pattern2BDeleted;
        }

        public async Task<Sample> DeleteSampleAsync(Sample sample2BDeleted)
        {
            _context.Sample.Remove(sample2BDeleted);
            await _context.SaveChangesAsync();
            return sample2BDeleted;
        }
        public async Task<SamplePlaylist> DeleteSamplePlaylistAsync(SamplePlaylist samplePlaylist2BDeleted)
        {
            _context.SamplePlaylist.Remove(samplePlaylist2BDeleted);
            await _context.SaveChangesAsync();
            return samplePlaylist2BDeleted;
        }
        public async Task<SampleSets> DeleteSampleSetsAsync(SampleSets sampleSets2BDeleted)
        {
            _context.SampleSet.Remove(sampleSets2BDeleted);
            await _context.SaveChangesAsync();
            return sampleSets2BDeleted;
        }

        public async Task<SavedProject> DeleteSavedProjectAsync(SavedProject savedProject2BDeleted)
        {
            _context.SavedProject.Remove(savedProject2BDeleted);
            await _context.SaveChangesAsync();
            return savedProject2BDeleted;
        }

        public async Task<Track> DeleteTrackAsync(Track track2BDeleted)
        {
            _context.Track.Remove(track2BDeleted);
            await _context.SaveChangesAsync();
            return track2BDeleted;
        }
        public async Task<UserProject> DeleteUserProjectAsync(UserProject userProject2BDeleted)
        {
            _context.UserProject.Remove(userProject2BDeleted);
            await _context.SaveChangesAsync();
            return userProject2BDeleted;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// This block of code has to do with the finding and returning of different models in our database.
        /// We do this by getting the identifying id of an object which is unique and locating that object in our database and returning said object.
        /// We also have created methods to get all objects in a certain table like all Patterns or Samples.
        /// </summary>
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<Pattern> GetPatternByIDAsync(int patternID)
        {
            return await _context.Pattern
                .AsNoTracking()
                .FirstOrDefaultAsync(pattern => pattern.Id == patternID);
        }

        public async Task<List<Pattern>> GetPatternsAsync()
        {
            return await _context.Pattern
                .AsNoTracking()
                .Select(pattern => pattern)
                .ToListAsync();
        }

        public async Task<Sample> GetSampleByIDAsync(int sampleID)
        {
            return await _context.Sample
                .Include(sample => sample.Track)
                .AsNoTracking()
                .FirstOrDefaultAsync(sample => sample.Id == sampleID);
        }

        public async Task<List<Sample>> GetSamplesAsync()
        {
            return await _context.Sample
                .Include(sample => sample.Track)
                .AsNoTracking()
                .Select(sample => sample)
                .ToListAsync();
        }
        public async Task<SamplePlaylist> GetSamplePlaylistByIDAsync(int samplePlaylistID)
        {
            return await _context.SamplePlaylist
                .FirstOrDefaultAsync(samplePlaylist => samplePlaylist.Id == samplePlaylistID);
        }

        public async Task<List<SamplePlaylist>> GetSamplePlaylistsAsync()
        {
            return await _context.SamplePlaylist
                .Select(sample => sample)
                .ToListAsync();
        }
        public async Task<SampleSets> GetSampleSetsByIDAsync(int sampleSetID)
        {
            return await _context.SampleSet
                .FirstOrDefaultAsync(sampleSet => sampleSet.Id == sampleSetID);
        }

        public async Task<List<SampleSets>> GetSampleSetsAsync()
        {
            return await _context.SampleSet
                .Select(sample => sample)
                .ToListAsync();
        }
        public async Task<SavedProject> GetSavedProjectByIDAsync(int savedProjectID)
        {
            return await _context.SavedProject
                .Include(savedProject => savedProject.UserProjects)
                .AsNoTracking()
                .FirstOrDefaultAsync(savedProject => savedProject.Id == savedProjectID);
        }

        public async Task<List<SavedProject>> GetSavedProjectsAsync()
        {
            return await _context.SavedProject
                .Include(savedProject => savedProject.UserProjects)
                .AsNoTracking()
                .Select(sampleProject => sampleProject)
                .ToListAsync();
        }

        public async Task<Track> GetTrackByIDAsync(int trackID)
        {
            return await _context.Track
                .Include(track => track.Pattern)
                .AsNoTracking()
                .Include(track => track.Sample)
                .AsNoTracking()
                .Include(track => track.SavedProject)
                .AsNoTracking()
                .FirstOrDefaultAsync(track => track.Id == trackID);
        }

        public async Task<List<Track>> GetTracksAsync()
        {
            return await _context.Track
                .Include(track => track.Pattern)
                .AsNoTracking()
                .Include(track => track.Sample)
                .AsNoTracking()
                .Include(track => track.SavedProject)
                .AsNoTracking()
                .Select(track => track)
                .ToListAsync();
        }
        public Task<UserProject> GetUserProjectByIDAsync(int userProjectID)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserProject>> GetUserProjectsAsync()
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// This block of code has to do with the updating of different models in our database.
        /// We achieve this by getting a new object of that type. We then find the matching Id of that object in our database
        /// and update its values to the new values of the object we got. 
        /// </summary>
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<Pattern> UpdatePatternAsync(Pattern pattern2BUpdated)
        {
            Pattern oldPattern = await _context.Pattern.Where(s => s.Id == pattern2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldPattern).CurrentValues.SetValues(pattern2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return oldPattern;
        }

        public async Task<Sample> UpdateSampleAsync(Sample sample2BUpdated)
        {
            Sample oldSample = await _context.Sample.Where(s => s.Id == sample2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldSample).CurrentValues.SetValues(sample2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return oldSample;
        }
        public async Task<SamplePlaylist> UpdateSamplePlaylistAsync(SamplePlaylist samplePlaylist2BUpdated)
        {
            SamplePlaylist oldSamplePlaylist = await _context.SamplePlaylist.Where(s => s.Id == samplePlaylist2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldSamplePlaylist).CurrentValues.SetValues(samplePlaylist2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return oldSamplePlaylist;
        }
        public async Task<SampleSets> UpdateSampleSetsAsync(SampleSets sampleSet2BUpdated)
        {
            SampleSets oldSampleSets = await _context.SampleSet.Where(s => s.Id == sampleSet2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldSampleSets).CurrentValues.SetValues(sampleSet2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return oldSampleSets;
        }


        public async Task<SavedProject> UpdateSavedProjectAsync(SavedProject savedProject2BUpdated)
        {
            SavedProject oldSavedProject = await _context.SavedProject.Where(sp => sp.Id == savedProject2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldSavedProject).CurrentValues.SetValues(savedProject2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return oldSavedProject;
        }

        public async Task<Track> UpdateTrackAsync(Track track2BUpdated)
        {
            Track oldTrack = await _context.Track.Where(t => t.Id == track2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldTrack).CurrentValues.SetValues(track2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return track2BUpdated;
        }

        

        public Task<UserProject> UpdateUserProjectAsync(UserProject userProject2BUpdated)
        {
            throw new NotImplementedException();
        }

        
    }
}
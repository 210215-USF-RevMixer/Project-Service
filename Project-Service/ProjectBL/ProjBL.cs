using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDL;
using ProjectModels;

namespace ProjectBL
{
    public class ProjBL : IProjectBL
    {
        private IProjectRepoDB _repo;
        public ProjBL(IProjectRepoDB repo)
        {
            _repo = repo;
        }

        //SavedProject
        public async Task<SavedProject> AddSavedProjectAsync(SavedProject newSavedProject, int userId)
        {
            newSavedProject =  await _repo.AddSavedProjectAsync(newSavedProject);
            UserProject userProject = new UserProject();
            userProject.ProjectId = newSavedProject.Id;
            userProject.Owner = true;
            userProject.UserId = userId;
            userProject.SavedProject = newSavedProject;
            await _repo.AddUserProjectAsync(userProject);
            return await _repo.GetSavedProjectByIDAsync(newSavedProject.Id);
        }
        public async Task<SavedProject> DeleteSavedProjectAsync(SavedProject savedProject2BDeleted)
        {
            return await _repo.DeleteSavedProjectAsync(savedProject2BDeleted);
        }
        public async Task<SavedProject> GetSavedProjectByIDAsync(int savedProjectID)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetSavedProjectByIDAsync(savedProjectID);
        }
        public async Task<List<SavedProject>> GetSavedProjectsAsync()
        {
            return await _repo.GetSavedProjectsAsync();
        }
        public async Task<SavedProject> UpdateSavedProjectAsync(SavedProject savedProject2BUpdated)
        {
            return await _repo.UpdateSavedProjectAsync(savedProject2BUpdated);
        }

        //UserProject
        public async Task<UserProject> AddUserProjectAsync(UserProject newUserProject)
        {
            return await _repo.AddUserProjectAsync(newUserProject);
        }
        public async Task<UserProject> DeleteUserProjectAsync(UserProject userProject2BDeleted)
        {
            return await _repo.DeleteUserProjectAsync(userProject2BDeleted);
        }
        public async Task<UserProject> GetUserProjectByIDAsync(int id)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetUserProjectByIDAsync(id);
        }
        public async Task<List<UserProject>> GetUserProjectsAsync()
        {
            return await _repo.GetUserProjectsAsync();
        }
        public async Task<UserProject> UpdateUserProjectAsync(UserProject userProject2BUpdated)
        {
            return await _repo.UpdateUserProjectAsync(userProject2BUpdated);
        }

        //Track
        public async Task<Track> AddTrackAsync(Track newTrack)
        {
            return await _repo.AddTrackAsync(newTrack);
        }
        public async Task<Track> DeleteTrackAsync(Track track2BDeleted)
        {
            return await _repo.DeleteTrackAsync(track2BDeleted);
        }
        public async Task<Track> GetTrackByIDAsync(int trackID)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetTrackByIDAsync(trackID);
        }
        public async Task<List<Track>> GetTracksAsync()
        {
            return await _repo.GetTracksAsync();
        }
        public async Task<Track> UpdateTrackAsync(Track track2BUpdated)
        {
            return await _repo.UpdateTrackAsync(track2BUpdated);
        }

        //Pattern
        public async Task<Pattern> AddPatternAsync(Pattern newPattern)
        {
            //Todo: Add BL
            return await _repo.AddPatternAsync(newPattern);
        }
        public async Task<Pattern> DeletePatternAsync(Pattern pattern2BDeleted)
        {
            return await _repo.DeletePatternAsync(pattern2BDeleted);
        }
        public async Task<Pattern> GetPatternByIDAsync(int patternID)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetPatternByIDAsync(patternID);
        }
        public async Task<List<Pattern>> GetPatternsAsync()
        {
            //TODO add BL
            return await _repo.GetPatternsAsync();
        }
        public async Task<Pattern> UpdatePatternAsync(Pattern pattern2BUpdated)
        {
            return await _repo.UpdatePatternAsync(pattern2BUpdated);
        }

        //Sample
        public async Task<Sample> AddSampleAsync(Sample newSample, int userId)
        {
            //Sample sample2Add = new Sample();
            //sample2Add.SampleLink = newSample.SampleLink;
            //sample2Add.SampleName = newSample.SampleName;
            //sample2Add.Track = newSample.Track;
            //sample2Add.IsApproved = newSample.IsApproved;
            //sample2Add.IsLocked = newSample.IsLocked;
            //sample2Add.IsPrivate = newSample.IsPrivate;

            //Todo: Add BL
            newSample =  await _repo.AddSampleAsync(newSample);
            UsersSample usersSample = new UsersSample();
            usersSample.SampleId = newSample.Id;
            usersSample.IsOwner = true;
            usersSample.UserId = userId;
            await _repo.AddUsersSampleAsync(usersSample);
            return await _repo.GetSampleByIDAsync(newSample.Id);

        }
        public async Task<Sample> DeleteSampleAsync(Sample sample2BDeleted)
        {
            return await _repo.DeleteSampleAsync(sample2BDeleted);
        }
        public async Task<Sample> GetSampleByIDAsync(int sampleID)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetSampleByIDAsync(sampleID);
        }
        // public async Task<List<Sample>> GetSampleByUserIDAsync(int userID)
        // {
        //     return await _repo.GetSampleByUserIDAsync(userID);
        // }
        public async Task<List<Sample>> GetSamplesAsync()
        {
            //TODO add BL
            return await _repo.GetSamplesAsync();
        }
        public async Task<Sample> UpdateSampleAsync(Sample sample2BUpdated)
        {
            return await _repo.UpdateSampleAsync(sample2BUpdated);
        }

        //SamplePlaylist
        public async Task<SamplePlaylist> AddSamplePlaylistAsync(SamplePlaylist newSamplePlaylist)
        {
            return await _repo.AddSamplePlaylistAsync(newSamplePlaylist);
        }
        public async Task<SamplePlaylist> DeleteSamplePlaylistAsync(SamplePlaylist samplePlaylist2BDeleted)
        {
            return await _repo.DeleteSamplePlaylistAsync(samplePlaylist2BDeleted);
        }
        public async Task<SamplePlaylist> GetSamplePlaylistByIDAsync(int samplePlaylistID)
        {
            return await _repo.GetSamplePlaylistByIDAsync(samplePlaylistID);
        }

        public async Task<List<SamplePlaylist>> GetSamplePlaylistsAsync()
        {
            return await _repo.GetSamplePlaylistsAsync();
        }
        public async Task<SamplePlaylist> UpdateSamplePlaylistAsync(SamplePlaylist samplePlaylist2BUpdated)
        {
            return await _repo.UpdateSamplePlaylistAsync(samplePlaylist2BUpdated);
        }

        //SampleSets 
        public async Task<SampleSets> AddSampleSetsAsync(SampleSets newSampleSets, int userId)
        {
            newSampleSets = await _repo.AddSampleSetsAsync(newSampleSets);
            UsersSampleSets usersSampleSets = new UsersSampleSets();
            usersSampleSets.SampleSetsId = newSampleSets.Id;
            usersSampleSets.UserId = userId;
            usersSampleSets.IsOwner = true;
            await _repo.AddUsersSampleSetsAsync(usersSampleSets);
            return await _repo.GetSampleSetsByIDAsync(newSampleSets.Id);

        }
        public async Task<SampleSets> DeleteSampleSetsAsync(SampleSets sampleSets2BDeleted)
        {
            return await _repo.DeleteSampleSetsAsync(sampleSets2BDeleted);
        }
        public async Task<List<SampleSets>> GetSampleSetsAsync()
        {
            return await _repo.GetSampleSetsAsync();
        }
        public async Task<SampleSets> GetSampleSetsByIDAsync(int sampleSetID)
        {
            return await _repo.GetSampleSetsByIDAsync(sampleSetID);
        }
        public async Task<SampleSets> UpdateSampleSetsAsync(SampleSets sampleSet2BUpdated)
        {
            return await _repo.UpdateSampleSetsAsync(sampleSet2BUpdated);
        }
        
        //UsersSample
        public async Task<UsersSample> AddUsersSampleAsync(UsersSample newUsersSample)
        {
            return await _repo.AddUsersSampleAsync(newUsersSample);
        }
        public async Task<UsersSample> DeleteUsersSampleAsync(UsersSample usersSample2BDeleted)
        {
            return await _repo.DeleteUsersSampleAsync(usersSample2BDeleted);
        }
        public async Task<List<UsersSample>> GetUsersSamplesAsync()
        {
            return await _repo.GetUsersSamplesAsync();
        }
        public async Task<UsersSample> GetUsersSampleByIDAsync(int usersSampleID)
        {
            return await _repo.GetUsersSampleByIDAsync(usersSampleID);
        }
        public async Task<List<UsersSample>> GetUsersSampleByUserIDAsync(int userID)
        {
            return await _repo.GetUsersSampleByUserIDAsync(userID);
        }
        public async Task<UsersSample> UpdateUsersSampleAsync(UsersSample usersSample2BUpdated)
        {
            return await _repo.UpdateUsersSampleAsync(usersSample2BUpdated);
        }
        
        //UsersSampleSets
        public async Task<UsersSampleSets> AddUsersSampleSetsAsync(UsersSampleSets newUsersSampleSets)
        {
            return await _repo.AddUsersSampleSetsAsync(newUsersSampleSets);
        }
        public async Task<UsersSampleSets> DeleteUsersSampleSetsAsync(UsersSampleSets usersSampleSets2BDeleted)
        {
            return await _repo.DeleteUsersSampleSetsAsync(usersSampleSets2BDeleted);
        }
        public async Task<List<UsersSampleSets>> GetUsersSampleSetsAsync()
        {
            return await _repo.GetUsersSampleSetsAsync();
        }
        public async Task<UsersSampleSets> GetUsersSampleSetsByIDAsync(int usersSampleSetsID)
        {
            return await _repo.GetUsersSampleSetsByIDAsync(usersSampleSetsID);
        }
        public async Task<List<UsersSampleSets>> GetUsersSampleSetsByUserIDAsync(int userID)
        {
            return await _repo.GetUsersSampleSetsByUserIDAsync(userID);
        }
        public async Task<UsersSampleSets> UpdateUsersSampleSetsAsync(UsersSampleSets usersSampleSets2BUpdated)
        {
            return await _repo.UpdateUsersSampleSetsAsync(usersSampleSets2BUpdated);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectModels;
using ProjectDL;
namespace ProjectBL
{
    public interface IProjectBL
    {
        Task<Sample> AddSampleAsync(Sample newSample, int userId);
        Task<SamplePlaylist> AddSamplePlaylistAsync(SamplePlaylist newSamplePlaylist);
        Task<SampleSets> AddSampleSetsAsync(SampleSets newSampleSets, int userId);
        Task<SavedProject> AddSavedProjectAsync(SavedProject newSavedProject, int userId);
        Task<Track> AddTrackAsync(Track newTrack);
        Task<Pattern> AddPatternAsync(Pattern newPattern);
        Task<UserProject> AddUserProjectAsync(UserProject newUserProject);
        Task<Pattern> DeletePatternAsync(Pattern pattern2BDeleted);
        Task<Sample> DeleteSampleAsync(Sample sample2BDeleted);
        Task<SamplePlaylist> DeleteSamplePlaylistAsync(SamplePlaylist samplePlaylist2BDeleted);
        Task<SampleSets> DeleteSampleSetsAsync(SampleSets sampleSets2BDeleted);
        Task<SavedProject> DeleteSavedProjectAsync(SavedProject savedProject2BDeleted);
        Task<Track> DeleteTrackAsync(Track track2BDeleted);
        Task<UserProject> DeleteUserProjectAsync(UserProject userProject2BDeleted);
        Task<Pattern> GetPatternByIDAsync(int patternID);
        Task<List<Pattern>> GetPatternsAsync();
        Task<List<UserProject>> GetUserProjectsAsync();
        Task<UserProject> GetUserProjectByIDAsync(int userProjectID);
        Task<Sample> GetSampleByIDAsync(int sampleID);
        //Task<List<Sample>> GetSampleByUserIDAsync(int userID);
        Task<SamplePlaylist> GetSamplePlaylistByIDAsync(int samplePlaylistID);
        Task<List<SamplePlaylist>> GetSamplePlaylistsAsync();
        Task<List<Sample>> GetSamplesAsync();
        Task<List<SampleSets>> GetSampleSetsAsync();
        Task<SampleSets> GetSampleSetsByIDAsync(int sampleSetID);
        Task<SavedProject> GetSavedProjectByIDAsync(int savedProjectID);
        Task<List<SavedProject>> GetSavedProjectsAsync();
        Task<Track> GetTrackByIDAsync(int trackID);
        Task<List<Track>> GetTracksAsync();
        Task<Pattern> UpdatePatternAsync(Pattern pattern2BUpdated);
        Task<UserProject> UpdateUserProjectAsync(UserProject userProject2BUpdated);
        Task<Sample> UpdateSampleAsync(Sample sample2BUpdated);
        Task<SamplePlaylist> UpdateSamplePlaylistAsync(SamplePlaylist samplePlaylist2BUpdated);
        Task<SampleSets> UpdateSampleSetsAsync(SampleSets sampleSet2BUpdated);
        Task<SavedProject> UpdateSavedProjectAsync(SavedProject savedProject2BUpdated);
        Task<Track> UpdateTrackAsync(Track track2BUpdated);
        //UsersSample
        Task<UsersSample> AddUsersSampleAsync(UsersSample newUsersSample);
        Task<UsersSample> DeleteUsersSampleAsync(UsersSample usersSample2BDeleted);
        Task<List<UsersSample>> GetUsersSamplesAsync();
        Task<UsersSample> GetUsersSampleByIDAsync(int usersSampleID);
        Task<List<UsersSample>> GetUsersSampleByUserIDAsync(int usersSampleUserID);
        Task<UsersSample> UpdateUsersSampleAsync(UsersSample usersSample2BUpdated);
        
        //UsersSampleSets
        Task<UsersSampleSets> AddUsersSampleSetsAsync(UsersSampleSets newUsersSampleSets);
        Task<UsersSampleSets> DeleteUsersSampleSetsAsync(UsersSampleSets usersSampleSets2BDeleted);
        Task<List<UsersSampleSets>> GetUsersSampleSetsAsync();
        Task<UsersSampleSets> GetUsersSampleSetsByIDAsync(int usersSampleSetsID);
        Task<List<UsersSampleSets>> GetUsersSampleSetsByUserIDAsync(int usersSampleSetsUserID);
        Task<UsersSampleSets> UpdateUsersSampleSetsAsync(UsersSampleSets usersSampleSets2BUpdated);
    }
}
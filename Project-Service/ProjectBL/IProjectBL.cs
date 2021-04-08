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
        //SavedProject
        Task<SavedProject> AddSavedProjectAsync(SavedProject newSavedProject);
        Task<SavedProject> DeleteSavedProjectAsync(SavedProject savedProject2BDeleted);
        Task<SavedProject> GetSavedProjectByIDAsync(int savedProjectID);
        Task<List<SavedProject>> GetSavedProjectsAsync();
        Task<SavedProject> UpdateSavedProjectAsync(SavedProject savedProject2BUpdated);

        //UserProject
        Task<UserProject> AddUserProjectAsync(UserProject newUserProject);
        Task<UserProject> DeleteUserProjectAsync(UserProject userProject2BDeleted);
        Task<UserProject> GetUserProjectByIDAsync(int id);
        Task<List<UserProject>> GetUserProjectsAsync();
        Task<UserProject> UpdateUserProjectAsync(UserProject userProject2BUpdated);

        //Track
        Task<Track> AddTrackAsync(Track newTrack);
        Task<Track> DeleteTrackAsync(Track track2BDeleted);
        Task<Track> GetTrackByIDAsync(int trackID);
        Task<List<Track>> GetTracksAsync();
        Task<Track> UpdateTrackAsync(Track track2BUpdated);

        //Pattern

        //Sample

        //SamplePlaylist

        //SampleSets
        Task<Sample> AddSampleAsync(Sample newSample);
        Task<SamplePlaylist> AddSamplePlaylistAsync(SamplePlaylist newSamplePlaylist);
        Task<SampleSets> AddSampleSetsAsync(SampleSets newSampleSets);
        
        
        
        Task<Pattern> DeletePatternAsync(Pattern pattern2BDeleted);
        Task<Sample> DeleteSampleAsync(Sample sample2BDeleted);
        Task<SamplePlaylist> DeleteSamplePlaylistAsync(SamplePlaylist samplePlaylist2BDeleted);
        Task<SampleSets> DeleteSampleSetsAsync(SampleSets sampleSets2BDeleted);
        
        
        
        Task<Pattern> GetPatternByIDAsync(int patternID);
        Task<List<Pattern>> GetPatternsAsync();
        Task<Sample> GetSampleByIDAsync(int sampleID);
        Task<SamplePlaylist> GetSamplePlaylistByIDAsync(int samplePlaylistID);
        Task<List<SamplePlaylist>> GetSamplePlaylistsAsync();
        Task<List<Sample>> GetSamplesAsync();
        Task<List<SampleSets>> GetSampleSetsAsync();
        Task<SampleSets> GetSampleSetsByIDAsync(int sampleSetID);
        
        
        Task<Pattern> UpdatePatternAsync(Pattern pattern2BUpdated);
        Task<Sample> UpdateSampleAsync(Sample sample2BUpdated);
        Task<SamplePlaylist> UpdateSamplePlaylistAsync(SamplePlaylist samplePlaylist2BUpdated);
        Task<SampleSets> UpdateSampleSetsAsync(SampleSets sampleSet2BUpdated);
        
        

    }
}
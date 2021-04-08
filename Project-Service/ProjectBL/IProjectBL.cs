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
        Task<SavedProject> AddSavedProjectAsync(SavedProject newSavedProject);
        Task<SavedProject> DeleteSavedProjectAsync(SavedProject savedProject2BDeleted);
        Task<SavedProject> GetSavedProjectByIDAsync(int savedProjectID);
        Task<List<SavedProject>> GetSavedProjectsAsync();
        Task<SavedProject> UpdateSavedProjectAsync(SavedProject savedProject2BUpdated);
        Task<Sample> AddSampleAsync(Sample newSample);
        Task<Sample> DeleteSampleAsync(Sample sample2BDeleted);
        Task<Sample> GetSampleByIDAsync(int sampleID);
        Task<List<Sample>> GetSamplesAsync();
        Task<Sample> UpdateSampleAsync(Sample sample2BUpdated);
        Task<Track> AddTrackAsync(Track newTrack);
        Task<Track> DeleteTrackAsync(Track track2BDeleted);
        Task<Track> GetTrackByIDAsync(int trackID);
        Task<List<Track>> GetTracksAsync();
        Task<Track> UpdateTrackAsync(Track track2BUpdated);
        Task<Pattern> AddPatternAsync(Pattern newPattern);
        Task<Pattern> DeletePatternAsync(Pattern pattern2BDeleted);
        Task<Pattern> GetPatternByIDAsync(int patternID);
        Task<List<Pattern>> GetPatternsAsync();
        Task<Pattern> UpdatePatternAsync(Pattern pattern2BUpdated);

        Task<UserProject> AddUserProjectAsync(UserProject newUserProject);
        Task<UserProject> DeleteUserProjectAsync(UserProject userProject2BDeleted);
        Task<UserProject> GetUserProjectByIDAsync(int id);
        Task<List<UserProject>> GetUserProjectsAsync();
        Task<UserProject> UpdateUserProjectAsync(UserProject userProject2BUpdated);
        Task<Comments> AddCommentAsync(Comments newComment);
        Task<Comments> DeleteCommentAsync(Comments comment2BDeleted);
        Task<Comments> GetCommentByIDAsync(int id);
        Task<List<Comments>> GetCommentsAsync();
        Task<Comments> UpdateCommentAsync(Comments comment2BUpdated);

        Task<List<Comments>> GetCommentsByMusicIDAsync(int id);

    }
}
using Domain.Entities;
using prmToolkit.NotificationPattern;

namespace Domain.Contracts
{
    public static class MovieContract
    {
        public static void AddMovieContract(this Movie movie)
        {
            new AddNotifications<Movie>(movie)
                .IfNullOrEmpty(m => m.Original_title)
                .IfEqualsZero(m => m.Year)
                .IfNullOrEmpty(m => m.Overview)
                .IfEqualsZero(m => m.Vote_average);
        }
    }
}
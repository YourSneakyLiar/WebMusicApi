using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IAlbumRepository Album { get; }
        ITrackRepository Track { get; }
        IPlaylistRepository Playlist { get; }
        IGenreRepository Genre { get; }
        ILikeRepository Like { get; } // Добавьте это свойство

        Task Save();
    }
}
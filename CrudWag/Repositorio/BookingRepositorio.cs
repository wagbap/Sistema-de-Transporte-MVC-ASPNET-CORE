using Microsoft.EntityFrameworkCore;
using CrudWag.Data;
using CrudWag.Models;
using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CrudWag.Repositorio
{

    public class BookingRepositorio : IBookingRepositorio
    {
        private readonly BancoDbContext ctx;
        public BookingRepositorio(BancoDbContext ctx)
        {
            this.ctx = ctx;
        }

        public List<BookingModel> BuscarTodos()
        {
            return ctx.TbBooking.ToList();
        }

        public bool Add(BookingModel model)
        {
            try
            {

                ctx.TbBooking.Add(model);
                ctx.SaveChanges();
                foreach (int genreId in model.MotoristaId)
                {
                    var movieGenre = new MovieGenre
                    {
                        MovieId = model.Id,
                        GenreId = genreId
                    };
                    ctx.MovieGenre.Add(movieGenre);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                var movieGenres = ctx.MovieGenre.Where(a => a.MovieId == data.Id);
                foreach (var movieGenre in movieGenres)
                {
                    ctx.MovieGenre.Remove(movieGenre);
                }
                ctx.TbBooking.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public BookingModel GetById(int id)
        {
            return ctx.TbBooking.Find(id);
        }



        public bool Update(BookingModel model)
        {
            try
            {
                // these genreIds are not selected by users and still present is movieGenre table corresponding to
                // this movieId. So these ids should be removed.
                var genresToDeleted = ctx.MovieGenre.Where(a => a.MovieId == model.Id && !model.MotoristaId.Contains(a.GenreId)).ToList();
                foreach (var mGenre in genresToDeleted)
                {
                    ctx.MovieGenre.Remove(mGenre);
                }
                foreach (int genId in model.MotoristaId)
                {
                    var movieGenre = ctx.MovieGenre.FirstOrDefault(a => a.MovieId == model.Id && a.GenreId == genId);
                    if (movieGenre == null)
                    {
                        movieGenre = new MovieGenre { GenreId = genId, MovieId = model.Id };
                        ctx.MovieGenre.Add(movieGenre);
                    }
                }

                ctx.TbBooking.Update(model);
                // we have to add these genre ids in movieGenre table
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<int> GetMotoristaByBookingId(int movieId)
        {
            var genreIds = ctx.MovieGenre.Where(a => a.MovieId == movieId).Select(a => a.GenreId).ToList();
            return genreIds;
        }

    }
}

using AutoMapper;
using BertoniLibrary.Models;
using Bertoni.ViewModels;

namespace Bertoni.Web.Profiles
{
    public class PhotoProfile : Profile {
        public PhotoProfile() {
            CreateMap<Photo, Photo>();
        }
    }
}
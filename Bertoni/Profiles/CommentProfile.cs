using AutoMapper;
using BertoniLibrary.Models;
using Bertoni.ViewModels;

namespace Bertoni.Profiles {
    public class CommentProfile : Profile {
        public CommentProfile() {
            CreateMap<Comment, Comment>();
        }
    }
}
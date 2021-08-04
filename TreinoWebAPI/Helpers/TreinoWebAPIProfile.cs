using AutoMapper;
using TreinoWebAPI.Dto;
using TreinoWebAPI.models;

namespace TreinoWebAPI.Helpers
{
    public class TreinoWebAPIProfile : Profile
    {
        //CONSTRUTOR    
        public TreinoWebAPIProfile()
        {
            //Poderia ser ASSIM...
            //CreateMap<Produto, ProdutoDto>();
            //<ProdutoDto, Produto>();

            //Ou ASSIM:
             CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}
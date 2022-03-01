﻿using AutoMapper;
using System;
using TP.Condutores.Application.ViewModels;
using TP.Condutores.Domain;
using TP.Core.DomainObjects;

namespace TP.Condutores.Application.AutoMapper
{
    public class ExibirCondutorQuerieToViewModel : Profile
    {
        public ExibirCondutorQuerieToViewModel()
        {
            CreateMap<Condutor, ExibirCondutorViewModel>()
                .ForMember(n => n.PrimeiroNome, c => c.MapFrom(c => c.Nome.PrimeiroNome))
                .ForMember(n => n.UltimoNome, c => c.MapFrom(c => c.Nome.UltimoNome))
                .ForMember(n => n.Veiculos, c => c.MapFrom(c => c.Veiculo));

            CreateMap<VeiculoCondutor, VeiculoCondutorViewModel>();
        }
    }

    public class ViewModelToExibirCondutorQuerie : Profile
    {
        public ViewModelToExibirCondutorQuerie()
        {
            CreateMap<ExibirCondutorViewModel, Condutor>()
                .ConstructUsing(c => new Condutor(new Nome(c.PrimeiroNome, c.UltimoNome), 
                c.CPF, c.Telefone, c.Email, c.CNH, Convert.ToDateTime(c.DataNascimento)));

            CreateMap<VeiculoCondutorViewModel, VeiculoCondutor>()
                .ConstructUsing(c => new VeiculoCondutor(Guid.Parse(c.CondutorId), c.Placa));
        }
    }
}

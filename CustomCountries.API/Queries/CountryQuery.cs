﻿using CustomCountries.API.Models;
using CustomCountries.API.Services;
using CustomCountries.API.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCountries.API.Queries
{
    public class CountryQuery
    {
        private readonly CountryService _countryService;

        public CountryQuery(CountryService countryService)
        {
            _countryService = countryService;
        }

        public IQueryable<Country> CountryList => _countryService.GetSomeData();
        //public Country ListCountry() =>
        //    //_context.Countries.ToList();
        //new Country
        //    {
        //        Id = "XXXXX",
        //        Area = 7.7F,
        //        Capital = "Brasília"
        //    };
        //public CountryQuery(/*UsuarioRepositorio repositorio*/)
        //{
        //    Field<ListGraphType<CountryType>>(
        //    name: "authors", resolve: context =>
        //    {
        //        return new List<Country>()
        //        {
        //            new Country() {
        //                Id = "XXXXX",
        //                Area = 7.7F,
        //                Capital = "Brasília"
        //            },
        //            new Country() {
        //                Id = "ZZZZZZ",
        //                Area = 7.7F,
        //                Capital = "AAA"
        //            }
        //        };
        //    });
        //    //Field<ListGraphType<UsuarioType>>("usuario",
        //    //    arguments: new QueryArguments(new QueryArgument[]
        //    //    {
        //    //        new QueryArgument<IdGraphType>{Name="id"},
        //    //        new QueryArgument<StringGraphType>{Name="nome"}
        //    //    }),
        //    //    resolve: contexto =>
        //    //    {
        //    //        var filtro = new UsuarioFiltro()
        //    //        {
        //    //            Id = contexto.GetArgument<int>("id"),
        //    //            Nome = contexto.GetArgument<string>("nome"),
        //    //        };
        //    //        return repositorio.ObterUsuarios(filtro);
        //    //    }

        //    //    );
        //}
    }
}

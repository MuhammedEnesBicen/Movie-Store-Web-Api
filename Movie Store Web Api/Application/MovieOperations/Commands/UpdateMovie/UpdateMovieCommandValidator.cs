﻿using FluentValidation;
using System;

namespace Movie_Store_Web_Api.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command => command.Model).NotNull();
            RuleFor(command => command.MovieId).GreaterThan(0);
            RuleFor(command => command.Model.DirectorId).GreaterThan(0);
            RuleFor(command => command.Model.Price).GreaterThanOrEqualTo(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.MovieYear).GreaterThan(DateTime.Parse("12/12/1799"));
            RuleFor(command => command.Model.Name.Length).GreaterThan(0);
            
        }
    }
}

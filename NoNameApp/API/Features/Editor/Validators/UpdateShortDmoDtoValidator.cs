﻿using FluentValidation;
using Model;
using Model.DTOs.Editor;

namespace API.Features.Editor.Validators {
    public class UpdateShortDmoDtoValidator : AbstractValidator<UpdateShortDmoDto> {
        public UpdateShortDmoDtoValidator() {
            RuleFor(d => d.Id)
                .NotEmpty()
                .WithMessage("Dmo id is missing");

            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("Dmo name is missing")
                .MaximumLength(ApplicationConstants.MaxDmoNameLength)
                .WithMessage($"Maximum dmo name length is {ApplicationConstants.MaxDmoNameLength}");

            RuleFor(d => d.MovieTitle)
                .NotEmpty()
                .WithMessage("Movie title is missing")
                .MaximumLength(ApplicationConstants.MaxMovieTitleLength)
                .WithMessage($"Maximum movie title length is {ApplicationConstants.MaxMovieTitleLength}");

            RuleFor(d => d.ShortComment)
                .MaximumLength(ApplicationConstants.MaxShortCommentLength)
                .WithMessage($"Maximum comment length is {ApplicationConstants.MaxShortCommentLength}");
        }
    }
}

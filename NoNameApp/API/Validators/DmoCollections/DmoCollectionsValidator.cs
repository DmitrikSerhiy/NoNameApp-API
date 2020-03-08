﻿using API.DTO.DmoCollections;
using FluentValidation;
using Model;

namespace API.Validators.DmoCollections {
    // ReSharper disable UnusedMember.Global
    public class DmoCollectionsValidator : AbstractValidator<DmoCollectionShortDto> {
        public DmoCollectionsValidator() {
            RuleFor(d => d.CollectionName)
                .NotEmpty().WithMessage("Name of collection is missing")
                .MaximumLength(ApplicationConstants.MaxEntityNameLength)
                .WithMessage($"Maximum collection name length is {ApplicationConstants.MaxEntityNameLength}");
        }
    }
}

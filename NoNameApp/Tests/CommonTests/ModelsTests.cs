﻿using FluentAssertions;
using Model.DTOs;
using System.Linq;
using Xunit;

namespace Tests.CommonTests {
    public class ModelsTests {

        [Fact]
        public void AllDtoShouldInheritBaseDtoClass() {
            //Arrange
            var allDtos = typeof(BaseDto).Assembly.Types().Where(t => t.Name.EndsWith("Dto") && t.Name != nameof(BaseDto)).ToList();

            //Assert
            allDtos.ForEach(dto => dto.Should().BeDerivedFrom<BaseDto>());
        }
    }
}

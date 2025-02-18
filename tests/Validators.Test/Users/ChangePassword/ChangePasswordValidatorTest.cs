﻿using CashFlow.Application.UseCases.Users.ChangePassword;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using Shouldly;

namespace Validators.Tests.Users.ChangePassword;
public class ChangePasswordValidatorTest
{
    [Fact]
    public void Success()
    {
        var validator = new ChangePasswordValidator();

        var request = RequestChangePasswordJsonBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Error_NewPassword_Empty(string newPassword)
    {
        var validator = new ChangePasswordValidator();

        var request = RequestChangePasswordJsonBuilder.Build();
        request.NewPassword = newPassword;

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldHaveSingleItem().ErrorMessage.ShouldBe(ResourceErrorMessages.INVALID_PASSWORD);
    }
}
